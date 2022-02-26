using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CHA_API.Model.RequestModel;
using CHA_API.Model.TableModel;

namespace CHA_API.Service.MapperProfile
{
    public class CosigneeMasterMapper : Profile
    {
        public CosigneeMasterMapper()
        {
            CreateMap<ConsigneeMasterRequest, InsertConsigneeMaster>()
                .ForMember(dest => dest.CreatedBy, src => src.MapFrom(s => s.UserId))
                .ForMember(dest => dest.CreatedOn, src => src.MapFrom(s => DateTime.Now));
        }
    }
}
