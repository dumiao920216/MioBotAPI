using System.Net;
using System.Net.Sockets;
using System.Text;
using MioBotAPI.Helper;

namespace MioBotAPI.Socket
{
    public class Client
    {
        static readonly TcpClient client = new();
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
            client.SendTimeout = 1000;
            client.Connect(address);
        }
        public static void Send(string msg)
        {
            NetworkStream stream = client.GetStream();
            byte[] send = Encoding.Default.GetBytes(msg);
            byte[] read = new Byte[client.Available]; ;
            try
            {
                stream.Write(send, 0, send.Length);
            }
            catch (Exception ex)
            {
                LogHelper.logger.Error(ex);
            }
            //stream.Read(read, 0, read.Length);
            //return Encoding.Default.GetString(read);
        }
    }
}
