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
    public class BuyerMasterMapper : Profile
    {
        public BuyerMasterMapper()
        {
            CreateMap<BuyerMasterRequest, InsertBuyerMaster>()
                .ForMember(dest => dest.CreatedBy, src => src.MapFrom(s => s.UserId))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(s => DateTime.Now));
        }
    }
}
