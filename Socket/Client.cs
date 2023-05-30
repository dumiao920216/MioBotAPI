using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MioBotAPI.Socket
{
    public class Client
    {
        static TcpClient client = new();
        public static void Connect()
        {
            var config = new ConfigurationBuilder()
                             .SetBasePath(Environment.CurrentDirectory)
                             .AddJsonFile("appsettings.json")
                             .AddInMemoryCollection()
                             .Build();
            var ip = IPAddress.Parse(config["Address:Ip"]);
            var port = Convert.ToInt32(config["Address:Port"]);
            IPEndPoint address = new(ip, port);
            client.Connect(address);
        }
        public static void Send(string msg)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.Default.GetBytes(msg);
            stream.Write(data, 0, data.Length);
        }
    }
}
