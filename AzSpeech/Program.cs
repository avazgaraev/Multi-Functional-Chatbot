using AzSpeech.Context;
using AzSpeech.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AzSpeechDbContext>(options => options.UseSqlServer("Server=tcp:azspeechdb.database.windows.net,1433;Initial Catalog=AzSpeechDB;Persist Security Info=False;User ID=azspeech;Password=Speech123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddScoped<ICognitiveServices, CognitiveServices>();
builder.Services.AddScoped<IChatbotService, ChatbotService>();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("https://localhost:4200",
                            "http://localhost:4200",
                            "http://azspeech.azurewebsites.net/",
                            "https://azspeech.azurewebsites.net/")
                .AllowAnyHeader()
                .AllowAnyMethod()
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
