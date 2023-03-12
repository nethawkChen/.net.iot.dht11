using System.Net;
using System.Net.Sockets;

namespace Lib {
    public class Utility {
        public static string? GetLocalIP() {
            string? result = null;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    result = ip.ToString();
                }
            }
            return result;
        }

        /// <summary>
        /// 取得 Host name
        /// </summary>
        /// <returns></returns>
        public static string? GetHostName() {
            return Environment.MachineName;
        }
    }
}