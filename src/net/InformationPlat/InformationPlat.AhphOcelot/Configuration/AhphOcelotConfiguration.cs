﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InformationPlat.AhphOcelot.Configuration
{
    /// <summary>
    /// 自定义配置信息
    /// </summary>
    public class AhphOcelotConfiguration
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DbConnectionStrings { get; set; }

        /// <summary>
        /// 是否启用定时器，默认不启动
        /// </summary>
        public bool EnableTimer { get; set; } = false;

        /// <summary>
        /// 定时器周期，单位（毫秒），默认30分总自动更新一次
        /// </summary>
        public int TimerDelay { get; set; } = 30 * 60 * 1000;

        /// <summary>
        /// Redis连接字符串
        /// </summary>
        public List<string> RedisConnectionStrings { get; set; }

        /// <summary>
        /// Redis存储的key前缀,默认值ahphocelot,如果分布式缓存多个应用部署，需要修改此值。
        /// </summary>
        public string RedisKeyPrefix { get; set; } = "ahphocelot";
    }
}
