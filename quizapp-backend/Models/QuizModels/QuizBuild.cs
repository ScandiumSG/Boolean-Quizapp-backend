using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.Models.QuizModels
{
    public class QuizBuild
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<QuestionBuild>? Questions { get; set; }
    }
}
