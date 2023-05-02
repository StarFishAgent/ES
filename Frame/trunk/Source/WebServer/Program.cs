using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>//自定义端口号
                {
                    webBuilder.UseUrls("http://*:18801"); //设置端口号
                    //测试地址：http://localhost:18801/swagger/index.html
                    webBuilder.ConfigureKestrel((context, options) =>
                    {
                        //options.ListenAnyIP(18800); //设置端口号
                        options.Limits.MaxRequestBodySize = int.MaxValue;//更改上传大小限制
                        options.Limits.MaxRequestBufferSize = int.MaxValue;
                        options.Limits.MaxRequestLineSize = int.MaxValue;
                        options.Limits.MaxResponseBufferSize = int.MaxValue;
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
