using DemoMixvel.Api.Swagger;
using DemoMixvel.Data.Repository;
using DemoMixvel.Data.Services;
using DemoMixvel.Database;
using DemoMixvel.Provider.One.Adapter;
using DemoMixvel.Provider.One.Validators;
using DemoMixvel.Provider.Two.Adapter;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ProviderOneSearchRequestValidator>();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true; 
    options.AssumeDefaultVersionWhenUnspecified = true; 
    options.DefaultApiVersion = new ApiVersion(1, 0); 
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; 
    options.SubstituteApiVersionInUrl = true; 
});

builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

//context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RouteDbContext>(options => options.UseSqlServer(connectionString!));

builder.Services.AddMemoryCache();
builder.Services.AddSingleton(new MemoryCacheEntryOptions
{
    SlidingExpiration = TimeSpan.FromMinutes(10),
    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
    Priority = CacheItemPriority.Normal
});

//other deps

builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddTransient<IRoutesRepository, RoutesRepository>();
builder.Services.AddTransient<IProviderOneAdapter, ProviderOneAdapter>();
builder.Services.AddTransient<IProviderTwoAdapter, ProviderTwoAdapter>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Run migrations on startup (just for easyness)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<RouteDbContext>();
    context.Database.Migrate();
}

app.Run();