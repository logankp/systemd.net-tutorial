using System;
using System.IO;

namespace SocketService_Inet
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = Console.OpenStandardOutput();
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("This socket was passed on stdin/stdout");
            }
        }
    }
}
