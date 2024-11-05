using ElectionResultsGraphQL;
using ElectionResultsGraphQL.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration["DatabaseSettings:ConnectionString"];
if (string.IsNullOrWhiteSpace(mongoConnectionString))
{
    throw new ArgumentNullException(mongoConnectionString, "MongoDB connection string is not configured.");
}

var settings = MongoClientSettings.FromConnectionString(mongoConnectionString);

settings.ServerApi = new ServerApi(ServerApiVersion.V1);

var mongoClient = new MongoClient(settings);
builder.Services.AddSingleton<IMongoClient>(mongoClient);

builder.Services.AddSingleton<MunicipalityService>();
builder.Services.AddSingleton<CountyService>();

builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();
app.Run();