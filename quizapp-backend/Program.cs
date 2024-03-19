using quizapp_backend.Repository;
using Microsoft.EntityFrameworkCore;
using quizapp_backend.API;
using quizapp_backend.Database;
using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.UserModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Elephant");
Console.WriteLine("Connection string: ");
Console.WriteLine(connectionString); // Print the connection string to the console

builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseNpgsql(connectionString));

builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Quiz>, Repository<Quiz>>();
builder.Services.AddScoped<IRepository<Question>, Repository<Question>>();
builder.Services.AddScoped<IRepository<AnswerOption>, Repository<AnswerOption>>();
builder.Services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.PlayQuizEndpointConfiguration();
app.BuildQuizEndpointConfiguration();
//app.QuestionEndpointConfiguration();
//app.AnswereOptionEndpointConfiguration();
//app.UserAnswerEndpointConfiguration();

app.ApplyProjectMigrations();

//app.UseAuthorization();

app.Run();
