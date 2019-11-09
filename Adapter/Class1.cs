using System.Linq;
using Adapter.Clients;
using Adapter.FirstOrmLibrary;
using Adapter.Models;
using Adapter.SecondOrmLibrary;

namespace Adapter
{
    public class Adapter : IOrmAdapter
    {
        private readonly ISecondOrm secondOrm;

        public Adapter(ISecondOrm secondOrm)
        {
            this.secondOrm = secondOrm;
        }

        public void Add(DbUserInfoEntity entity)
        {
            Context.UserInfos.Add(entity);
        }

        public void Add(DbUserEntity entity)
        {
            Context.Users.Add(entity);
        }

        DbUserEntity IFirstOrm<DbUserEntity>.Read(int id)
        {
            return Context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Delete(DbUserEntity entity)
        {
            Context.Users.RemoveWhere(u => u.Id == entity.Id);
        }

        DbUserInfoEntity IFirstOrm<DbUserInfoEntity>.Read(int id)
        {
            return Context.UserInfos.FirstOrDefault(u => u.Id == id);
        }

        public void Delete(DbUserInfoEntity entity)
        {
            Context.UserInfos.RemoveWhere(u => u.Id == entity.Id);
        }

        public ISecondOrmContext Context => secondOrm.Context;
    }
}
