using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Comunicate.SocketServer
{
    using System.Net;
    using System.Net.Sockets;
    using System.Web;
    class Program
    {
        static void Main(string[] args)
        {
            const int BufferSize = 256;

            Console.WriteLine(" Server is running ... ");
            IPAddress ip = new IPAddress(new byte[] { 172, 16, 14, 203 });
            TcpListener listener = new TcpListener(ip, 8500);
            listener.Start();
            // 开始 侦听 
            Console. WriteLine(" Start Listening ...");
            Console. WriteLine("\n\n 输入\" Q\" 键 退出。");


            TcpClient remoteClient = listener.AcceptTcpClient();
            Console.WriteLine("Client Connected!Local:{0} <-- Client:{1}", remoteClient.Client.LocalEndPoint, remoteClient.Client.RemoteEndPoint);

            NetworkStream streamToClient = remoteClient.GetStream();
            byte[] buffer = new byte[BufferSize];
            int bytesRead = streamToClient.Read(buffer, 0, BufferSize);


            Console.WriteLine(Encoding.Unicode.GetString(buffer));
            for (int i = 0; i < buffer.Length; i++)
            {

                    Console.Write(String.Format("{0:X000}"+"-", buffer[i]));

            }


            ConsoleKey key;
            do {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
                
        }

        private void MD5Test()
        {
            string SP_Id = "";
            string secrect = "";

            
        }
    }
}
