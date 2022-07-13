using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Tests.Builders
{
    public abstract class BaseBuilder<T> where T : class
    {
        public abstract T Build();
    }
}