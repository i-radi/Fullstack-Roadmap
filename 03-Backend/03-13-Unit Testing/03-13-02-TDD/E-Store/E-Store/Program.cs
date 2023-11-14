using E_Store.Configurations;
using E_Store.Services.Implementations;
using E_Store.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.Configure<ApiServiceConfig>(builder.Configuration.GetSection("ApiServiceConfig"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
