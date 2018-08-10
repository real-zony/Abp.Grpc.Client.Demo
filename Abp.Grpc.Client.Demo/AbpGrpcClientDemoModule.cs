using Abp.Grpc.Client.Extensions;
using Abp.Grpc.Common.Configuration;
using Abp.Modules;

namespace Abp.Grpc.Client.Demo
{
    [DependsOn(typeof(AbpGrpcClientModule))]
    public class AbpGrpcClientDemoModule : AbpModule
    {
        public override void PreInitialize()
        {
            // 配置 Consul 服务地址
            Configuration.Modules.UseGrpcClient(new ConsulRegistryConfiguration("10.0.75.1", 8500, null));
        }
    }
}