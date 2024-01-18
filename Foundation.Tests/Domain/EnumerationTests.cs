using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Foundation.Tests.Domain
{
    
    public class EnumerationTests
    {
        [Test]
        public void GetAllWithPosEnumReturnsAllCountries()
        {
            //Arrange

            //Act
            var posEnums = Enumeration.GetAll<PosEnum>();
            foreach (var posEnum in posEnums)
            {   
                Console.WriteLine(PosEnum.ToString());
            }

            //Assert
            posEnums.Count().Should().Be(4);
        }

        [Test]
        public void FromValue_WithPosEnum_ReturnsPosEnum()
        {
            //Arrange
            var PosEnumValue = "US";

            //Act
            var PosEnum = Enumeration.FromValue<PosEnum>(PosEnumValue);

            //Assert
            PosEnum.Value.Should().Be(PosEnumValue);
        }

        [Test]
        public void FromDisplayName_WithPosEnum_ReturnsPosEnum()
        {
            //Arrange
            var PosEnumValue = "United States";

            //Act
            var PosEnum = Enumeration.FromDisplay<PosEnum>(PosEnumValue);

            //Assert
            PosEnum.Display.Should().Be(PosEnumValue);
        }

        [Test]
        public void FromKey_WithPosEnum_ReturnsPosEnum()
        {
            //Arrange
            var PosEnumKey = PosEnum.Keys.UnitedStates;

            //Act
            var PosEnum = PosEnum.FromKey<PosEnum>(PosEnumKey);

            //Assert
            PosEnum.Key.Should().Be(PosEnumKey);
        }

        [Test]
        public void FromKey_WithPosEnumUK_ReturnsDisplay()
        {
            //Arrange
            var PosEnumKey = PosEnum.Keys.UnitedKingdom;
            var PosEnumName = "Great Britain";

            //Act
            var PosEnum = PosEnum.FromKey<PosEnum>(PosEnumKey);

            //Assert
            PosEnum.Display.Should().Be(PosEnumName);
        }
    }



    public class PosEnum : Enumeration<string>
    {
        public static PosEnum Left = new(nameof(Left));
        public static PosEnum Right = new(nameof(Right));
        public static PosEnum Middle = new(nameof(Middle));

        public PosEnum() { }
        public PosEnum(string value, string display) : base(value, display) { }
        public PosEnum(string display) : base(display, display) { }
    }
}
