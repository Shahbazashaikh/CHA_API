using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CHA_API.Model.RequestModel
{
    public class GetConsigneeMasterRequest
    {
        public string CompanyName { get; set; }

        public string CountryCode { get; set; }

        public string Type { get; set; }
    }
}
