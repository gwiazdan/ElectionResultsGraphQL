using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElectionResultsGraphQL.Models;

public class County
{
    [BsonId]
    public required int Id { get; set; }
    
    [BsonElement("name")]
    public required string Name { get; set; }
    
    [BsonElement("voivodeshipId")]
    public required int VoivodeshipId { get; set; }
    
    [BsonElement("senateConstituencyId")]
    public int? SenateConstituencyId { get; set; }
    
    [BsonElement("sejmConstituencyId")]
    public required int SejmConstituencyId { get; set; }
    
    [BsonElement("sejmikConstituencyId")]
    public int? SejmikConstituencyId { get; set; }
    
    [BsonElement("europeanParliamentConstituencyId")]
    public required int EuropeanParliamentConstituencyId { get; set; }
    
    
    [BsonIgnore]
    public required int NumberOfVotes { get; set; }
    
    [BsonIgnore]
    public required int VotesForKo { get; set; }
    
    [BsonIgnore]
    public required int VotesForTd { get; set; }
    
    [BsonIgnore]
    public required int VotesForLew { get; set; }
    
    [BsonIgnore]
    public required int VotesForPis { get; set; }
    
    [BsonIgnore]
    public required int VotesForKonf { get; set; }
    
    [BsonIgnore]
    public required int VotesForBs { get; set; }
    
    [BsonIgnore]
    public required int VotesForMn { get; set; }
    
}