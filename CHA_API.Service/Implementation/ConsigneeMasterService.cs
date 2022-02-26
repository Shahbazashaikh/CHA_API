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

        public async Task<List<ConsigneeMasterResponse>> GetConsigneeMaster(GetConsigneeMasterRequest getConsigneeMasterRequest)
        {
            try
            {
                List<ConsigneeMasterResponse> response = new List<ConsigneeMasterResponse>();
                response = (await _consigneeRepository.GetConsigneeMaster(getConsigneeMasterRequest))?.ToList();
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeMasterService", "GetConsigneeMaster", getConsigneeMasterRequest);
            }
        }

        public async Task<string> InsertConsigneeMaster(ConsigneeMasterRequest consigneeMaster)
        {
            try
            {
                string response = string.Empty;
                int id = await _consigneeRepository.InsertConsigneeMaster(_mapper.Map<InsertConsigneeMaster>(consigneeMaster));
                response = id > 0 ? "Successfully Saved" : "There is some error while saving data";
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ConsigneeMasterService", "InsertConsigneeMaster", consigneeMaster);
            }
        }
    }
}
