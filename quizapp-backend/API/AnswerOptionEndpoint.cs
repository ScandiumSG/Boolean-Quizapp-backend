using quizapp_backend.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using quizapp_backend.DtoManagers;
using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Repository;

namespace quizapp_backend.API
{
    public static class AnswerOptionEndpoint
    {
        public static void AnswereOptionEndpointConfiguration(this WebApplication app)
        {
            var AnswerOption = app.MapGroup("AnswerOption");

            AnswerOption.MapGet("", GetAll);
            AnswerOption.MapGet("{id}", Get);
            AnswerOption.MapPost("", Create);
            AnswerOption.MapPut("{id}", Update);
            AnswerOption.MapDelete("{id}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<AnswerOption> AnswerOptionRepository)
        {
            IEnumerable<AnswerOption> AnswerOptions = await AnswerOptionRepository.Get();

            IEnumerable<OutputAnswerOption> outputAnswerOption = AnswerOptionDtoManager.Convert(AnswerOptions);

            Payload<IEnumerable<OutputAnswerOption>> payload = new Payload<IEnumerable<OutputAnswerOption>>(outputAnswerOption);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IRepository<AnswerOption> AnswerOptionRepository, int id)
        {
            AnswerOption? AnswerOption = await AnswerOptionRepository.Get(id);
            if (AnswerOption is null)
                return TypedResults.NotFound();

            OutputAnswerOption outputAnswerOption = AnswerOptionDtoManager.Convert(AnswerOption);

            Payload<OutputAnswerOption> payload = new Payload<OutputAnswerOption>(outputAnswerOption);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IRepository<AnswerOption> AnswerOptionRepository, InputAnswerOption inputAnswerOption)
        {
            AnswerOption AnswerOption = AnswerOptionDtoManager.Convert(inputAnswerOption);

            await AnswerOptionRepository.Create(AnswerOption);

            OutputAnswerOption outputAnswerOption = AnswerOptionDtoManager.Convert(AnswerOption);

            Payload<OutputAnswerOption> payload = new Payload<OutputAnswerOption>(outputAnswerOption);

            return TypedResults.Created("url", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Update(IRepository<AnswerOption> AnswerOptionRepository, int id, InputAnswerOption inputAnswerOption)
        {
            AnswerOption? answerOption = await AnswerOptionRepository.Get(id);
            if (answerOption is null)
                return TypedResults.NotFound();

            answerOption.Text = inputAnswerOption.Text;
            answerOption.IsCorrect = inputAnswerOption.IsCorrect;
            answerOption.QuestionId = inputAnswerOption.QuestionId;

            await AnswerOptionRepository.Update(answerOption);

            OutputAnswerOption outputAnswerOption = AnswerOptionDtoManager.Convert(answerOption);

            Payload<OutputAnswerOption> payload = new Payload<OutputAnswerOption>(outputAnswerOption);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IRepository<AnswerOption> AnswerOptionRepository, int id)
        {
            AnswerOption? AnswerOption = await AnswerOptionRepository.Delete(id);
            if (AnswerOption is null)
                return TypedResults.NotFound();

            OutputAnswerOption outputAnswerOption = AnswerOptionDtoManager.Convert(AnswerOption);

            Payload<OutputAnswerOption> payload = new Payload<OutputAnswerOption>(outputAnswerOption);

            return TypedResults.Ok(payload);
        }
    }
}
