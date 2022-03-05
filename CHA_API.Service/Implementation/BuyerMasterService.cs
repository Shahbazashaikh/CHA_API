using System;
using CHA_API.Repository;
using CHA_API.Model.ExceptionModel;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;
using CHA_API.Model.TableModel;
using CHA_API.Model;
namespace CHA_API.Service
{
    public class BuyerMasterService : IBuyerMasterServices
    {

        private readonly IBuyerRepository _buyerRepository;
        private readonly IMapper _mapper;

        public BuyerMasterService(IBuyerRepository buyerRepository,
                                      IMapper mapper)
        {
            _buyerRepository = buyerRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<BuyerMasterResponse>>> GetBuyerMaster(string buyerName)
        {
            try
            {
                ResponseModel<List<BuyerMasterResponse>> response = new ResponseModel<List<BuyerMasterResponse>>();
                response.Data = (await _buyerRepository.GetBuyerMaster(buyerName))?.ToList();
                response.IsSuccessful = response.Data != null && response.Data.Count > 0;
                if (response.IsSuccessful == false)
                    response.Error.ErrorMessage = "Data not found";
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "GetBuyerMaster", "GetBuyerMaster", buyerName);
            }
        }

        public async Task<ResponseModel<object>> InsertBuyerMaster(BuyerMasterRequest buyerMaster)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                int id = await _buyerRepository.InsertBuyerMaster(_mapper.Map<InsertBuyerMaster>(buyerMaster));
                response.Data = id > 0;
                response.IsSuccessful = id > 0;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "BuyerMasterService", "InsertBuyerMaster", buyerMaster);
            }
        }


    }
}
