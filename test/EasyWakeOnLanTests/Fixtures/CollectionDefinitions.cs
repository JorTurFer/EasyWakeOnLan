using Xunit;

namespace EasyWakeOnLanTests.Fixtures
{
    [CollectionDefinition("UdpClientTest", DisableParallelization = true)]
    public class UdpCollection : ICollectionFixture<UdpListenerFixture>
    {

    }
}
