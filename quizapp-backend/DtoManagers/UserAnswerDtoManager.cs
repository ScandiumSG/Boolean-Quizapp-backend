using quizapp_backend.Models.QuestionUserAnswerModels;

namespace quizapp_backend.DtoManagers
{
    public static class UserAnswerDtoManager
    {
        public static OutputUserAnswer Convert(UserAnswer questionUserAnswer)
        {
            return new OutputUserAnswer
            {
                QuestionId = questionUserAnswer.QuestionId,
                AnswerOptionId = questionUserAnswer.AnswerOptionId,
                UserId = questionUserAnswer.UserId
            };
        }

        public static IEnumerable<OutputUserAnswer> Convert(IEnumerable<UserAnswer> questionUserAnswers)
        {
            return questionUserAnswers.Select(Convert);
        }

        public static UserAnswer Convert(InputUserAnswer inputQuestionUserAnswer)
        {
            return new UserAnswer
            {
                QuestionId = inputQuestionUserAnswer.QuestionId,
                AnswerOptionId = inputQuestionUserAnswer.AnswerOptionId,
                UserId = inputQuestionUserAnswer.UserId
            };
        }
    }
}
