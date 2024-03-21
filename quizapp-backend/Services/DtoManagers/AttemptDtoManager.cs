using quizapp_backend.Models.ScoreModels;

namespace quizapp_backend.Services.DtoManagers
{
    public static class AttemptDtoManager
    {
        public static AttemptOutput Convert(Attempt attempt)
        {
            return new AttemptOutput
            {
                UserId = attempt.UserId,
                QuizId = attempt.QuizId,
                Score = attempt.Score,
                HighestPossibleScore = attempt.HighestPossibleScore,
                Correct = attempt.Correct,
                Wrong = attempt.Wrong
            };
        }
    }
}
