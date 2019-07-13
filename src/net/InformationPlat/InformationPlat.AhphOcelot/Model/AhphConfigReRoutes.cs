using System.ComponentModel.DataAnnotations;

namespace InformationPlat.AhphOcelot.Model
{
    /// <summary>
    /// 路由配置
    /// 网关-路由,可以配置多个网关和多个路由
    /// </summary>
    public partial class AhphConfigReRoutes
    {
        /// <summary>
        /// 配置路由主键
        /// </summary>
        [Key]
        public int CtgRouteId { get; set; }
        /// <summary>
        /// 网关主键
        /// </summary>
        public int? AhphId { get; set; }
        /// <summary>
        /// 路由主键
        /// </summary>
        public int? ReRouteId { get; set; }
    }
}
