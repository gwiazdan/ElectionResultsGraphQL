using ElectionResultsGraphQL.Models;
using MongoDB.Driver;

namespace ElectionResultsGraphQL.Services;

public class MunicipalityService(IMongoClient mongoClient)
{
    private readonly IMongoCollection<Municipality> _municipalities =
        mongoClient.GetDatabase("electionResults").GetCollection<Municipality>("municipalities");
    
    public async Task<List<Municipality>> GetAllAsync()
    {
        try
        {
            var municipalities =  await _municipalities.Find(_ => true).ToListAsync();
            
            return municipalities;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas odczytu danych: {ex.Message}");
            throw;
        }
    }
}