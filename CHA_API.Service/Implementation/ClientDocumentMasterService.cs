using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using CHA_API.Model;
using CHA_API.Model.ExceptionModel;
using CHA_API.Model.RequestModel;
using CHA_API.Model.ResponseModel;
using CHA_API.Model.TableModel;
using CHA_API.Repository;
using CHA_API.Service.MapperProfile;
using Microsoft.AspNetCore.Http;

namespace CHA_API.Service
{
    public class ClientDocumentMasterService : IClientDocumentMasterService
    {
        private readonly IClientDocumentMasterRepository _clientDocumentMasterRepository;
        private readonly IMapper _mapper;

        public ClientDocumentMasterService(IClientDocumentMasterRepository clientDocumentMasterRepository,
                                           IMapper mapper)
        {
            _clientDocumentMasterRepository = clientDocumentMasterRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<ClientDocumentMasterResponse>>> GetClientDocument(long clientId)
        {
            try
            {
                ResponseModel<List<ClientDocumentMasterResponse>> response = new ResponseModel<List<ClientDocumentMasterResponse>>();
                response.Data = (await _clientDocumentMasterRepository.GetClientDocument(clientId))?.ToList();
                response.IsSuccessful = response.Data != null && response.Data.Count > 0;
                if (response.IsSuccessful == false)
                    response.Error.ErrorMessage = "Data not found";
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientDocumentMasterService", "GetClientDocument", new { clientId });
            }
        }

        public async Task<ResponseModel<object>> InsertClientDocument(List<ClientDocumentMasterRequest> documents)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                List<InsertClientDocumentMaster> clientDocuments = new List<InsertClientDocumentMaster>();
                UploadDocuments(documents);
                long documentId = await _clientDocumentMasterRepository.InserClientDocument(_mapper.MapCollection<List<ClientDocumentMasterRequest>,
                                                                                                                 List<InsertClientDocumentMaster>,
                                                                                                                 ClientDocumentMasterMapper>(documents, clientDocuments));
                response.Data = documentId > 0;
                response.IsSuccessful = documentId > 0;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientDocumentMasterService", "InsertClientDocument", documents);
            }
        }

        public async Task<ResponseModel<object>> UpdateClientDocument(List<ClientDocumentMasterRequest> documents)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                List<UpdateClientDocumentMaster> clientDocuments = new List<UpdateClientDocumentMaster>();
                response.Data = await _clientDocumentMasterRepository.UpdateClientDocument(_mapper.MapCollection<List<ClientDocumentMasterRequest>,
                                                                                                                 List<UpdateClientDocumentMaster>,
                                                                                                                 ClientDocumentMasterMapper>(documents, clientDocuments));
                response.IsSuccessful = (bool)response.Data;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientDocumentMasterService", "UpdateClientDocument", documents);
            }
        }

        public async Task<ResponseModel<object>> DeleteClientDocument(long clientId, long documentId)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                response.Data = await _clientDocumentMasterRepository.DeleteClientDocument(clientId, documentId);
                response.IsSuccessful = (bool)response.Data;
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientDocumentMasterService", "DeleteClientDocument", new { clientId, documentId });
            }
        }

        private void UploadDocuments(List<ClientDocumentMasterRequest> documents)
        {
            try
            {
                ResponseModel<object> response = new ResponseModel<object>();
                if (documents != null && documents.Count > 0)
                {
                    documents.ForEach((document) =>
                    {
                        string pathToSave = Path.Combine("C:\\", document.ClientName);
                        if (document != null && document.File != null)
                        {
                            string fileName = ContentDispositionHeaderValue.Parse(document.File.ContentDisposition).FileName.Trim('"');
                            string fullPath = Path.Combine(pathToSave, fileName);
                            document.DocumentPath = fullPath;
                            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                            {
                                document.File.CopyTo(stream);
                            }
                        }
                    });
                }
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "ClientDocumentMasterService", "UploadDocuments", documents);
            }
        }
    }
}
