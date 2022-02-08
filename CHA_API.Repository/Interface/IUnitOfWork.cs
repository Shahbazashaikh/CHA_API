using System.Data;

namespace CHA_API.Repository
{
    public interface IUnitOfWork
    {
        public IDbConnection dbConnection { get; set; }

        public IDbTransaction dbTransaction { get; set; }

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        void Dispose();
    }
}
