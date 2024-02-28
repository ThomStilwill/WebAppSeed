using Foundation.Domain;

namespace Domain.Location
{
    public class Region : Enumeration<Region, Region.Keys,string>
    {
        public enum Keys
        {
            USVI,
            NE,
            WC,
            S
        }

        public static Region USVI = new(Keys.USVI, "US Virgin Islands");
        public static Region NE = new(Keys.NE,"North East");
        public static Region WC = new(Keys.WC,"West Coast");
        public static Region S = new(Keys.S, "South");

        public Region() { }

        public Region(Keys key) : base(key) { }
        public Region(Keys key, string value): base(key, value) { }
    }
}
