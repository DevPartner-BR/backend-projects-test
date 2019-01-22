using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure
{
    public class ResponseDescriptor<T>
    {
        public string Message { get; set; }

        public T Result { get; set; }
    }
}
