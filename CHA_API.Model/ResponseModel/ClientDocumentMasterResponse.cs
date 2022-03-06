using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Model.ResponseModel
{
    public class ClientDocumentMasterResponse
    {
        public long DocumentID { get; set; }

        public long ClientId { get; set; }

        public string DocumentName { get; set; }

        public string DocumentPath { get; set; }

        public int DocumentType { get; set; }
    }
}
