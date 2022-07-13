using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.API.Exceptions
{
    public class CloudinaryServerException : Exception
    {
        public CloudinaryServerException()
        {
        }

        public CloudinaryServerException(string message) : base(message)
        {
        }
    }
}