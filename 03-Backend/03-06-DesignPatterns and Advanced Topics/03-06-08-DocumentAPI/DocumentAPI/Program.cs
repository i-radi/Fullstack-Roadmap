using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("Products", new OpenApiInfo
    {
        Version= "v1",
        Title="Products",
        Description="Products Web Api in Asp.net Core Version .net7",

    });
    c.SwaggerDoc("Categories", new OpenApiInfo
    {
        Version= "v1",
        Title="Categories",
        Description="Categories Web Api in Asp.net Core Version .net7",

    });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/Products/swagger.json", "Products");
        options.SwaggerEndpoint("/swagger/Categories/swagger.json", "Categories");
        options.RoutePrefix="swagger";
        options.DisplayRequestDuration();
        options.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
