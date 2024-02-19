using FluentAssertions;
using Foundation.Domain;

namespace Tests.Foundation.Domain
{
    internal class PosEnumTests
    {
        public class PosEnum : Enumeration<string>
        {
            public static PosEnum Left = new(nameof(Left));
            public static PosEnum Right = new(nameof(Right));
            public static PosEnum Middle = new(nameof(Middle));

            public PosEnum() { }
            public PosEnum(string value, string display) : base(value, display) { }
            public PosEnum(string display) : base(display, display) { }
        }

        [Test]
        public void TestEnumeration() { }

        [Test]
        public void GetAllWithPosEnumReturnsAllCountries()
        {
            //Arrange

            //Act
            var posEnums = Enumeration.GetAll<PosEnum>();
            foreach (var posEnum in posEnums)
            {
                Console.WriteLine(PosEnum.FromKey<PosEnum>(posEnum.Display));
            }

            //Assert
            posEnums.Count().Should().Be(3);
        }

        [Test]
        public void FromDisplayName_WithLeftPosEnum_ReturnsRightDisplay()
        {
            //Arrange
            var PosEnumValue = "Left";

            //Act
            var posEnum = PosEnum.FromKey<PosEnum>(PosEnumValue);

            //Assert
            posEnum.Key.Should().Be(PosEnumValue);
        }

        [Test]
        public void FromDisplayName_WithRightPosEnum_ReturnsRightDisplay()
        {
            //Arrange
            var PosEnumValue = "Right";

            //Act
            var PosEnum = Enumeration.FromDisplay<PosEnum>(PosEnumValue);

            //Assert
            PosEnum.Display.Should().Be(PosEnumValue);
        }

        // [Test]
        // public void FromKey_WithPosEnum_ReturnsPosEnum()
        // {
        //     //Arrange
        //     var PosEnumKey = PosEnum;
        //
        //     //Act
        //     var PosEnum = PosEnum.FromKey<PosEnum>(PosEnumKey);
        //
        //     //Assert
        //     PosEnum.Key.Should().Be(PosEnumKey);
        // }

    }
}
