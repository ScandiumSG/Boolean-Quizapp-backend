using quizapp_backend.Models.AnswerOptionModels;

namespace quizapp_backend.Services.DtoManagers
{
    public class AnswerOptionDtoManager
    {
        // Read Play
        public static AnswerOptionPlay ConvertPlay(AnswerOption answerOption)
        {
            return new AnswerOptionPlay
            {
                Id = answerOption.Id,
                Text = answerOption.Text
            };
        }

        public static ICollection<AnswerOptionPlay> ConvertPlay(ICollection<AnswerOption> answerOptions)
        {
            return answerOptions.Select(ConvertPlay).ToList();
        }

        // Read Build
        public static AnswerOptionBuild ConvertBuild(AnswerOption answerOption)
        {
            return new AnswerOptionBuild
            {
                Id = answerOption.Id,
                Text = answerOption.Text,
                IsCorrect = answerOption.IsCorrect
            };
        }

        public static ICollection<AnswerOptionBuild> ConvertBuild(ICollection<AnswerOption> answerOptions)
        {
            return answerOptions.Select(ConvertBuild).ToList();
        }

        // Create
        public static AnswerOption Convert(AnswerOptionCreate inputAnswerOption)
        {
            return new AnswerOption
            {
                Text = inputAnswerOption.Text,
                IsCorrect = inputAnswerOption.IsCorrect
            };
        }

        public static ICollection<AnswerOption> Convert(ICollection<AnswerOptionCreate> inputAnswerOptions)
        {
            return inputAnswerOptions.Select(Convert).ToList();
        }
    }
}
