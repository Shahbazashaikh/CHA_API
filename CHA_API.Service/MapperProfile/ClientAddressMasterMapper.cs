using System;
using AutoMapper;
using CHA_API.Model.TableModel;
using CHA_API.Model.RequestModel;

namespace CHA_API.Service.MapperProfile
{
    public class ClientAddressMasterMapper : Profile
    {
        public ClientAddressMasterMapper()
        {
            CreateMap<ClientAddressMasterRequest, InsertClientAddressMaster>()
                .ForMember(dest => dest.CreatedBy, src => src.MapFrom(s => s.UserId))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(s => DateTime.Now));

            CreateMap<ClientAddressMasterRequest, UpdateClientAddressMaster>()
                .ForMember(dest => dest.ModifiedBy, src => src.MapFrom(s => s.UserId))
                .ForMember(dest => dest.ModifiedDate, src => src.MapFrom(s => DateTime.Now));
        }
    }
}
