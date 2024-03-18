using quizapp_backend.Models.AnswerOptionModels;

namespace quizapp_backend.DtoManagers
{
    public class AnswerOptionDtoManager
    {
        public static OutputAnswerOption Convert(AnswerOption answerOption)
        {
            return new OutputAnswerOption
            {
                Id = answerOption.Id,
                QuestionId = answerOption.QuestionId,
                Text = answerOption.Text,
                IsCorrect = answerOption.IsCorrect
            };
        }

        public static IEnumerable<OutputAnswerOption> Convert(IEnumerable<AnswerOption> answerOptions)
        {
            return answerOptions.Select(Convert);
        }

        public static AnswerOption Convert(InputAnswerOption inputAnswerOption)
        {
            return new AnswerOption
            {
                QuestionId = inputAnswerOption.QuestionId,
                Text = inputAnswerOption.Text,
                IsCorrect = inputAnswerOption.IsCorrect
            };
        }
    }
}
