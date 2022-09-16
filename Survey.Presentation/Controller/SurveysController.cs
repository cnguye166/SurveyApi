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
    [Route("api/surveys")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SurveysController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSurveys()
        {
           
            var surveys = await _service.SurveyService.GetAllSurveysAsync(trackChanges: false);
            return Ok(surveys);
            
        }

        [HttpGet("{id:guid}", Name = "SurveyById")]
        public async Task<IActionResult> GetSurvey(Guid id)
        {
            var survey = await _service.SurveyService.GetSurveyAsync(id, trackChanges: false);
            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] SurveyForCreationDto survey)
        {
            if (survey is null)
                return BadRequest("SurveyForCreationDto object is null");

            var createdSurvey = await _service.SurveyService.CreateSurveyAsync(survey);

            return CreatedAtRoute("SurveyById", new { id = createdSurvey.Id }, createdSurvey);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSurvey(Guid id)
        {
            await _service.SurveyService.DeleteSurveyAsync(id, trackChanges:false) ;
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSurvey(Guid id, SurveyForUpdateDto survey)
        {
            if (survey is null)
                return BadRequest("SurveyForUpdateDto object is null");
            await _service.SurveyService.UpdateSurveyAsync(id, survey, trackChanges:true);

            return NoContent();
        }
    }
}
