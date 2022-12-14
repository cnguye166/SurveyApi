using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Service.Contracts;
using Shared.DataTransferObjects;
using Survey.Presentation.ModelBinders;

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

        [HttpGet("collection/({ids})", Name = "QuestionCollection")]
        public async Task<IActionResult> GetQuestionCollection(Guid surveyId, [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var questions = await _service.QuestionService.GetByIdsAsync(surveyId, ids, trackChanges:false);
            return Ok(questions);
        }


        [HttpGet("{id:guid}/all")]
        public async Task<IActionResult> GetQuestionEntire(Guid surveyId, Guid id)
        {
            var questionEntire = await _service.QuestionService.GetQuestionChoicesAsync(surveyId, id, trackChanges: false);
            return Ok(questionEntire);
        }

        [Authorize]
        [HttpPost]

        public async Task<IActionResult> CreateQuestionForSurvey(Guid surveyId, [FromBody] QuestionForCreationDto question)
        {
            if (question is null)
                return BadRequest("QuestionForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdQuestion = await _service.QuestionService.CreateQuestionForSurveyAsync(surveyId, question, trackChanges: false);

            return CreatedAtRoute("GetQuestionForSurvey", new { surveyId, id = createdQuestion.Id }, createdQuestion);
        }



        [Authorize]
        [HttpPost("collection")]

        public async Task<IActionResult> CreateQuestionsCollection(Guid surveyId, [FromBody] IEnumerable<QuestionForCreationDto> questionCollection)
        {
            if (questionCollection is null)
                return BadRequest("IEnumerable<QuestionForCreationDto> object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdQuestionCollection = await _service.QuestionService.CreateQuestionCollectionAsync(surveyId, questionCollection);

            return CreatedAtRoute("QuestionCollection", new {surveyId, ids = createdQuestionCollection.ids }, createdQuestionCollection.questions);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]

        public async Task<IActionResult> DeleteQuestionForSurvey(Guid surveyId, Guid id)
        {
            await _service.QuestionService.DeleteQuestionForSurveyAsync(surveyId, id, trackChanges: false);
            return NoContent();
        } 

        [Authorize]
        [HttpPut("{id:guid}")]

        public async Task<IActionResult> UpdateQuestionForSurvey(Guid surveyId, Guid id, [FromBody] QuestionForUpdateDto questionForUpdate)
        {
            if (questionForUpdate is null)
                return BadRequest("QuestionForUpdateDto object is null");

            await _service.QuestionService.UpdateQuestionForSurveyAsync(surveyId, id, questionForUpdate, surveyTrackChanges: false, questionTrackChanges: true);

            return NoContent();
        }
    }
}
