using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Weather;

namespace API.Orchestrators;

public interface ILocationOrchestrator
{
    Task<IEnumerable<string>> GetStatesByRegion(string region);
}