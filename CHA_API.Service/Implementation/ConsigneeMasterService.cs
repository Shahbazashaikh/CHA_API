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
    public class ConsigneeMasterService : IConsigneeMasterService
    {
        private readonly IConsigneeRepository _consigneeRepository;
        private readonly IMapper _mapper;

        public ConsigneeMasterService(IConsigneeRepository consigneeRepository,
                                      IMapper mapper)
        {
            _consigneeRepository = consigneeRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<ConsigneeMasterResponse>>> GetConsigneeMaster(GetConsigneeMasterRequest getConsigneeMasterRequest)
        {
            try
            {
                ResponseModel<List<ConsigneeMasterResponse>> response = new ResponseModel<List<ConsigneeMasterResponse>>();
                response.Data = (await _consigneeRepository.GetConsigneeMaster(getConsigneeMasterRequest))?.ToList();
                response.IsSuccessful = response.Data != null && response.Data.Count > 0;
                if (response.IsSuccessful == false)
                    response.Error.ErrorMessage = "Data not found";
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeMasterService", "GetConsigneeMaster", getConsigneeMasterRequest);
            }
        }

        public async Task<ResponseModel<string>> InsertConsigneeMaster(ConsigneeMasterRequest consigneeMaster)
        {
            try
            {
                ResponseModel<string> response = new ResponseModel<string>();
                int id = await _consigneeRepository.InsertConsigneeMaster(_mapper.Map<InsertConsigneeMaster>(consigneeMaster));
                response.Data = id > 0 ? "Successfully Saved" : "There is some error while saving data";
                response.IsSuccessful = id > 0;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeMasterService", "InsertConsigneeMaster", consigneeMaster);
            }
        }

        public async Task<ResponseModel<object>> UpdateConsigneeMaster(ConsigneeMasterRequest consigneeMaster)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                response.Data = await _consigneeRepository.UpdateConsigneeMaster(_mapper.Map<UpdateConsigneeMaster>(consigneeMaster));
                response.IsSuccessful = (bool)response.Data;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeMasterService", "UpdateConsigneeMaster", consigneeMaster);
            }
        }

        public async Task<ResponseModel<object>> DeleteConsigneeMaster(int id)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                response.Data = await _consigneeRepository.DeleteConsigneeMaster(id);
                response.IsSuccessful = (bool)response.Data;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeMasterService", "DeleteConsigneeMaster", id);
            }
        }
    }
}
