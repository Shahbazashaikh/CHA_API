using System.ComponentModel.DataAnnotations;

namespace CHA_API.Model.RequestModel
{
    public class ClientAddressMasterRequest
    {
        public long AddressID { get; set; }

        public long ClientId { get; set; }

        [Required(ErrorMessage = "Branch No is requried")]
        [MinLength(3,ErrorMessage = "The {0} value should have minimum {1} characters")]
        [MaxLength(3,ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string BranchNo { get; set; }

        [Required(ErrorMessage ="Address 1 is requried")]
        [MaxLength(35, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string Address1 { get; set; }

        [MaxLength(35, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string Address2 { get; set; }

        [MaxLength(35, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string City { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "State Code is requried")]
        [MinLength(2, ErrorMessage = "The {0} value should have minimum {1} characters")]
        [MaxLength(2, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string StateCode { get; set; }

        [Required(ErrorMessage = "District is requried")]
        [MaxLength(35, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string District { get; set; }

        [Required(ErrorMessage = "Pin Code is requried")]
        [MinLength(6, ErrorMessage = "The {0} value should have minimum {1} characters")]
        [MaxLength(6, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string PINCode { get; set; }

        public int UserId { get; set; }
    }
}
