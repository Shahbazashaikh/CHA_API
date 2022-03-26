using Dapper.Contrib.Extensions;

namespace CHA_API.Model.TableModel
{
    [Table("ClientMaster")]
    public class ClientMasterBase
    {
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

        public string EXPGSTNType { get; set; }

        public string IMPGSTNType { get; set; }

        public string RegNo { get; set; }

        public string TypeofExp { get; set; }
    }
}
