
using System.Threading.Tasks;

namespace EasyWakeOnLan
{
    /// <summary>
    /// EasyWakeOnLanCient interface
    /// </summary>
    public interface IEasyWakeOnLanCient
    {
        /// <summary>
        /// Wake a PC
        /// </summary>
        /// <param name="Mac">NIC Mac to wake</param>
        void Wake(string Mac);
        /// <summary>
        /// Wake a PC Async
        /// </summary>
        /// <param name="Mac">NIC Mac to wake</param>
        Task WakeAsync(string Mac);

    }
}
