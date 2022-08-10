var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapGet("/", () =>
{
    app.Logger.LogInformation("Initial Home Get");
    return "GET - Net 6 Running ... 09082022-v1.0.0 CI/CD in TRAVIS-CI v1.0.0 LAB 4 CARLOS ANGEL AFORO255";
});

app.MapPost("/", () =>
{
    app.Logger.LogInformation("Initial Home Post");
    return "POST - Net 6 Running ... 22042022-v1.0.0 CI/CD in AKS v1.0.0 AFORO255";
});

app.Run();

