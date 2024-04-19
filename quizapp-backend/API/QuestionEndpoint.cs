using quizapp_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.DataTransferObjects;
using quizapp_backend.Services.DtoManagers;

namespace quizapp_backend.API
{
    public static class QuestionEndpoint
    {
        public static void QuestionEndpointConfiguration(this WebApplication app)
        {
            var question = app.MapGroup("Question");

            question.MapGet("", GetAll);
            question.MapGet("{id}", Get);
            question.MapPost("", Create);
            question.MapPut("{id}", Update);
            question.MapDelete("{id}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Question> questionRepository)
        {
            ICollection<Question> questions = await questionRepository.Get();

            ICollection<QuestionBuild> outputQuestion = QuestionDtoManager.ConvertBuild(questions);
            Payload<ICollection<QuestionBuild>> payload = new Payload<ICollection<QuestionBuild>>(outputQuestion);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Get(IRepository<Question> questionRepository, int id)
        {
            Question? question = await questionRepository.Get(id);
            if (question is null)
                return TypedResults.NotFound();

            QuestionBuild outputQuestion = QuestionDtoManager.ConvertBuild(question);
            Payload<QuestionBuild> payload = new Payload<QuestionBuild>(outputQuestion);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IRepository<Question> questionRepository, QuestionCreate inputQuestion)
        {
            Question question = QuestionDtoManager.Convert(inputQuestion);

            await questionRepository.Create(question);

            QuestionBuild outputQuestion = QuestionDtoManager.ConvertBuild(question);
            Payload<QuestionBuild> payload = new Payload<QuestionBuild>(outputQuestion);
            return TypedResults.Created("url", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Update(IRepository<Question> questionRepository, int id, QuestionUpdate inputQuestion)
        {
            Question? question = await questionRepository.Get(id);
            if (question is null)
                return TypedResults.NotFound();

            question.Text = inputQuestion.Text;
            question.Order = inputQuestion.Order;

            await questionRepository.Update(question);

            QuestionBuild outputQuestion = QuestionDtoManager.ConvertBuild(question);
            Payload<QuestionBuild> payload = new Payload<QuestionBuild>(outputQuestion);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Delete(IRepository<Question> questionRepository, int id)
        {
            Question? question = await questionRepository.Delete(id);
            if (question is null)
                return TypedResults.NotFound();

            QuestionBuild outputQuestion = QuestionDtoManager.ConvertBuild(question);
            Payload<QuestionBuild> payload = new Payload<QuestionBuild>(outputQuestion);
            return TypedResults.Ok(payload);
        }
    }
}
