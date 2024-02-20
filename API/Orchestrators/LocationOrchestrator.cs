using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Location;
using Foundation.Domain;
using Microsoft.IdentityModel.Tokens;

namespace API.Orchestrators
{
    public class LocationOrchestrator : ILocationOrchestrator
    {
        public async Task<IEnumerable<string>> GetStatesByRegion(string regionCode)
        {
            
            Region region = null;
            if (!regionCode.IsNullOrEmpty())
            {
                region = Region.FromKey<Region>(regionCode);
                if (region == null) throw new ApplicationException("Invalid Region code.");
            }

            return await Task.Run(() =>
            {
                var enumerable = Enumeration.GetAll<State>().Where(s=>s!.Region == region).Select(x=>x.Key);
                return enumerable;
            });
        }
    }
}
