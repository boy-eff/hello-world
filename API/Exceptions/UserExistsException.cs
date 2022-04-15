using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API.Exceptions
{
    [Serializable]
    public class UserExistsException : Exception
    {
        public UserExistsException()
        {
        }

        public UserExistsException(string message) : base(message)
        {
        }
    }
}