using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.APICore
{
    public class ApiCoreResult<T>
    {
        public string? ServiceName { get; set; }
        public object? RequestMessage { get; set; }
        public T? Result { get; set; }
        
        public List<string?> Errors { get; set; }

        public ApiCoreResult() 
        { 
            Errors = new List<string?>();
        }

        public bool HasError()
        {
            bool result = false;
            if (Errors != null)
            { 
                return Errors.Any();
            }
            return result;
        }
    }
}
