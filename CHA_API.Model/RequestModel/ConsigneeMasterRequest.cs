using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Model.RequestModel
{
    public class ConsigneeMasterRequest
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string BranchNo { get; set; }

        [Required(ErrorMessage = "Address1 is required")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "CountryCode is required")]
        public string CountryCode { get; set; }

        public int ZipCode { get; set; }

        public string Remarks { get; set; }

        public int UserId { get; set; }
    }
}
