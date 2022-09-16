﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Presentation.Controller
{
    [Route("api/surveys/{surveyId}/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public QuestionsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions(Guid surveyId)
        {
            var questions = await _service.QuestionService.GetQuestionsAsync(surveyId, trackChanges:false);
            return Ok(questions);
        }

        [HttpGet("{id:guid}", Name = "GetQuestionForSurvey")]
        public async Task<IActionResult> GetQuestion(Guid surveyId, Guid id)
        {
            var question = await _service.QuestionService.GetQuestionAsync(surveyId, id, trackChanges:false);
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestionForSurvey(Guid surveyId, [FromBody] QuestionForCreationDto question)
        {
            if (question is null)
            {
                return BadRequest("QuestionForCreationDto object is null.");
            }

            var createdQuestion = await _service.QuestionService.CreateQuestionForSurveyAsync(surveyId, question, trackChanges: false);

            return CreatedAtRoute("GetQuestionForSurvey", new { surveyId, id = createdQuestion.id }, createdQuestion);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteQuestionForSurvey(Guid surveyId, Guid id)
        {
            await _service.QuestionService.DeleteQuestionForSurveyAsync(surveyId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateQuestionForSurvey(Guid surveyId, Guid id, [FromBody] QuestionForUpdateDto questionForUpdate)
        {
            await _service.QuestionService.UpdateQuestionForSurveyAsync(surveyId, id, questionForUpdate, surveyTrackChanges: false, questionTrackChanges: true);

            return NoContent();
        }
    }
}
