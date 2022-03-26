using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CHA_API.Model.RequestModel
{
    public class ClientMasterRequest
    {
        public long ClientId { get; set; }

        [Required(ErrorMessage = "IECNO is requried")]
        [MinLength(10, ErrorMessage = "The {0} value should have minimum {1} characters")]
        [MaxLength(10, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string IECNo { get; set; }

        [Required(ErrorMessage = "Type is requried")]
        [MinLength(1, ErrorMessage = "The {0} value should have minimum {1} characters")]
        [MaxLength(1, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Name is requried")]
        [MaxLength(50, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pan is requried")]
        [MinLength(15, ErrorMessage = "The {0} value should have minimum {1} characters")]
        [MaxLength(15, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string PANNo { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string ContactPerson { get; set; }

        [MinLength(10, ErrorMessage = "The {0} value should have minimum {1} characters")]
        [MaxLength(13, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string PhoneNo { get; set; }

        [MaxLength(500, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string Fax { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string EMail { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string BinNo { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string TINNo { get; set; }

        [MinLength(3, ErrorMessage = "The {0} value can not exceed {1} characters")]
        [MaxLength(3, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string EXPGSTNType { get; set; }

        [MinLength(3, ErrorMessage = "The {0} value can not exceed {1} characters")]
        [MaxLength(3, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string IMPGSTNType { get; set; }

        [MaxLength(20, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string RegNo { get; set; }

        [MinLength(1, ErrorMessage = "The {0} value can not exceed {1} characters")]
        [MaxLength(1, ErrorMessage = "The {0} value can not exceed {1} characters")]
        public string TypeofExp { get; set; }

        public List<ClientAddressMasterRequest> Addresses { get; set; }

        //public List<ClientDocumentMasterRequest> Documents { get; set; }

        public int UserId { get; set; }
    }
}
