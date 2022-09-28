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
    [Route("api/surveys/{surveyId}/filled")]
    [ApiController]
    public class FilledSurveyController : ControllerBase
    {
        private readonly IServiceManager _service;

        public FilledSurveyController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilledSurveys(Guid surveyId)
        {
            var filledSurveys = await _service.FilledSurveyService.GetFilledSurveysAsync(surveyId, trackChanges: false);
            return Ok(filledSurveys);
        }

        [HttpGet("{id:guid}", Name = "GetFilledSurvey")]
        public async Task<IActionResult> GetFilledSurvey(Guid surveyId, Guid id)
        {
            var filledSurvey = await _service.FilledSurveyService.GetFilledSurveyAsync(surveyId, id, trackChanges: false);
            return Ok(filledSurvey);
        }

        [HttpGet("{id:guid}/all")]
        public async Task<IActionResult> GetFilledSurveyEntire(Guid surveyId, Guid id)
        {
            var filledSurveyEntire = await _service.FilledSurveyService.GetFilledSurveyAnswersAsync(surveyId, id, trackChanges: false);

            return Ok(filledSurveyEntire);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> CreateFilledSurvey(Guid surveyId, [FromBody] FilledSurveyForCreationDto filledSurveyForCreationDto)
        {
            if (filledSurveyForCreationDto is null)
                return BadRequest("FilledSurveyForCreationDto object is null");
            var createdFilledSurvey = await _service.FilledSurveyService.CreateFilledSurveyForSurveyAsync(surveyId, filledSurveyForCreationDto, false);
            return CreatedAtRoute("GetFilledSurvey", new { surveyId, id = createdFilledSurvey.Id }, createdFilledSurvey);
        }





    }
}
