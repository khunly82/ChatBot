using ChatBot.BLL.Services;
using ChatBot.DAL;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject HttpClient
builder.Services.AddScoped(opt =>
{
    HttpClient httpClient = new HttpClient();
    // Pour rajouter le token dans les headers
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {builder.Configuration["OpenAI:ApiKey"]}");
    return httpClient;
});

// Inject Services
//builder.Services.AddScoped<WebClient>();
builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<AudioService>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddDbContext<OpenAIContext>(
    o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("Main") ?? throw new Exception("Missing connection string")
));

// Configure Cors
builder.Services.AddCors(o => o.AddDefaultPolicy(b => b
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// d'exposer le dossier wwwroot en dehors du serveur
app.UseStaticFiles();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
