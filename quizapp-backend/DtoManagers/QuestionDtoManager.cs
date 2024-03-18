using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.DtoManagers
{
    public class QuestionDtoManager
    {
        public static OutputQuestion Convert(Question question)
        {
            return new OutputQuestion
            {
                Id = question.Id,
                QuizId = question.QuizId,
                Text = question.Text
            };
        }

        public static IEnumerable<OutputQuestion> Convert(IEnumerable<Question> questions)
        {
            return questions.Select(Convert);
        }

        public static Question Convert(InputQuestion inputQuestion)
        {
            return new Question
            {
                QuizId = inputQuestion.QuizId,
                Text = inputQuestion.Text
            };
        }
    }
}
