using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.Interfaces;
using PsychoUnedApi.Models;
using PsychoUnedApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configura la política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:8100") // Origen permitido
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IExamQuestionService, ExamQuestionService>();
builder.Services.AddScoped<IExamQuestionAnswer, ExamQuestionAnswerService>();
builder.Services.AddScoped<IExamsService, ExamsService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
