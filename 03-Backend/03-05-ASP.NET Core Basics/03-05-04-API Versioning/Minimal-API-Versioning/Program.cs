using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Asp.Versioning.Conventions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader =
    ApiVersionReader.Combine(
       new HeaderApiVersionReader("Api-Version"),
       new QueryStringApiVersionReader("Query-String-Version"));
}).AddApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    //setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();
var versionSet = app.NewApiVersionSet()
                    .HasApiVersion(1.0)
                    .HasApiVersion(2.0)
                    .ReportApiVersions()
                    .Build();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapGet("/GetMessage", () => 
"This is an example of a minimal API")
    .WithApiVersionSet(versionSet)
    .MapToApiVersion(1.0);

app.MapGet("/GetMessage", () =>
"This is an example of a minimal API 2")
    .WithApiVersionSet(versionSet)
    .MapToApiVersion(2.0);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.Run();
