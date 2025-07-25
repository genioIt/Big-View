using Microsoft.EntityFrameworkCore;
using WebApiEducation.Application;
using WebApiEducation.Application.App;
using WebApiEducation.Application.Mapper;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Interface;
using WebApiEducation.Infrastructure.Persistence;
using WebApiEducation.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enabled CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();
    builder.Services.AddScoped<StudentApplication>();
    builder.Services.AddScoped<INoteRepository, NoteRepository>();
    builder.Services.AddScoped<NoteApplication>();
    builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
    builder.Services.AddScoped<TeacherApplication>();
    builder.Services.AddScoped<ILogWebApiRepository, LogWebApiRepository>();

}

void ConfigureMapper(WebApplicationBuilder builder)
{
    builder.Services.AddAutoMapper(
          typeof(StudentMapper),
          typeof(NoteMapper),
          typeof(TeacherMapper),
          typeof(ResponseServiceMapper)
        );
}

//Context
builder.Services.AddDbContext<AudisoftEducationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


ConfigureServices(builder);
ConfigureMapper(builder);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usa la política de CORS
app.UseCors("allowAngular");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

