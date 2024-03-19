using quizapp_backend.DataTransferObjects;
using quizapp_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using quizapp_backend.DtoManagers;
using quizapp_backend.Models.QuizModels;

namespace quizapp_backend.API
{
    public static class PlayQuiz
    {
        public static void PlayQuizEndpointConfiguration(this WebApplication app)
        {
            var quiz = app.MapGroup("Play/Quiz");

            quiz.MapGet("", GetAll);
            quiz.MapGet("{id}", Get);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Quiz> quizRepository)
        {
            ICollection<Quiz> quizzes = await quizRepository.Get();

            ICollection<QuizCard> outputQuizCard = QuizDtoManager.Convert(quizzes);
            Payload<ICollection<QuizCard>> payload = new Payload<ICollection<QuizCard>>(outputQuizCard);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IRepository<Quiz> quizRepository, int id)
        {
            Quiz? quiz = await quizRepository.Get(id);
            if (quiz is null)
                return TypedResults.NotFound();

            QuizPlay outputQuiz = QuizDtoManager.ConvertPlay(quiz);
            Payload<QuizPlay> payload = new Payload<QuizPlay>(outputQuiz);
            return TypedResults.Ok(payload);
        }
    }
}
