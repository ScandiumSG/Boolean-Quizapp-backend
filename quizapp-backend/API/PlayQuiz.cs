using quizapp_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.DataTransferObjects;
using quizapp_backend.Services.DtoManagers;
using Microsoft.AspNetCore.Authorization;
using quizapp_backend.Models.ScoreModels;
using System.Security.Claims;
using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.API
{
    public static class PlayQuiz
    {
        public static void PlayQuizEndpointConfiguration(this WebApplication app)
        {
            var quiz = app.MapGroup("Play/Quiz");

            quiz.MapGet("", GetAll);
            quiz.MapGet("{id}", Get);
            quiz.MapPost("{id}", Answer);
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

            QuizPlay outputQuiz = QuizDtoManager.ConvertPlay(quiz);
            Payload<QuizPlay> payload = new Payload<QuizPlay>(outputQuiz);
            return TypedResults.Ok(payload);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Answer(ClaimsPrincipal user, IRepository<Quiz> quizRepository, IRepository<Attempt> scoreRepository, int id, QuizAttempt quizInput)
        {
            Quiz? quiz = await quizRepository.Get(id);
            if (quiz is null)
                return TypedResults.NotFound();

            var questions = quiz.Questions;
            int correctAnswers = 0;
            int wrongAnswers = 0;

            foreach (QuestionAttempt? questionInput in quizInput.Questions)
            {
                Question? question = questions.FirstOrDefault(q => q.Id == questionInput.Id);
                if (question is null)
                    return TypedResults.NotFound();

                IEnumerable<int> correctOptions = question.AnswerOptions.Where(a => a.IsCorrect).Select(a => a.Id);

                foreach (int answerInput in questionInput.AnswerOptionIds)
                {
                    bool isAnswerCorrect = correctOptions.Contains(answerInput);

                    if (isAnswerCorrect)
                        correctAnswers++;
                    else
                        wrongAnswers++;
                }
            }

            string userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

            Attempt attempt = new Attempt
            {
                UserId = userId,
                QuizId = quiz.Id,
                Score = correctAnswers - wrongAnswers,
                HighestPossibleScore = questions.Sum(q => q.AnswerOptions.Count(a => a.IsCorrect)),
                Correct = correctAnswers,
                Wrong = wrongAnswers
            };

            Attempt? existingAttempt = await scoreRepository.Get(a => a.UserId == userId && a.QuizId == id);
            if (existingAttempt == null && userId != quiz.UserId)
                await scoreRepository.Create(attempt);

            AttemptOutput output = AttemptDtoManager.Convert(attempt);
            Payload<Attempt> payload = new Payload<Attempt>(attempt);
            return TypedResults.Created("url", payload);
        }
    }
}
