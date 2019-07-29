using System.Text;

namespace EasyWakeOnLanTests.Extensions
{
    internal static class ByteExternsions
    {
        internal static string GetStringFromByteArray(this byte[] bytes)
        {
            var builder = new StringBuilder();
            foreach (var currentByte in bytes)
            {
                builder.Append(currentByte.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
