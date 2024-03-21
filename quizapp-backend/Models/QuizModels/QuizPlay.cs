using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.Models.QuizModels
{
    public class QuizPlay
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<QuestionPlay> Questions { get; set; }
    }
}
