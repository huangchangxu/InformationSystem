using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using InformationPlat.Id4Server.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InformationPlat.Id4Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //配置身份服务器与内存中的存储，密钥，客户端和资源
            //配置身份服务器与内存中的存储，密钥，客户端和资源
            services.AddIdentityServer()
                   .AddDeveloperSigningCredential()
                   //.AddInMemoryApiResources(Config.GetApiResources())//添加api资源
                   //.AddInMemoryClients(Config.GetClients());//添加客户端
                   .AddDapperStore(option =>
                   {
                       option.DbConnectionStrings = "Server=47.104.196.141;Database=Information_ids;User ID=hcx;Password=CHANGxu910527;";
                   });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc();
            //添加到HTTP管道中。
            app.UseIdentityServer();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
