using EasyWakeOnLan;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using EasyWakeOnLanTests.Extensions;
using Xunit;

namespace EasyWakeOnLanTests.UnitaryTests
{
    public class EasyWakeOnLanClientUnitaryTests
    {
        private readonly Func<string, byte[]> _getBytesFunc;

        public EasyWakeOnLanClientUnitaryTests()
        {
            _getBytesFunc = GetGetBytesFunction();
        }
        
        public static IEnumerable<object[]> MacData =>
             new List<object[]>
             {
                 new object[] { "00-14-22-01-23-45", "ffffffffffff0014220123450014220123450014220123450014220123450014220123450014220123450014220123450014220123450014220123450014220123450014220123450014220123450014220123450014220123450014220123450014220123450000000000000000000000000000000000000000000000000000"},
                 new object[] { "00:30:BD:00:04:DC", "ffffffffffff0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0030bd0004dc0000000000000000000000000000000000000000000000000000"},
                 new object[] { "0004DC004096", "ffffffffffff0004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960004dc0040960000000000000000000000000000000000000000000000000000"},
             };

        [Theory]
        [MemberData(nameof(MacData))]
        public void ShouldBeCorrectBytes(string mac, string expected)
        {
            var bytes = _getBytesFunc(mac);
            var result = bytes.GetStringFromByteArray();
            result.Should().Be(expected);
        }

        [Fact]
        public void ShouldRaiseArgumentNullException_IfMacIsNull()
        {
            Action action = () =>
            {
                _getBytesFunc(null);
            };
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldRaiseFormatException_IfMacIsNotValid()
        {
            Action action = () =>
            {
                _getBytesFunc("NotValidMac");
            };
            action.Should().Throw<FormatException>();
        }

        private Func<string, byte[]> GetGetBytesFunction()
        {
            var method = typeof(EasyWakeOnLanClient).GetMethod("GetBytes", BindingFlags.Static | BindingFlags.NonPublic);
            return (Func<string, byte[]>)Delegate.CreateDelegate(typeof(Func<string, byte[]>), method);
        }
    }
}
