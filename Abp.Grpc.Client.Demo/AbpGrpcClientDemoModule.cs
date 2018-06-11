using Abp.Grpc.Client.Configuration;
using Abp.Grpc.Client.Extensions;
using Abp.Modules;

namespace Abp.Grpc.Client.Demo
{
    [DependsOn(typeof(AbpGrpcClientModule))]
    public class AbpGrpcClientDemoModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.UseGrpcClient(new ConsulRegistryConfiguration("10.0.75.1", 8500, null));
        }
    }
}