using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Model
{
    public class StandardErrorMessage<T> where T : class
    {
        public T ErrorMessage { get; set; }

        public int StatusCode { get; set; }

        public int SubCode { get; set; }
    }
}
