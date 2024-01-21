

using AutoMapper;
using Cassandra;
using Cassandra.Mapping;
using demo_cassandra.Commons;
using demo_cassandra.Domains.Entities;
using demo_cassandra.Domains.Services;
using demo_cassandra.Infrastructures.Databases;
using message_service.Infrastructures.Repository;
using message_service.Routers;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

builder.Services.AddHttpClient();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region database casandra

string? cassandraConnectionString = Environment.GetEnvironmentVariable("CASSANDRA_CONNECTION_STRINGS");
string? cassandraKeySpace = Environment.GetEnvironmentVariable("CASSANDRA_KEY_SPACE");

builder.Services.AddTransient(x =>
{
    Cluster cluster = Cluster.Builder()
                     .AddContactPoints(cassandraConnectionString)
                     .Build();
    Cassandra.ISession? session = cluster.Connect(cassandraKeySpace);
    session.UserDefinedTypes.Define(
           UdtMap.For<Temp>(),
           UdtMap.For<Temp2>()
       );
    return session;
});
MappingConfiguration.Global.Define<UserMapping>();
#endregion


# region mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
    mc.AllowNullCollections = true;
    mc.AllowNullDestinationValues = true;
});
AutoMapper.IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
# endregion


builder.Services.AddScoped<IUserService, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/", () => $"NumArr {DateTime.Now}");
app.UserMap();

app.Run();
