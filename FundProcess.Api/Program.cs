using FundProcess.Lib;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPerformanceService, PerformanceService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// route API 
app.MapGet("/performance", (
    IPerformanceService performanceService,
    DateTime from,
    DateTime to
) =>
{
    // dataset en dur
    var dataset = new[]
    {
        Tuple.Create(new DateTime(2024, 01, 01), 100.0),
        Tuple.Create(new DateTime(2024, 03, 01), 120.0),
        Tuple.Create(new DateTime(2024, 05, 01), 140.0),
        Tuple.Create(new DateTime(2024, 07, 01), 160.0)
    };

    try
    {
        var result = performanceService.GetPerformance(dataset, from, to);
        return Results.Ok(new { performance = result });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("GetPerformance");

app.Run();
