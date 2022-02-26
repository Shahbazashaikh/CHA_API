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
        [Required(ErrorMessage = "CompanyName is reqired")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "CountryCode is reqired")]
        public string CountryCode { get; set; }
    }
}
