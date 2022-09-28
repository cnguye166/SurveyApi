using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Presentation.Controller
{
    [Route("api/surveys/{surveyId}/questions/{questionId}/choices")]
    public class ChoicesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ChoicesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetChoices(Guid surveyId, Guid questionId)
        {
            var choices = await _service.ChoiceService.GetChoicesAsync(surveyId, questionId, trackChanges: false);

            return Ok(choices);
        }

        [HttpGet("{id:int}", Name = "GetChoiceForQuestion")]
        public async Task<IActionResult> GetChoice(Guid surveyId, Guid questionId, int id)
        {
            var choice = await _service.ChoiceService.GetChoiceAsync(surveyId, questionId, id, trackChanges: false);
            return Ok(choice);
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateChoiceForQuestion(Guid surveyId, Guid questionId, [FromBody] ChoiceForCreationDto choiceForCreation)
        {
            if (choiceForCreation is null)
                return BadRequest("ChoiceForCreationDto object is null");

            var createdChoice = await _service.ChoiceService.CreateChoiceForQuestionAsync(surveyId, questionId, choiceForCreation, trackChanges: false);
            return CreatedAtRoute("GetChoiceForQuestion", new {surveyId, questionId, id = createdChoice.Id}, createdChoice);
        }

        [Authorize]
        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteChoiceForQuestion(Guid surveyId, Guid questionId, int id)
        {
            await _service.ChoiceService.DeleteChoiceForQuestionAsync(surveyId, questionId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [Authorize]

        public async Task<IActionResult> UpdateChoiceForQuestion(Guid surveyId, Guid questionId, int id, [FromBody] ChoiceForUpdateDto choiceForUpdate)
        {
            if (choiceForUpdate is null)
                return BadRequest("ChoiceForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.ChoiceService.UpdateChoiceForQuestionAsync(surveyId, questionId, id, choiceForUpdate, questionTrackChanges: false, choiceTrackChanges: true);
            return NoContent();
        }
    }
}
