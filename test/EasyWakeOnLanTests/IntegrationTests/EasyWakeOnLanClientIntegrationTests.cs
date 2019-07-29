using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyWakeOnLan;
using EasyWakeOnLanTests.Fixtures;
using FluentAssertions;
using Xunit;

namespace EasyWakeOnLanTests.IntegrationTests
{
    [Collection("UdpClientTest")]
    public class EasyWakeOnLanClientIntegrationTests
    {
        private UdpListenerFixture _udpListenerFixture;
        private readonly EasyWakeOnLanClient _easyWakeOnLanClient;

        public EasyWakeOnLanClientIntegrationTests(UdpListenerFixture udpListenerFixture)
        {
            _udpListenerFixture = udpListenerFixture;
            _udpListenerFixture.ClearRecivedMessage();
            _easyWakeOnLanClient = new EasyWakeOnLanClient();
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
        public void Wake_ShouldBeExpectedResult(string mac, string expected)
        {
            _easyWakeOnLanClient.Wake(mac);
            Thread.Sleep(500);
            AssertSendedUdpMessage(expected);
        }


        [Theory]
        [MemberData(nameof(MacData))]
        public async Task WakeAsync_ShouldBeExpectedResult(string mac, string expected)
        {
            await _easyWakeOnLanClient.WakeAsync(mac);
            await Task.Delay(500);
            AssertSendedUdpMessage(expected);
        }

        private void AssertSendedUdpMessage(string expected)
        {
            var result = _udpListenerFixture.GetRecivedMessage();
            result.Should().Be(expected);
        }
    }
}
