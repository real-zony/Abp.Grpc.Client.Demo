using Abp.Grpc.Common.Runtime.Session;
using MagicOnion;

namespace Abp.Grpc.Client.Demo.RpcServices
{
    public interface ITestGrpcService : IService<ITestGrpcService>
    {
        // 普通的 Grpc 接口定义
        UnaryResult<int> Sum(int x, int y);

        // 带有 GrpcSession 的接口定义
        UnaryResult<long?> TestGrpcSession(GrpcSession session);
    }
}