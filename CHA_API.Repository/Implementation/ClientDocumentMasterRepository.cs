using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using CHA_API.Model.ExceptionModel;
using CHA_API.Model.ResponseModel;
using CHA_API.Model.TableModel;

namespace CHA_API.Repository
{
    public class ClientDocumentMasterRepository : IClientDocumentMasterRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientDocumentMasterRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClientDocumentMasterResponse>> GetClientDocument(long clientId)
        {
            try
            {
                string getQuery = @"SELECT DocumentID, ClientId, DocumentName, DocumentType FROM dbo.ClientDocumentMaster
                                    WHERE ClientId = " + clientId;
                return await _unitOfWork.dbConnection.QueryAsync<ClientDocumentMasterResponse>(getQuery);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientDocumentMasterRepository", "GetClientDocument", clientId);
            }
        }

        public async Task<int> InserClientDocument(List<InsertClientDocumentMaster> documents)
        {
            try
            {
                return await _unitOfWork.dbConnection.InsertAsync(documents, _unitOfWork.dbTransaction);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientDocumentMasterRepository", "InserClientDocument", documents);
            }
        }

        public async Task<bool> UpdateClientDocument(List<UpdateClientDocumentMaster> documents)
        {
            try
            {
                return await _unitOfWork.dbConnection.UpdateAsync(documents, _unitOfWork.dbTransaction);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientDocumentMasterRepository", "UpdateClientDocument", documents);
            }
        }

        public async Task<bool> DeleteClientDocument(long clientId, long documentId = 0)
        {
            try
            {
                string getQuery = "SELECT * FROM dbo.ClientDocumentMaster WHERE ClientId = " + clientId;
                if (documentId > 0)
                    getQuery += " AND DocumentID = " + documentId;
                UpdateClientDocumentMaster document = await _unitOfWork.dbConnection.QuerySingleAsync(getQuery, _unitOfWork.dbTransaction);
                return await _unitOfWork.dbConnection.DeleteAsync(document, _unitOfWork.dbTransaction);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientDocumentMasterRepository", "DeleteClientDocument", new { clientId, documentId });
            }
        }
    }
}
