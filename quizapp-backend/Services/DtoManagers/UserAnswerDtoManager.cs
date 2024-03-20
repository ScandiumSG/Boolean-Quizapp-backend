﻿using quizapp_backend.Models.QuestionUserAnswerModels;

namespace quizapp_backend.Services.DtoManagers
{
    public static class UserAnswerDtoManager
    {
        public static OutputUserAnswer Convert(UserAnswer questionUserAnswer)
        {
            return new OutputUserAnswer
            {
                QuestionId = questionUserAnswer.QuestionId,
                AnswerOptionId = questionUserAnswer.AnswerOptionId,
            };
        }

        public static ICollection<OutputUserAnswer> Convert(ICollection<UserAnswer> questionUserAnswers)
        {
            return questionUserAnswers.Select(Convert).ToList();
        }

        // Create UserAnswer
        public static UserAnswer Convert(InputUserAnswer inputQuestionUserAnswer)
        {
            return new UserAnswer
            {
                QuestionId = inputQuestionUserAnswer.QuestionId,
                AnswerOptionId = inputQuestionUserAnswer.AnswerOptionId,
                UserId = inputQuestionUserAnswer.UserId
            };
        }

        public static List<UserAnswer> Convert(List<InputUserAnswer> inputQuestionUserAnswers)
        {
            return inputQuestionUserAnswers.Select(Convert).ToList();
        }

        // User Output
        public static OutputUserAnswer ConvertUser(UserAnswer questionUserAnswer)
        {
            return new OutputUserAnswer
            {
                AnswerOptionId = questionUserAnswer.AnswerOptionId,
            };
        }

        public static ICollection<OutputUserAnswer> ConvertUser(ICollection<UserAnswer> questionUserAnswers)
        {
            return questionUserAnswers.Select(Convert).ToList();
        }
    }
}
