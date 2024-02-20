using Foundation.Domain;

namespace Domain.Location
{
    public class State : Enumeration<string>
    {
        public static State STX = new(nameof(State.STX), "St. Croix");
        public static State NJ = new(nameof(State.NJ),"New Jersey", Region.NE);
        public static State CA = new(nameof(State.CA),"California");
        public static State CT = new(nameof(State.CT),"Connecticut", Region.NE);
        public static State TX = new(nameof(State.TX), "Texas");

        public State() { }

        public State(string key, string display, Region region) : base(key, display)
        {
            Region = region;

        }
        public State(string key, string display) : base(key, display) { }
        public State(string display) : base(display, display) { }

        public Region Region { get; set; }


    }
}
