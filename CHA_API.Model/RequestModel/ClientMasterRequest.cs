using System.Collections.Generic;

namespace CHA_API.Model.RequestModel
{
    public class ClientMasterRequest
    {
        public long ClientId { get; set; }

        public string IECNo { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string PANNo { get; set; }

        public string ContactPerson { get; set; }

        public string PhoneNo { get; set; }

        public string Fax { get; set; }

        public string EMail { get; set; }

        public string BinNo { get; set; }

        public string TINNo { get; set; }

        public string EXPGSTNTType { get; set; }

        public string IMPGSTNTType { get; set; }

        public string RegNo { get; set; }

        public string TypeofExp { get; set; }

        public List<ClientAddressMasterRequest> Addresses { get; set; }

        public List<ClientDocumentMasterRequest> Documents { get; set; }

        public int UserId { get; set; }
    }
}
