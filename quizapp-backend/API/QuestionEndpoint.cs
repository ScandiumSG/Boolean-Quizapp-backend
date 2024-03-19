using quizapp_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.API
{
    //public static class QuestionEndpoint
    //{
    //    public static void QuestionEndpointConfiguration(this WebApplication app)
    //    {
    //        var question = app.MapGroup("Question");

    //        question.MapGet("", GetAll);
    //        question.MapGet("{id}", Get);
    //        question.MapPost("", Create);
    //        question.MapPut("{id}", Update);
    //        question.MapDelete("{id}", Delete);
    //    }

    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    public static async Task<IResult> GetAll(IRepository<Question> questionRepository)
    //    {
    //        ICollection<Question> questions = await questionRepository.Get();

    //        ICollection<OutputQuestion> outputQuestion = QuestionDtoManager.Convert(questions);
    //        Payload<ICollection<OutputQuestion>> payload = new Payload<ICollection<OutputQuestion>>(outputQuestion);
    //        return TypedResults.Ok(payload);
    //    }

    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    public static async Task<IResult> Get(IRepository<Question> questionRepository, int id)
    //    {
    //        Question? question = await questionRepository.Get(id);
    //        if (question is null)
    //            return TypedResults.NotFound();

    //        OutputQuestion outputQuestion = QuestionDtoManager.Convert(question);
    //        Payload<OutputQuestion> payload = new Payload<OutputQuestion>(outputQuestion);
    //        return TypedResults.Ok(payload);
    //    }

    //    [ProducesResponseType(StatusCodes.Status201Created)]
    //    public static async Task<IResult> Create(IRepository<Question> questionRepository, QuestionInput inputQuestion)
    //    {
    //        Question question = QuestionDtoManager.Convert(inputQuestion);

    //        await questionRepository.Create(question);

    //        OutputQuestion outputQuestion = QuestionDtoManager.Convert(question);
    //        Payload<OutputQuestion> payload = new Payload<OutputQuestion>(outputQuestion);
    //        return TypedResults.Created("url", payload);
    //    }

    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    public static async Task<IResult> Update(IRepository<Question> questionRepository, int id, QuestionInput inputQuestion)
    //    {
    //        Question? question = await questionRepository.Get(id);
    //        if (question is null)
    //            return TypedResults.NotFound();

    //        question.Text = inputQuestion.Text;

    //        await questionRepository.Update(question);

    //        OutputQuestion outputQuestion = QuestionDtoManager.Convert(question);
    //        Payload<OutputQuestion> payload = new Payload<OutputQuestion>(outputQuestion);
    //        return TypedResults.Ok(payload);
    //    }

    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    public static async Task<IResult> Delete(IRepository<Question> questionRepository, int id)
    //    {
    //        Question? question = await questionRepository.Delete(id);
    //        if (question is null)
    //            return TypedResults.NotFound();

    //        OutputQuestion outputQuestion = QuestionDtoManager.Convert(question);
    //        Payload<OutputQuestion> payload = new Payload<OutputQuestion>(outputQuestion);
    //        return TypedResults.Ok(payload);
    //    }
    //}
}
