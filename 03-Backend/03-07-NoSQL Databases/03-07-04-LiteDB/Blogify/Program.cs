using Blogify.Configuration;
using Blogify.Models;
using Blogify.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<LiteDbOptions>(builder.Configuration.GetSection("LiteDbOptions"));
builder.Services.AddSingleton<ILiteDbContext, LiteDbContext>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
