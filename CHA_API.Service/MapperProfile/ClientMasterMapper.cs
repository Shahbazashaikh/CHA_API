using System;
using AutoMapper;
using CHA_API.Model.TableModel;
using CHA_API.Model.RequestModel;

namespace CHA_API.Service.MapperProfile
{
    public class ClientMasterMapper : Profile
    {
        public ClientMasterMapper()
        {
            CreateMap<ClientMasterRequest, InsertClientMaster>()
                .ForMember(dest => dest.CreatedBy, src => src.MapFrom(s => s.UserId))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(s => DateTime.Now));

            CreateMap<ClientMasterRequest, UpdateClientMaster>()
                .ForMember(dest => dest.ModifiedBy, src => src.MapFrom(s => s.UserId))
                .ForMember(dest => dest.ModifiedDate, src => src.MapFrom(s => DateTime.Now));
        }
    }
}
