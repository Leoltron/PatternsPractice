using Adapter.FirstOrmLibrary;
using Adapter.Models;
using Adapter.SecondOrmLibrary;

namespace Adapter.Clients
{
    public interface IOrmAdapter : IFirstOrm<DbUserInfoEntity>, IFirstOrm<DbUserEntity>, ISecondOrm
    {
    }
}
