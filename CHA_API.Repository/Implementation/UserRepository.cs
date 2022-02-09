using CHA_API.Model.RequestModel;
using CHA_API.Model.TableModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHA_API.Model.ExceptionModel;
using Dapper;

namespace CHA_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserLoginMaster> AuthenticateUser(UserLoginRequest userLoginRequest)
        {
            try
            {
                string query = @"SELECT * FROM dbo.UserLoginMaster WHERE UserName = " + "'" + userLoginRequest.UserName + "'" + " AND Password = " + "'" + userLoginRequest.Password + "'";
                return await _unitOfWork.dbConnection.QueryFirstAsync<UserLoginMaster>(query);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "UserRepository", "AuthenticateUser", userLoginRequest);
            }
        }
    }
}
