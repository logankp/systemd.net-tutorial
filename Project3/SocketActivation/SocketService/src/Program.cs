using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Loader;
using Tmds.Systemd;

namespace SocketService
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyLoadContext.Default.Unloading += SigTermEventHandler;
            Console.CancelKeyPress += CancelHandler;

            Socket[] sockets = ServiceManager.GetListenSockets();
            Socket socket = sockets[0];

            Socket acceptSocket = socket.Accept();
            ServiceManager.Notify(ServiceState.Ready, ServiceState.Status("Socket accepted"));
            NetworkStream stream = new NetworkStream(acceptSocket);
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("This is a test");
            }


        }

        private static void CancelHandler(object sender, ConsoleCancelEventArgs e)
        {
            ServiceManager.Notify(ServiceState.Stopping, ServiceState.Status("SigTerm handled"));
        }

        private static void SigTermEventHandler(AssemblyLoadContext obj)
        {
            ServiceManager.Notify(ServiceState.Stopping, ServiceState.Status("CTRL+C captured"));
        }
    }
}
