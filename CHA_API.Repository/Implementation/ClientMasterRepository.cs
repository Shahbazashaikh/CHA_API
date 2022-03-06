using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using CHA_API.Model.ExceptionModel;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;
using CHA_API.Model.TableModel;

namespace CHA_API.Repository
{
    public class ClientMasterRepository : IClientMasterRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientMasterRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClientMasterResponse>> GetClients(GetClientRequest clientRequest)
        {
            try
            {
                string getQuery = "SELECT CM.ClientId, CM.Name, CM.IECNo, CM.Type FROM dbo.ClientMaster AS CM";
                if (clientRequest != null)
                {
                    if (!string.IsNullOrEmpty(clientRequest.State))
                        getQuery += "\n" + "INNER JOIN dbo.ClientAddressMaster AS CAM ON CM.ClientId = CAM.ClientId" + "\n" + "WHERE CAM.StateName = " + "'" + clientRequest.State + "'";
                    else
                        getQuery += "\n" + "WHERE";
                    if (!string.IsNullOrEmpty(clientRequest.Name))
                        getQuery += string.IsNullOrEmpty(clientRequest.State) == false ? " AND " : "" + "CM.Name = " + "'" + clientRequest.Name + "'";
                    if (!string.IsNullOrEmpty(clientRequest.IECNo))
                        getQuery += (string.IsNullOrEmpty(clientRequest.State) || string.IsNullOrEmpty(clientRequest.Name)) == false ? " AND " : "" + "CM.IECNo = " + "'" + clientRequest.IECNo + "'";
                }
                return await _unitOfWork.dbConnection.QueryAsync<ClientMasterResponse>(getQuery);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientMasterRepository", "GetClients", clientRequest);
            }
        }

        public async Task<int> InsertClient(InsertClientMaster client)
        {
            try
            {
                return await _unitOfWork.dbConnection.InsertAsync(client, _unitOfWork.dbTransaction);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientMasterRepository", "InsertClient", client);
            }
        }

        public async Task<bool> UpdateClient(UpdateClientMaster client)
        {
            try
            {
                return await _unitOfWork.dbConnection.UpdateAsync(client, _unitOfWork.dbTransaction);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientMasterRepository", "UpdateClient", client);
            }
        }

        public async Task<bool> DeleteClient(long clientId)
        {
            try
            {
                string getQuery = "SELECT * FROM dbo.ClientMaster WHERE ClientId = " + clientId;
                UpdateClientMaster client = await _unitOfWork.dbConnection.QuerySingleAsync(getQuery, _unitOfWork.dbTransaction);
                return await _unitOfWork.dbConnection.DeleteAsync(client, _unitOfWork.dbTransaction);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientMasterRepository", "DeleteClient", new { clientId });
            }
        }
    }
}
