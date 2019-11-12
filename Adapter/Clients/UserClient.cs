using System.Linq;
using Adapter.FirstOrmLibrary;
using Adapter.Models;
using Adapter.SecondOrmLibrary;

namespace Adapter.Clients
{
    public class UserClient
    {
        private readonly IOrmAdapter ormAdapter;

        private readonly IFirstOrm<DbUserEntity> firstOrm1;
        private readonly IFirstOrm<DbUserInfoEntity> firstOrm2;

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            var user = firstOrm1.Read(userId);
            var userInfo = firstOrm2.Read(user.InfoId);
            return (user, userInfo);
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            ormAdapter.Add(user);
            ormAdapter.Add(userInfo);
        }

        public void Remove(int userId)
        {
            var user = firstOrm1.Read(userId);
            var userInfo = firstOrm2.Read(user.InfoId);

            firstOrm2.Delete(userInfo);
            firstOrm1.Delete(user);
        }

        public UserClient(IOrmAdapter ormAdapter)
        {
            this.ormAdapter = ormAdapter;
            firstOrm1 = ormAdapter;
            firstOrm2 = ormAdapter;
        }
    }
}
