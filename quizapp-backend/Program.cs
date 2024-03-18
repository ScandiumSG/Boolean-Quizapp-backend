using quizapp_backend.Repository;
using Microsoft.EntityFrameworkCore;
using quizapp_backend.API;
using quizapp_backend.Database;
using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.UserModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("LocalDockerContainer")));

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

app.QuizEndpointConfiguration();
app.QuestionEndpointConfiguration();
app.AnswereOptionEndpointConfiguration();
app.UserAnswerEndpointConfiguration();

app.ApplyProjectMigrations();

//app.UseAuthorization();

app.Run();
