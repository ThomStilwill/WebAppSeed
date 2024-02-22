using Domain.Location;
using FluentAssertions;

namespace Tests.Foundation.Domain
{
    internal class LocationTests
    {
        [Test]
        public void GetAll_WithNoArgs_ReturnsAllStates()
        {
            //Arrange

            //Act
            var states = State.GetAll();
            foreach (var state in states)
            {
                Console.WriteLine(State.FromKey(state.Key));
            }

            //Assert
            states.Count().Should().Be(5);
        }

        [Test]
        public void FromKey_WithCA_ReturnsCAEnumeration()
        {
            var stateAbbreviation = "CA";
            var state = State.FromKey(stateAbbreviation);
            state.Should().Be(State.CA);
        }

        [Test]
        public void FromDisplay_WithCA_ReturnsCAEnumeration()
        {
            var stateName = "California";
            var state = State.FromDisplay(stateName);
            state.Should().Be(State.CA);
        }
    }
}
