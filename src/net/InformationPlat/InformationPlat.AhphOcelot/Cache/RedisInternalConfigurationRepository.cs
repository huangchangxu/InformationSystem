using CSRedis;
using InformationPlat.AhphOcelot.Configuration;
using InformationPlat.AhphOcelot.Extensions;
using Ocelot.Configuration;
using Ocelot.Configuration.Repository;
using Ocelot.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InformationPlat.AhphOcelot.Cache
{
    /// <summary>
    /// 使用redis存储内部配置信息
    /// </summary>
    public class RedisInternalConfigurationRepository : IInternalConfigurationRepository
    {
        private readonly AhphOcelotConfiguration _options;
        private IInternalConfiguration _internalConfiguration;
        public RedisInternalConfigurationRepository(AhphOcelotConfiguration options)
        {
            _options = options;
            CSRedisClient csredis;
            if (options.RedisConnectionStrings.Count == 1)
            {
                //普通模式
                csredis = new CSRedisClient(options.RedisConnectionStrings[0]);
            }
            else
            {
                //集群模式
                //实现思路：根据key.GetHashCode() % 节点总数量，确定连向的节点
                //也可以自定义规则(第一个参数设置)
                Func<string, string> nodeRule = null;
                csredis = new CSRedisClient(nodeRule, options.RedisConnectionStrings.ToArray());
            }
            //初始化 RedisHelper
            RedisHelper.Initialization(csredis);
        }

        /// <summary>
        /// 设置配置信息
        /// </summary>
        /// <param name="internalConfiguration">配置信息</param>
        /// <returns></returns>
        public Response AddOrReplace(IInternalConfiguration internalConfiguration)
        {
            var key = _options.RedisKeyPrefix + "-internalConfiguration";
            RedisHelper.Set(key, internalConfiguration.ToJson());
            _internalConfiguration = internalConfiguration;
            return new OkResponse();
        }

        /// <summary>
        /// 从缓存中获取配置信息
        /// </summary>
        /// <returns></returns>
        public Response<IInternalConfiguration> Get()
        {
            var key = _options.RedisKeyPrefix + "-internalConfiguration";
            var result = RedisHelper.Get<InternalConfiguration>(key);
            if (result != null)
            {
                return new OkResponse<IInternalConfiguration>(result);
            }

            if (_internalConfiguration != null)
            {
                RedisHelper.Set(key, _internalConfiguration.ToJson());
                return new OkResponse<IInternalConfiguration>(_internalConfiguration);
            }
            return new OkResponse<IInternalConfiguration>(default(InternalConfiguration));
        }
    }
}
