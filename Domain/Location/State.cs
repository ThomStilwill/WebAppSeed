using Foundation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Location
{
    public class State : Enumeration<State,State.Keys,string>
    {
        public enum Keys
        {
            STX,
            NJ,
            CA,
            CT,
            TX
        }

        public static State STX = new(Keys.STX,nameof(Keys.STX), "St. Croix");
        public static State NJ = new(Keys.NJ, nameof(Keys.NJ), "New Jersey", Region.NE);
        public static State CA = new(Keys.CA, nameof(Keys.CA), "California");
        public static State CT = new(Keys.CT, nameof(Keys.CT), "Connecticut", Region.NE);
        public static State TX = new(Keys.TX, nameof(Keys.TX), "Texas");

        public State() { }
        public State(Keys key) : base(key) { }
        public State(Keys key,string value, string display) : base(key, value, display) { }
        public State(Keys key, string value, string display, Region region) : base(key, value, display)
        {
            Region = region;
        }

        public Region Region { get; set; }

        public static IEnumerable<State> GetByRegion(string regionCode = null)
        {
            Region region = null;
            if (!string.IsNullOrEmpty(regionCode))
            {
                region = Region.FromValue(regionCode);
                if (region == null) throw new ApplicationException("Invalid Region code.");
            }

            return GetAll().Where(s => s!.Region == region);
        }
    }
}
