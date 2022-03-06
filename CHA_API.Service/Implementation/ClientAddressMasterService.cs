using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CHA_API.Model;
using CHA_API.Model.ExceptionModel;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;
using CHA_API.Model.TableModel;
using CHA_API.Repository;
using CHA_API.Service.MapperProfile;

namespace CHA_API.Service
{
    public class ClientAddressMasterService : IClientAddressMasterService
    {
        private readonly IClientAddressMasterRepository _clientAddressMasterRepository;
        private readonly IMapper _mapper;

        public ClientAddressMasterService(IClientAddressMasterRepository clientAddressMasterRepository,
                                          IMapper mapper)
        {
            _clientAddressMasterRepository = clientAddressMasterRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<ClientAddressMasterResponse>>> GetClientAddress(long clientId)
        {
            try
            {
                ResponseModel<List<ClientAddressMasterResponse>> response = new ResponseModel<List<ClientAddressMasterResponse>>();
                response.Data = (await _clientAddressMasterRepository.GetClientAddress(clientId))?.ToList();
                response.IsSuccessful = response.Data != null && response.Data.Count > 0;
                if (response.IsSuccessful == false)
                    response.Error.ErrorMessage = "Data not found";
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientAddressMasterService", "GetClientAddress", new { clientId });
            }
        }

        public async Task<ResponseModel<object>> InsertClientAddress(List<ClientAddressMasterRequest> addresses)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                List<InsertClientAddressMaster> clientAddress = new List<InsertClientAddressMaster>();
                long addressId = await _clientAddressMasterRepository.InsertClientAddress(_mapper.MapCollection<List<ClientAddressMasterRequest>,
                                                                                                                 List<InsertClientAddressMaster>,
                                                                                                                 ClientAddressMasterMapper>(addresses, clientAddress));
                response.Data = addressId > 0;
                response.IsSuccessful = addressId > 0;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientAddressMasterService", "InsertClientAddress", addresses);
            }
        }

        public async Task<ResponseModel<object>> UpdateClientAddress(List<ClientAddressMasterRequest> addresses)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                List<UpdateClientAddressMaster> clientAddress = new List<UpdateClientAddressMaster>();
                response.Data = await _clientAddressMasterRepository.UpdateClientAddress(_mapper.MapCollection<List<ClientAddressMasterRequest>,
                                                                                                                 List<UpdateClientAddressMaster>,
                                                                                                                 ClientAddressMasterMapper>(addresses, clientAddress));
                response.IsSuccessful = (bool)response.Data;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientAddressMasterService", "InsertClientAddress", addresses);
            }
        }

        public async Task<ResponseModel<object>> DeleteClientAddress(long clientId, long addressId)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                response.Data = await _clientAddressMasterRepository.DeleteClientAddress(clientId, addressId);
                response.IsSuccessful = (bool)response.Data;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientAddressMasterService", "DeleteClientAddress", new { clientId, addressId });
            }
        }
    }
}
