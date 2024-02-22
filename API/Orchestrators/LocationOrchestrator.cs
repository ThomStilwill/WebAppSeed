using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Location;

namespace API.Orchestrators
{
    public class LocationOrchestrator : ILocationOrchestrator
    {
        public async Task<IEnumerable<string>> GetStatesByRegion(string regionCode)
        {
            return await Task.Run(() =>
            {
                return State.GetByRegion(regionCode).Select(x=>x.Key);
            });
        }
    }
}
