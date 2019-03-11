using NameSorter.Implementation;
using NameSorter.Interfaces;
using NameSorter.Model;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {

            
            
            //dependency injection
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<IApplication,Application>()
                .AddTransient<IFileProcessorInterface, FileProcessor>()
                .AddTransient<ISortInterface<PersonModel>, PersonSortImplementation>()
                .BuildServiceProvider();


            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Error);

            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            //logger.LogDebug("Starting application");

            var app = serviceProvider.GetService<IApplication>();
            app.performSorting(args[0], @"./sorted-names-list.txt");
            serviceProvider.Dispose();

        }
    }
}
