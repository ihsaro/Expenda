using Expenda.Infrastructure;
using WalkieTalkie.Application;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "client/dist"
});

// Add services to the container.
builder.Services
    .RegisterApplicationDependencies()
    .RegisterInfrastructureDependencies(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapFallbackToFile("index.html");
app.Run();
