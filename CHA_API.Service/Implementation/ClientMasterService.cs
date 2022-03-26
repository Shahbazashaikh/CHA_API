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
    public class ClientMasterService : IClientMasterService
    {
        private readonly IClientMasterRepository _clientMasterRepository;
        private readonly IClientAddressMasterRepository _clientAddressMasterRepository;
        private readonly IClientDocumentMasterRepository _clientDocumentMasterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientMasterService(IClientMasterRepository clientMasterRepository,
                                   IClientAddressMasterRepository clientAddressMasterRepository,
                                   IClientDocumentMasterRepository clientDocumentMasterRepository,
                                   IUnitOfWork unitOfWork,
                                   IMapper mapper)
        {
            _clientMasterRepository = clientMasterRepository;
            _clientAddressMasterRepository = clientAddressMasterRepository;
            _clientDocumentMasterRepository = clientDocumentMasterRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<ClientMasterResponse>>> GetClients(GetClientRequest clientRequest)
        {
            try
            {
                ResponseModel<List<ClientMasterResponse>> response = new ResponseModel<List<ClientMasterResponse>>();
                response.Data = (await _clientMasterRepository.GetClients(clientRequest))?.ToList();
                response.IsSuccessful = response.Data != null && response.Data.Count > 0;
                if (response.IsSuccessful == false)
                    response.Error.ErrorMessage = "Data not found";
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientMasterService", "GetClient", clientRequest);
            }
        }

        public async Task<ResponseModel<object>> InsertClient(ClientMasterRequest client)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                ResponseModel<object> response = new ResponseModel<object>();
                long clientId = await _clientMasterRepository.InsertClient(_mapper.Map<InsertClientMaster>(client));
                if (clientId > 0)
                {
                    if (client.Addresses != null && client.Addresses.Count > 0)
                    {
                        client.Addresses.ForEach((address) =>
                        {
                            address.ClientId = clientId;
                        });
                    }
                    List<InsertClientAddressMaster> addresses = new List<InsertClientAddressMaster>();
                    long addressId = await _clientAddressMasterRepository.InsertClientAddress(_mapper.MapCollection<List<ClientAddressMasterRequest>,
                                                                                                                 List<InsertClientAddressMaster>,
                                                                                                                 ClientAddressMasterMapper>(client.Addresses, addresses));
                }
                _unitOfWork.CommitTransaction();
                response.Data = clientId > 0;
                response.IsSuccessful = clientId > 0;
                return response;
            }
            catch (UnhandledException)
            {
                _unitOfWork.RollbackTransaction();
                _unitOfWork.Dispose();
                throw;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                _unitOfWork.Dispose();
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientMasterService", "InsertClient", client);
            }
        }

        public async Task<ResponseModel<object>> UpdateClient(ClientMasterRequest client)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                ResponseModel<object> response = new ResponseModel<object>();
                response.Data = await _clientMasterRepository.UpdateClient(_mapper.Map<UpdateClientMaster>(client));
                //List<UpdateClientAddressMaster> addresses = new List<UpdateClientAddressMaster>();
                //bool clientAddressUpdated = await _clientAddressMasterRepository.UpdateClientAddress(_mapper.MapCollection<List<ClientAddressMasterRequest>,
                //                                                                                             List<UpdateClientAddressMaster>,
                //                                                                                             ClientAddressMasterMapper>(client.Addresses, addresses));
                //List<UpdateClientDocumentMaster> clientDocuments = new List<UpdateClientDocumentMaster>();
                //bool clientDocumentUpdated = await _clientDocumentMasterRepository.UpdateClientDocument(_mapper.MapCollection<List<ClientDocumentMasterRequest>,
                //                                                                                            List<UpdateClientDocumentMaster>,
                //                                                                                            ClientDocumentMasterMapper>(client.Documents, clientDocuments));
                _unitOfWork.CommitTransaction();
                response.IsSuccessful = (bool)response.Data;
                return response;
            }
            catch (UnhandledException)
            {
                _unitOfWork.RollbackTransaction();
                _unitOfWork.Dispose();
                throw;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                _unitOfWork.Dispose();
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientMasterService", "UpdateClient", client);
            }
        }

        public async Task<ResponseModel<object>> DeleteClient(long clientId)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                ResponseModel<object> response = new ResponseModel<object>();
                response.Data = await _clientMasterRepository.DeleteClient(clientId);
                bool clientAddressUpdated = await _clientAddressMasterRepository.DeleteClientAddress(clientId);
                bool clientDocumentUpdated = await _clientDocumentMasterRepository.DeleteClientDocument(clientId);
                _unitOfWork.CommitTransaction();
                response.IsSuccessful = (bool)response.Data;
                return response;
            }
            catch (UnhandledException)
            {
                _unitOfWork.RollbackTransaction();
                _unitOfWork.Dispose();
                throw;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                _unitOfWork.Dispose();
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientMasterService", "DeleteClient", new { clientId });
            }
        }
    }
}
