using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.Services.DtoManagers
{
    public class QuestionDtoManager
    {
        // Create
        public static Question Convert(QuestionCreate inputQuestion)
        {
            return new Question
            {
                Text = inputQuestion.Text,
                Order = inputQuestion.Order,
                AnswerOptions = AnswerOptionDtoManager.Convert(inputQuestion.AnswerOptions)
            };
        }

        public static ICollection<Question> Convert(ICollection<QuestionCreate> inputQuestions)
        {
            return inputQuestions.Select(inputQuestion => Convert(inputQuestion)).ToList();
        }

        // Update
        public static Question Convert(QuestionCreate inputQuestion, int quizId)
        {
            return new Question
            {
                QuizId = quizId,
                Text = inputQuestion.Text,
                Order = inputQuestion.Order,
                AnswerOptions = AnswerOptionDtoManager.Convert(inputQuestion.AnswerOptions)
            };
        }

        public static ICollection<Question> Convert(ICollection<QuestionCreate> inputQuestions, int quizId)
        {
            return inputQuestions.Select(inputQuestion => Convert(inputQuestion, quizId)).ToList();
        }

        // Read Play
        public static QuestionPlay ConvertPlay(Question question)
        {
            return new QuestionPlay
            {
                Id = question.Id,
                Text = question.Text,
                Order = question.Order,
                AnswerOptions = AnswerOptionDtoManager.ConvertPlay(question.AnswerOptions)
            };
        }

        public static ICollection<QuestionPlay> ConvertPlay(ICollection<Question> questions)
        {
            return questions.Select(ConvertPlay).ToList();
        }

        // Read Build
        public static QuestionBuild ConvertBuild(Question question)
        {
            return new QuestionBuild
            {
                Id = question.Id,
                Text = question.Text,
                Order = question.Order,
                AnswerOptions = AnswerOptionDtoManager.ConvertBuild(question.AnswerOptions)
            };
        }

        public static ICollection<QuestionBuild> ConvertBuild(ICollection<Question> questions)
        {
            return questions.Select(ConvertBuild).ToList();
        }
    }
}
