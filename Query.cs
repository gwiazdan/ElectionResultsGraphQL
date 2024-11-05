using ElectionResultsGraphQL.Models;
using ElectionResultsGraphQL.Services;
using HotChocolate;

namespace ElectionResultsGraphQL;

public class Query
{
    public async Task<List<Municipality>> GetMunicipalities([Service] MunicipalityService service) =>
        await service.GetAllAsync();
    
    public async Task<List<County>> GetCounties([Service] CountyService service) =>
        await service.GetAllAsync();
}