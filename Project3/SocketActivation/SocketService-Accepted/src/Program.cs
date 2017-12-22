using System;
using System.IO;
using System.Net.Sockets;
using Microsoft.Win32.SafeHandles;

namespace SocketService_Accepted
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(new SafeFileHandle((IntPtr)3, true), FileAccess.ReadWrite);
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine("This socket was already accepted");
            }
        }
    }
}
