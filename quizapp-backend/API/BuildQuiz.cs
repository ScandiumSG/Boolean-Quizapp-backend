using quizapp_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.DataTransferObjects;
using quizapp_backend.Services.DtoManagers;
using Microsoft.AspNetCore.Authorization;

namespace quizapp_backend.API
{
    public static class BuildQuiz
    {
        public static void BuildQuizEndpointConfiguration(this WebApplication app)
        {
            var quiz = app.MapGroup("Build/Quiz");

            quiz.MapGet("", GetAll);
            quiz.MapGet("{id}", Get);
            quiz.MapPost("", Create);
            quiz.MapPut("{id}", Update);
            quiz.MapDelete("{id}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Quiz> quizRepository)
        {
            ICollection<Quiz> quizzes = await quizRepository.Get();
            quizzes = quizzes.OrderByDescending(q => q.CreationDate).ToList();

            ICollection<QuizCard> outputQuizCard = QuizDtoManager.ConvertCard(quizzes);
            Payload<ICollection<QuizCard>> payload = new Payload<ICollection<QuizCard>>(outputQuizCard);
            return TypedResults.Ok(payload);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IRepository<Quiz> quizRepository, int id)
        {
            Quiz? quiz = await quizRepository.Get(id);
            if (quiz is null)
                return TypedResults.NotFound();

            QuizBuild outputQuiz = QuizDtoManager.ConvertBuild(quiz);
            Payload<QuizBuild> payload = new Payload<QuizBuild>(outputQuiz);
            return TypedResults.Ok(payload);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IRepository<Quiz> quizRepository, QuizCreate inputQuiz)
        {
            Quiz quiz = QuizDtoManager.Convert(inputQuiz);

            await quizRepository.Create(quiz);

            QuizBuild outputQuiz = QuizDtoManager.ConvertBuild(quiz);
            Payload<QuizBuild> payload = new Payload<QuizBuild>(outputQuiz);
            return TypedResults.Created("url", payload);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Update(IRepository<Quiz> quizRepository, int id, QuizUpdate inputQuiz)
        {
            Quiz? quiz = await quizRepository.Get(id);
            if (quiz is null)
                return TypedResults.NotFound();

            quiz.UserId = inputQuiz.UserId;
            quiz.Title = inputQuiz.Title;
            quiz.Description = inputQuiz.Description;

            await quizRepository.Update(quiz);

            QuizBuild outputQuiz = QuizDtoManager.ConvertBuild(quiz);
            Payload<QuizBuild> payload = new Payload<QuizBuild>(outputQuiz);
            return TypedResults.Ok(payload);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IRepository<Quiz> quizRepository, int id)
        {
            Quiz? quiz = await quizRepository.Delete(id);
            if (quiz is null)
                return TypedResults.NotFound();

            QuizBuild outputQuiz = QuizDtoManager.ConvertBuild(quiz);
            Payload<QuizBuild> payload = new Payload<QuizBuild>(outputQuiz);
            return TypedResults.Ok(payload);
        }
    }
}
