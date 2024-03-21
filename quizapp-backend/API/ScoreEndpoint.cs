using quizapp_backend.Models.DataTransferObjects;

namespace quizapp_backend.API
{
    public static class ScoreEndpoint
    {
        public static void ConfigureScoreEndpoint(this WebApplication app)
        {
            var score = app.MapGroup("Score");

            //score.MapGet("quiz/{id}", GetScoreByQuiz);
        }

        //public static async Task<IResult> GetScoreByQuiz(IRepository<Score> scoreRepository, int id)
        //{
        //    ICollection<Score> scores = await scoreRepository.GetByQuiz(id);

        //    ICollection<ScoreBuild> outputScores = ScoreDtoManager.ConvertBuild(scores);
        //    Payload<ICollection<ScoreOutput>> payload = new Payload<ICollection<ScoreOutput>>(outputScores);
        //    return TypedResults.Ok(payload);
        //}
    }
}
