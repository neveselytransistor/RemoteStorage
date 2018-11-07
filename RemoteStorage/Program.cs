﻿using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RemoteStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                       .UseKestrel()
                       .UseContentRoot(Directory.GetCurrentDirectory())
                       .UseStartup<Startup>()
                       .Build();
            host.Run();
        }
    }
}