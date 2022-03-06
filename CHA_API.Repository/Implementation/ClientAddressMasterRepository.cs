using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using CHA_API.Model.ExceptionModel;
using CHA_API.Model.ResponseModel;
using CHA_API.Model.TableModel;

namespace CHA_API.Repository
{
    public class ClientAddressMasterRepository : IClientAddressMasterRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientAddressMasterRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClientAddressMasterResponse>> GetClientAddress(long clientId)
        {
            try
            {
                string getQuery = @"SELECT AddressID, ClientId, BranchNo, Address1, Address2, City, StateName, StateCode, District, PINCode
                                    FROM dbo.ClientAddressMaster
                                    WHERE ClientId = " + clientId;
                return await _unitOfWork.dbConnection.QueryAsync<ClientAddressMasterResponse>(getQuery);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientAddressMasterRepository", "GetClientAddress", clientId);
            }
        }

        public async Task<int> InsertClientAddress(List<InsertClientAddressMaster> addresses)
        {
            try
            {
                return await _unitOfWork.dbConnection.InsertAsync(addresses, _unitOfWork.dbTransaction);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientAddressMasterRepository", "InsertClientAddress", addresses);
            }
        }

        public async Task<bool> UpdateClientAddress(List<UpdateClientAddressMaster> addresses)
        {
            try
            {
                return await _unitOfWork.dbConnection.UpdateAsync(addresses, _unitOfWork.dbTransaction);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientAddressMasterRepository", "UpdateClientAddress", addresses);
            }
        }

        public async Task<bool> DeleteClientAddress(long clientId, long addressId = 0)
        {
            try
            {
                string getQuery = "SELECT * FROM dbo.ClientAddressMaster WHERE ClientId = " + clientId;
                if (addressId > 0)
                    getQuery += " AND AddressID = " + addressId;
                UpdateClientAddressMaster address = await _unitOfWork.dbConnection.QuerySingleAsync(getQuery, _unitOfWork.dbTransaction);
                return await _unitOfWork.dbConnection.DeleteAsync(address, _unitOfWork.dbTransaction);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientAddressMasterRepository", "DeleteClientAddress", new { clientId, addressId });
            }
        }
    }
}
