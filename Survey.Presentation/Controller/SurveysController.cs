using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using Survey.Presentation.ModelBinders;
using System.Text.Json;

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
        public async Task<IActionResult> GetSurveys([FromQuery] SurveyParameters surveyParameters)
        {
           
            var pagedResult = await _service.SurveyService.GetAllSurveysAsync(surveyParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.surveys);
            
        }

        [HttpGet("{id:guid}", Name = "SurveyById")]
        public async Task<IActionResult> GetSurvey(Guid id)
        {
            var survey = await _service.SurveyService.GetSurveyAsync(id, trackChanges: false);
            return Ok(survey);
        }

        [HttpGet("collection/({ids})", Name = "SurveyCollection")]
        public async Task<IActionResult> GetSurveyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var surveys = await _service.SurveyService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(surveys);
        }


        [HttpGet("{id:guid}/all")]
        public async Task<IActionResult> GetSurveyEntire(Guid id)
        {
            var surveyEntire = await _service.SurveyService.GetSurveyQuestionsChoicesAsync(id, trackChanges: false);
            return Ok(surveyEntire);
        }



        [Authorize]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> CreateSurvey([FromBody] SurveyForCreationDto survey)
        {
            if (survey is null)
                return BadRequest("SurveyForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var userId = _service.UserProviderService.GetUserId();
            var createdSurvey = await _service.SurveyService.CreateSurveyAsync(userId, survey);
            
            return CreatedAtRoute("SurveyById", new { id = createdSurvey.Id }, createdSurvey);
        }



        [Authorize]
        [HttpPost("collection")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> CreateSurveyCollection([FromBody] IEnumerable<SurveyForCreationDto> surveyCollection)
        {
            if (surveyCollection is null)
                return BadRequest("IEnumerable<SurveyForCreationDto> object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdSurveyCollection = await _service.SurveyService.CreateSurveyCollectionAsync(surveyCollection);
            return CreatedAtRoute("SurveyCollection", new { createdSurveyCollection.ids }, createdSurveyCollection.surveys);
        }



        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSurvey(Guid id)
        {
            await _service.SurveyService.DeleteSurveyAsync(id, trackChanges:false) ;
            return NoContent();
        }

        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
