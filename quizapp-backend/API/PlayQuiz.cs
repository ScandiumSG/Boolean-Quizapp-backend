using quizapp_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.DataTransferObjects;
using quizapp_backend.Services.DtoManagers;
using Microsoft.AspNetCore.Authorization;
using quizapp_backend.Models.ScoreModels;

namespace quizapp_backend.API
{
    public static class PlayQuiz
    {
        public static void PlayQuizEndpointConfiguration(this WebApplication app)
        {
            var quiz = app.MapGroup("Play/Quiz");

            quiz.MapGet("", GetAll);
            quiz.MapGet("{id}", Get);
            quiz.MapPost("{id}", Answere);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Quiz> quizRepository)
        {
            ICollection<Quiz> quizzes = await quizRepository.Get();

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

            QuizPlay outputQuiz = QuizDtoManager.ConvertPlay(quiz);
            Payload<QuizPlay> payload = new Payload<QuizPlay>(outputQuiz);
            return TypedResults.Ok(payload);
        }

        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Answere(IRepository<Quiz> quizRepository, IRepository<UserScore> scoreRepository, int id, QuizAttempt inputQuiz)
        {
            Quiz? quiz = await quizRepository.Get(id);
            if (quiz is null)
                return TypedResults.NotFound();

            var questions = quiz.Questions;
            int correctAnswers = 0;
            int wrongAnswers = 0;

            foreach (var questionAttempt in inputQuiz.Questions)
            {
                var question = questions.FirstOrDefault(q => q.Id == questionAttempt.Id);
                if (question != null)
                {
                    var correctOptions = question.AnswerOptions.Where(a => a.IsCorrect).Select(a => a.Id);

                    bool isAnswerCorrect = questionAttempt.AnswerOptionIds.OrderBy(id => id).SequenceEqual(correctOptions.OrderBy(id => id));

                    if (isAnswerCorrect)
                        correctAnswers++;
                    else
                        wrongAnswers++;
                }
            }

            UserScore userScore = new UserScore
            {
                UserId = inputQuiz.UserId,
                QuizId = quiz.Id,
                Score = correctAnswers - wrongAnswers,
                HighestPossibleScore = questions.Sum(q => q.AnswerOptions.Count(a => a.IsCorrect)),
                Correct = correctAnswers,
                Wrong = wrongAnswers
            };

            //TODO: Check if the user has already attempted the quiz
            await scoreRepository.Create(userScore);

            Payload<UserScore> payload = new Payload<UserScore>(userScore);
            return TypedResults.Created("url", payload);
        }


    }
}
