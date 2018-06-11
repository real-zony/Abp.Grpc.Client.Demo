using MagicOnion;

namespace Abp.Grpc.Client.Demo.RpcServices
{
    public interface ITestGrpcService : IService<ITestGrpcService>
    {
        UnaryResult<int> Sum(int x, int y);
    }
}