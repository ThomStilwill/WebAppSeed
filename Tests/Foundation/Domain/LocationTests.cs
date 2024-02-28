using Domain.Location;
using FluentAssertions;

namespace Tests.Foundation.Domain
{
    internal class LocationTests
    {
        [Test]
        public void GetAll_WithNoArgs_ReturnsAllStates()
        {
            var states = State.GetAll();
            foreach (var state in states)
            {
                Console.WriteLine(State.FromValue(state.Value));
            }
            states.Count().Should().Be(5);
        }

        [Test]
        public void FromKey_WithCA_ReturnsCAEnumeration()
        {
            var state = State.FromKey(State.Keys.CA);
            state.Should().Be(State.CA);
        }

        [Test]
        public void FromValue_WithCA_ReturnsCAEnumeration()
        {
            var stateAbbreviation = "CA";
            var state = State.FromValue(stateAbbreviation);
            state.Should().Be(State.CA);
        }

        [Test]
        public void FromDisplay_WithCA_ReturnsCAEnumeration()
        {
            var stateName = "California";
            var state = State.FromDisplay(stateName);
            state.Should().Be(State.CA);
        }

        [Test]
        public void StateTest()
        {
            var state = State.STX;
            switch (state.Key)
            {
                case State.Keys.STX:
                    Assert.True(true);
                    break;

            }

            Assert.False(false);
        }
    }
}
