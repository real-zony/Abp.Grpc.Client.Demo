using Abp.Grpc.Client.Demo.RpcServices;
using Abp.Grpc.Client.Utility;
using System;

namespace Abp.Grpc.Client.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bootstrapper = AbpBootstrapper.Create<AbpGrpcClientDemoModule>())
            {
                bootstrapper.Initialize();


                var connectionUtility = bootstrapper.IocManager.Resolve<IGRpcConnectionUtility>();
                var result = connectionUtility.GetRemoteService<ITestGrpcService>("TestGrpcService").Sum(10, 5).ResponseAsync.Result;
                Console.WriteLine("Result:" + result);

                Console.WriteLine("Press enter to stop application...");
                Console.ReadLine();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
