﻿
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;

namespace L1L2RedisCache.Test
{
    public class Program
    {
        static Program()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            Services = new ServiceCollection();

            Services.AddL1L2DistributedRedisCache(options =>
            {
                options.Configuration = "";
                options.InstanceName = "L1L2RedisCache.Test.";
            });
        }

        public static IConfigurationRoot Configuration { get; }
        public static IServiceCollection Services { get; }

        public async static Task<int> Main(string[] args)
        {
            var serviceProvider = Services.BuildServiceProvider();

            var distributedCache = serviceProvider
                .GetService<IDistributedCache>();

            return 1;
        }
    }
}