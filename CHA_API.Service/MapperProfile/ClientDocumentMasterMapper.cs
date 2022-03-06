using System;
using AutoMapper;
using CHA_API.Model.TableModel;
using CHA_API.Model.RequestModel;

namespace CHA_API.Service.MapperProfile
{
    public class ClientDocumentMasterMapper : Profile
    {
        public ClientDocumentMasterMapper()
        {
            CreateMap<ClientDocumentMasterRequest, InsertClientDocumentMaster>()
                .ForMember(dest => dest.CreatedBy, src => src.MapFrom(s => s.UserId))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(s => DateTime.Now));

            CreateMap<ClientDocumentMasterRequest, UpdateClientDocumentMaster>()
                .ForMember(dest => dest.ModifiedBy, src => src.MapFrom(s => s.UserId))
                .ForMember(dest => dest.ModifiedDate, src => src.MapFrom(s => DateTime.Now));
        }
    }
}
