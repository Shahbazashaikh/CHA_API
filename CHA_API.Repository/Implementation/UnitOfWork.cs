using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using CHA_API.Model;

namespace CHA_API.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppSettings _appSettings;

        private bool _disposed = false;

        public IDbConnection dbConnection { get; set; }
        public IDbTransaction dbTransaction { get; set; }

        public UnitOfWork(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            InitializeDbConnection();
        }

        public void BeginTransaction()
        {
            if (dbConnection != null)
                dbTransaction = dbConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (dbTransaction != null)
                dbTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (dbTransaction != null)
                dbTransaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (_disposed == false && dispose == true)
            {
                if (dbTransaction != null)
                    dbTransaction.Dispose();
                if (dbConnection != null)
                    dbConnection.Dispose();
                _disposed = true;
            }
        }

        private void InitializeDbConnection()
        {
            dbConnection = new SqlConnection(_appSettings.DbConnectionString);
            dbConnection.Open();
        }
    }
}
