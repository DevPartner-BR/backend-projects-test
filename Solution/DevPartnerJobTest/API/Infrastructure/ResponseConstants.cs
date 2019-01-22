using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure
{
    public static class ResponseConstants
    {
        public const string NotFound = "Entity not found";
        public const string Deleted = "Entity deleted";
        public const string ContactUs = "Internal Server Error";
        public const string MessageDbConnectionFailed = "Error Code: 001";
    }
}
