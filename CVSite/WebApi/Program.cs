using Microsoft.Extensions.DependencyInjection;
using Service.Classes;
using WebApi.CachedService;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddGitHubIntegration(option => builder.Configuration.GetSection(nameof(GitHubIntegrationOptions)).Bind(option));
builder.Services.Configure<GitHubIntegrationOptions>(builder.Configuration.GetSection("GitHubIntegrationOptions"));



builder.Services.AddMemoryCache();
//GitHubService ???? ?? CachedGitHubService
builder.Services.Decorate<IGitHubService,CachedGitHubService>();
//CachedGitHubService ???? ?????     


var app = builder.Build();

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
