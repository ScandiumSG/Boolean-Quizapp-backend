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
            userAnswer.MapPost("", Create);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll([FromServices] IRepository<UserAnswer> userAnswerRepository)
        {
            ICollection<UserAnswer> userAnswers = await userAnswerRepository.Get();

            ICollection<OutputUserAnswer> outputUserAnswer = UserAnswerDtoManager.Convert(userAnswers);

            Payload<ICollection<OutputUserAnswer>> payload = new Payload<ICollection<OutputUserAnswer>>(outputUserAnswer);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create([FromServices] IRepository<UserAnswer> userAnswerRepository, List<InputUserAnswer> inputUserAnswers)
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
    }
}
