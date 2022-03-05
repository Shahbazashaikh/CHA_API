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
    public class BuyerRepository : IBuyerRepository
    {

        private readonly IUnitOfWork _unitOfWork;

        public BuyerRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<BuyerMasterResponse>> GetBuyerMaster(string buyerName)
        {
            try
            {
                string getBuyerMasterQuery = @"SELECT BuyerId, Name, Address1, Address2, Address3, CountryName
                                               FROM dbo.BuyerMaster";
                if (!string.IsNullOrEmpty(buyerName) && buyerName != "All")
                    getBuyerMasterQuery += "WHERE Name = " + "'" + buyerName + "'";

                return await _unitOfWork.dbConnection.QueryAsync<BuyerMasterResponse>(getBuyerMasterQuery);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeRepository", "GetConsigneeMaster", buyerName);
            }
        }

        public async Task<int> InsertBuyerMaster(InsertBuyerMaster buyerMaster)
        {
            try
            {
                return await _unitOfWork.dbConnection.InsertAsync(buyerMaster);
            }
            catch (SqlException ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "InsertBuyerMaster", "InsertBuyerMaster", buyerMaster);
            }
        }



    }
}
