using FileData.Framework;
using FileData.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello...");

            IHost host = ServiceCollectionExtensions.CreateHostBuilder(args).Build();

            var executer = host.Services.GetService<IExecuter>();

            executer.Execute(args);

            Console.ReadKey();
        }
    }
}
