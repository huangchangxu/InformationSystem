using InformationPlat.AhphOcelot.Cache;
using InformationPlat.AhphOcelot.Configuration;
using InformationPlat.AhphOcelot.DataBase.MySql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocelot.Cache;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.DependencyInjection;
using System;

namespace InformationPlat.AhphOcelot.Middleware
{
    /// <summary>
    /// 扩展Ocelot实现的自定义的注入
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加默认的注入方式，所有需要传入的参数都是用默认值
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IOcelotBuilder AddAhphOcelot(this IOcelotBuilder builder, Action<AhphOcelotConfiguration> option)
        {
            builder.Services.Configure(option);
            //配置信息
            builder.Services.AddSingleton(
                resolver => resolver.GetRequiredService<IOptions<AhphOcelotConfiguration>>().Value);
            //配置文件仓储注入
            builder.Services.AddSingleton<IFileConfigurationRepository, MySqlFileConfigurationRepository>();
            //注册后端服务
            builder.Services.AddHostedService<DbConfigurationPoller>();

            //使用Redis重写缓存
            builder.Services.AddSingleton<IOcelotCache<FileConfiguration>, InRedisCache<FileConfiguration>>();
            builder.Services.AddSingleton<IOcelotCache<CachedResponse>, InRedisCache<CachedResponse>>();
            builder.Services.AddSingleton<IInternalConfigurationRepository, RedisInternalConfigurationRepository>();
            return builder;
        }
    }
}
