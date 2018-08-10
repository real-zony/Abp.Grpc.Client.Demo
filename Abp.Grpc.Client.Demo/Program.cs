using Abp.Grpc.Client.Demo.RpcServices;
using Abp.Grpc.Client.Utility;
using Abp.Runtime.Session;
using System;

namespace Abp.Grpc.Client.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bootstrapper = AbpBootstrapper.Create<AbpGrpcClientDemoModule>())
            {
                // Abp 框架初始化
                bootstrapper.Initialize();
                // 解析 Grpc 链接管理器
                var connectionUtility = bootstrapper.IocManager.Resolve<IGrpcConnectionUtility>();
                // 从 Consul 处解析 ITestGrpcService 服务
                var service = connectionUtility.GetRemoteService<ITestGrpcService>("TestGrpcService");
                // 调用 ITestGrpcService 提供的服务并接收结果
                var result = service.Sum(10, 5).GetAwaiter().GetResult();

                // 带用户会话状态的接口测试
                // 这里是模拟被调用端的 AbpSession 内部的值，租户 ID 为 1000，用户 ID 为 2000
                using (bootstrapper.IocManager.Resolve<IAbpSession>().Use(1000, 2000))
                {
                    var userId = service.TestGrpcSession(bootstrapper.IocManager.Resolve<IAbpSession>() as AbpSessionBase).GetAwaiter().GetResult();
                    Console.WriteLine("TestGrpcSession 方法结果:" + userId);
                }

                Console.WriteLine("Sum 方法结果:" + result);
                Console.ReadLine();
            }
        }
    }
}