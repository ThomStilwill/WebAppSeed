using Foundation.Domain;

namespace Domain.Location
{
    public class Region : Enumeration<string>
    {
        public static Region USVI = new(nameof(Region.USVI), "US Virgin Islands");
        public static Region NE = new(nameof(Region.NE),"North East");
        public static Region WC = new(nameof(Region.WC),"West Coast");
        public static Region S = new(nameof(Region.S), "South");

        public Region() { }

        public Region(string key, string display): base(key, display) { }
        public Region(string display) : base(display, display) { }
    }
}
