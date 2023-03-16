using Example.Api.Errors;
using Example.Application;
using Example.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

    // builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
