using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CHA_API.Model.ExceptionModel;
using Dapper;
using Dapper.Contrib.Extensions;
using CHA_API.Model.ResponseModel;
using CHA_API.Model.RequestModel;
using CHA_API.Model.TableModel;

namespace CHA_API.Repository
{
    public class ConsigneeRepository : IConsigneeRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsigneeRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ConsigneeMasterResponse>> GetConsigneeMaster(GetConsigneeMasterRequest getConsigneeMasterRequest)
        {
            try
            {
                string getConsigneeMasterQuery = @"SELECT ID, Name, BranchNo, Address1, Address2, City, State, Country, CountryCode, ZipCode, Remarks
                                                FROM dbo.ConsigneeMaster";
                if (getConsigneeMasterRequest != null && (!string.IsNullOrEmpty(getConsigneeMasterRequest.CompanyName)
                    || !string.IsNullOrEmpty(getConsigneeMasterRequest.CountryCode)))
                {
                    getConsigneeMasterQuery += " WHERE ";
                    if (!string.IsNullOrEmpty(getConsigneeMasterRequest.CompanyName))
                    {
                        getConsigneeMasterQuery += "Name = " + "'" + getConsigneeMasterRequest.CompanyName + "'";
                        getConsigneeMasterQuery += !string.IsNullOrEmpty(getConsigneeMasterRequest.CountryCode) ? " AND " : "";
                    }
                    if (!string.IsNullOrEmpty(getConsigneeMasterRequest.CountryCode))
                        getConsigneeMasterQuery += "Country = " + "'" + getConsigneeMasterRequest.CountryCode + "'";
                }

                return await _unitOfWork.dbConnection.QueryAsync<ConsigneeMasterResponse>(getConsigneeMasterQuery);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeRepository", "GetConsigneeMaster", getConsigneeMasterRequest);
            }
        }

        public async Task<int> InsertConsigneeMaster(InsertConsigneeMaster consigneeMaster)
        {
            try
            {
                return await _unitOfWork.dbConnection.InsertAsync(consigneeMaster);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeRepository", "InsertConsigneeMaster", consigneeMaster);
            }
        }

        public async Task<bool> UpdateConsigneeMaster(UpdateConsigneeMaster consigneeMaster)
        {
            try
            {
                return await _unitOfWork.dbConnection.UpdateAsync(consigneeMaster);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeRepository", "UpdateConsigneeMaster", consigneeMaster);
            }
        }

        public async Task<bool> DeleteConsigneeMaster(int id)
        {
            try
            {
                string query = "SELECT * FROM dbo.ConsigneeMaster WHERE ID = " + id.ToString();
                UpdateConsigneeMaster entity = await _unitOfWork.dbConnection.QuerySingleAsync<UpdateConsigneeMaster>(query);
                return await _unitOfWork.dbConnection.DeleteAsync<UpdateConsigneeMaster>(entity);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeRepository", "DeleteConsigneeMaster", id);
            }
        }
    }
}
