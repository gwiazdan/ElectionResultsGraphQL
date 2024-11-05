using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElectionResultsGraphQL.Models;

public class Municipality
{
    [BsonId]
    public required int Id { get; set; }
    
    [BsonElement("name")]
    public required string Name { get; set; }
    
    [BsonElement("numberOfVotes")]
    public required int NumberOfVotes { get; set; }
    
    [BsonElement("votesForKo")]
    public required int VotesForKo { get; set; }
    
    [BsonElement("votesForTd")]
    public required int VotesForTd { get; set; }
    
    [BsonElement("votesForLew")]
    public required int VotesForLew { get; set; }
    
    [BsonElement("votesForPis")]
    public required int VotesForPis { get; set; }
    
    [BsonElement("votesForKonf")]
    public required int VotesForKonf { get; set; }
    
    [BsonElement("votesForBs")]
    public required int VotesForBs { get; set; }
    
    [BsonElement("votesForMn")]
    public required int VotesForMn { get; set; }
    
    [BsonElement("countyId")]
    public required int CountyId { get; set; }
    
}