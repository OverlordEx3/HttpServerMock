using System;

namespace HttpServerMock
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpOKServer server = new HttpOKServer(555);

            Console.WriteLine("Listening on port {0}", server.Port);
            Console.WriteLine("Press <ESC> to quit...");
            server.Start();
            while(Console.ReadKey().Key != ConsoleKey.Escape){}
            server.Stop();
            Console.WriteLine("Server stopped");
        }
    }
}
