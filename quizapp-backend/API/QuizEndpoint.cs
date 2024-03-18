using quizapp_backend.DataTransferObjects;
using quizapp_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using quizapp_backend.DtoManagers;
using quizapp_backend.Models.QuizModels;

namespace quizapp_backend.API
{
    public static class QuizEndpoint
    {
        public static void QuizEndpointConfiguration(this WebApplication app)
        {
            var quiz = app.MapGroup("Quiz");

            quiz.MapGet("", GetAll);
            quiz.MapGet("{id}", Get);
            quiz.MapPost("", Create);
            quiz.MapPut("{id}", Update);
            quiz.MapDelete("{id}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Quiz> quizRepository)
        {
            IEnumerable<Quiz> quizzes = await quizRepository.Get();

            IEnumerable<OutputQuiz> outputQuiz = QuizDtoManager.Convert(quizzes);
            Payload<IEnumerable<OutputQuiz>> payload = new Payload<IEnumerable<OutputQuiz>>(outputQuiz);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IRepository<Quiz> quizRepository, int id)
        {
            Quiz? quiz = await quizRepository.Get(id);
            if (quiz is null)
                return TypedResults.NotFound();

            OutputQuiz outputQuiz = QuizDtoManager.Convert(quiz);
            Payload<OutputQuiz> payload = new Payload<OutputQuiz>(outputQuiz);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IRepository<Quiz> quizRepository, InputQuiz inputQuiz)
        {
            Quiz quiz = QuizDtoManager.Convert(inputQuiz);

            await quizRepository.Create(quiz);

            OutputQuiz outputQuiz = QuizDtoManager.Convert(quiz);
            Payload<OutputQuiz> payload = new Payload<OutputQuiz>(outputQuiz);
            return TypedResults.Created("url", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Update(IRepository<Quiz> quizRepository, int id, InputQuiz inputQuiz)
        {
            Quiz? quiz = await quizRepository.Get(id);
            if (quiz is null)
                return TypedResults.NotFound();

            quiz.UserId = inputQuiz.UserId;
            quiz.Title = inputQuiz.Title;
            quiz.Description = inputQuiz.Description;

            await quizRepository.Update(quiz);

            OutputQuiz outputQuiz = QuizDtoManager.Convert(quiz);
            Payload<OutputQuiz> payload = new Payload<OutputQuiz>(outputQuiz);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IRepository<Quiz> quizRepository, int id)
        {
            Quiz? quiz = await quizRepository.Delete(id);
            if (quiz is null)
                return TypedResults.NotFound();

            OutputQuiz outputQuiz = QuizDtoManager.Convert(quiz);
            Payload<OutputQuiz> payload = new Payload<OutputQuiz>(outputQuiz);
            return TypedResults.Ok(payload);
        }
    }
}
