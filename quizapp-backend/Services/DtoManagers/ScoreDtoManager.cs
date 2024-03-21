using quizapp_backend.Models.ScoreModels;

namespace quizapp_backend.Services.DtoManagers
{
    public static class ScoreDtoManager
    {
        public static AttemptOutput Convert (Attempt attempt) {
            return new AttemptOutput
            {
                UserId = attempt.UserId,
                Score = attempt.Score,
                QuizId = attempt.QuizId,
                HighestPossibleScore = attempt.HighestPossibleScore,
                Correct = attempt.Correct,
                Wrong = attempt.Wrong,
            };
        }
    }
}
