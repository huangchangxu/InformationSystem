﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationPlat.Id4Server.Interfaces
{
    /// <summary>
    /// 过期授权清理接口
    /// </summary>
    public interface IPersistedGrants
    {
        /// <summary>
        /// 移除指定时间的过期信息
        /// </summary>
        /// <param name="dt">过期时间</param>
        /// <returns></returns>
        Task RemoveExpireToken(DateTime dt);
    }
}
