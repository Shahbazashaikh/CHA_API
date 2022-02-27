using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Model
{
    public class ResponseModel<T> where T : class
    {
        public T Data { get; set; }

        public bool IsSuccessful { get; set; }

        public StandardErrorMessage<string> Error { get; set; } = new StandardErrorMessage<string>();
    }
}
