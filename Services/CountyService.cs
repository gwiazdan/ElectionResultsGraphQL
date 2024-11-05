using ElectionResultsGraphQL.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ElectionResultsGraphQL.Services;

public class CountyService(IMongoClient mongoClient)
{
    private readonly IMongoCollection<County> _counties =
        mongoClient.GetDatabase("electionResults").GetCollection<County>("counties");
    
    private readonly IMongoCollection<Municipality> _municipalities =
        mongoClient.GetDatabase("electionResults").GetCollection<Municipality>("municipalities");

    public async Task<List<County>> GetAllAsync()
    {
        try
        {
            var counties = await _counties.Find(_ => true).ToListAsync();
            
            var groupResults = await _municipalities.Aggregate()
                .Group(new BsonDocument
                {
                    { "_id", "$countyId" },
                    { "numberOfVotes", new BsonDocument("$sum", "$numberOfVotes") },
                    { "votesForKo", new BsonDocument("$sum", "$votesForKo") },
                    { "votesForTd", new BsonDocument("$sum", "$votesForTd") },
                    { "votesForLew", new BsonDocument("$sum", "$votesForLew") },
                    { "votesForPis", new BsonDocument("$sum", "$votesForPis") },
                    { "votesForKonf", new BsonDocument("$sum", "$votesForKonf") },
                    { "votesForBs", new BsonDocument("$sum", "$votesForBs") },
                    { "votesForMn", new BsonDocument("$sum", "$votesForMn") }
                })
                .ToListAsync();

            foreach (var grp in groupResults)
            {
                var countyId = grp["_id"].AsInt32;
                var county = counties.Find(c => c.Id == countyId);
                if (county == null) continue;
                county.NumberOfVotes = grp["numberOfVotes"].AsInt32;
                county.VotesForKo = grp["votesForKo"].AsInt32;
                county.VotesForTd = grp["votesForTd"].AsInt32;
                county.VotesForLew = grp["votesForLew"].AsInt32;
                county.VotesForPis = grp["votesForPis"].AsInt32;
                county.VotesForKonf = grp["votesForKonf"].AsInt32;
                county.VotesForBs = grp["votesForBs"].AsInt32;
                county.VotesForMn = grp["votesForMn"].AsInt32;
            }

            return counties;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas odczytu danych: {ex.Message}");
            throw;
        }
    }
}