using Microsoft.AspNetCore.Mvc;
using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.DataTransferObjects;
using quizapp_backend.Repository;
using quizapp_backend.Services.DtoManagers;

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
            ICollection<AnswerOption> AnswerOptions = await AnswerOptionRepository.Get();

            ICollection<AnswerOptionBuild> outputAnswerOption = AnswerOptionDtoManager.ConvertBuild(AnswerOptions);
            Payload<ICollection<AnswerOptionBuild>> payload = new Payload<ICollection<AnswerOptionBuild>>(outputAnswerOption);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IRepository<AnswerOption> AnswerOptionRepository, int id)
        {
            AnswerOption? AnswerOption = await AnswerOptionRepository.Get(id);
            if (AnswerOption is null)
                return TypedResults.NotFound();

            AnswerOptionBuild outputAnswerOption = AnswerOptionDtoManager.ConvertBuild(AnswerOption);
            Payload<AnswerOptionBuild> payload = new Payload<AnswerOptionBuild>(outputAnswerOption);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IRepository<AnswerOption> AnswerOptionRepository, AnswerOptionCreate inputAnswerOption)
        {
            AnswerOption AnswerOption = AnswerOptionDtoManager.Convert(inputAnswerOption);

            await AnswerOptionRepository.Create(AnswerOption);

            AnswerOptionBuild outputAnswerOption = AnswerOptionDtoManager.ConvertBuild(AnswerOption);
            Payload<AnswerOptionBuild> payload = new Payload<AnswerOptionBuild>(outputAnswerOption);
            return TypedResults.Created("url", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Update(IRepository<AnswerOption> AnswerOptionRepository, int id, AnswerOptionCreate inputAnswerOption)
        {
            AnswerOption? answerOption = await AnswerOptionRepository.Get(id);
            if (answerOption is null)
                return TypedResults.NotFound();

            answerOption.Text = inputAnswerOption.Text;
            answerOption.IsCorrect = inputAnswerOption.IsCorrect;

            await AnswerOptionRepository.Update(answerOption);

            AnswerOptionBuild outputAnswerOption = AnswerOptionDtoManager.ConvertBuild(answerOption);
            Payload<AnswerOptionBuild> payload = new Payload<AnswerOptionBuild>(outputAnswerOption);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IRepository<AnswerOption> AnswerOptionRepository, int id)
        {
            AnswerOption? AnswerOption = await AnswerOptionRepository.Delete(id);
            if (AnswerOption is null)
                return TypedResults.NotFound();

            AnswerOptionBuild outputAnswerOption = AnswerOptionDtoManager.ConvertBuild(AnswerOption);
            Payload<AnswerOptionBuild> payload = new Payload<AnswerOptionBuild>(outputAnswerOption);
            return TypedResults.Ok(payload);
        }
    }
}
