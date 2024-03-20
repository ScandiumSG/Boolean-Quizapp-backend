using Microsoft.AspNetCore.Mvc;
using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Repository;
using quizapp_backend.Models.DataTransferObjects;
using quizapp_backend.Services.DtoManagers;

namespace quizapp_backend.API
{
    public static class UserAnswerEndpoint
    {
        public static void UserAnswerEndpointConfiguration(this WebApplication app)
        {
            var userAnswer = app.MapGroup("UserAnswer");

            userAnswer.MapGet("", GetAll);
            userAnswer.MapGet("{questionId}/{userId}", Get);
            userAnswer.MapPost("", Create);
            //userAnswer.MapPut("{questionId}/{userId}", Update);
            userAnswer.MapDelete("{questionId}/{userId}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll([FromServices] IUserAnswerRepository userAnswerRepository)
        {
            ICollection<UserAnswer> userAnswers = await userAnswerRepository.Get();

            ICollection<OutputUserAnswer> outputUserAnswer = UserAnswerDtoManager.Convert(userAnswers);

            Payload<ICollection<OutputUserAnswer>> payload = new Payload<ICollection<OutputUserAnswer>>(outputUserAnswer);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get([FromServices] IUserAnswerRepository userAnswerRepository, int questionId, int userId)
        {
            UserAnswer? userAnswer = await userAnswerRepository.Get(questionId, userId);
            if (userAnswer is null)
                return TypedResults.NotFound();

            OutputUserAnswer outputUserAnswer = UserAnswerDtoManager.Convert(userAnswer);
            Payload<OutputUserAnswer> payload = new Payload<OutputUserAnswer>(outputUserAnswer);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create([FromServices] IUserAnswerRepository userAnswerRepository, List<InputUserAnswer> inputUserAnswers)
        {
            List<OutputUserAnswer> outputUserAnswers = new List<OutputUserAnswer>();

            foreach (var inputUserAnswer in inputUserAnswers)
            {
                UserAnswer userAnswer = UserAnswerDtoManager.Convert(inputUserAnswer);

                await userAnswerRepository.Create(userAnswer);

                OutputUserAnswer outputUserAnswer = UserAnswerDtoManager.Convert(userAnswer);
                outputUserAnswers.Add(outputUserAnswer);
            }

            Payload<List<OutputUserAnswer>> payload = new Payload<List<OutputUserAnswer>>(outputUserAnswers);
            return TypedResults.Created("url", payload);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> Delete([FromServices] IUserAnswerRepository userAnswerRepository, int questionId, int userId)
        {
            UserAnswer? userAnswer = await userAnswerRepository.Delete(questionId, userId);
            if (userAnswer is null)
                return TypedResults.NotFound();

            OutputUserAnswer outputUserAnswer = UserAnswerDtoManager.Convert(userAnswer);
            Payload<OutputUserAnswer> payload = new Payload<OutputUserAnswer>(outputUserAnswer);
            return TypedResults.Ok(payload);
        }
    }
}
