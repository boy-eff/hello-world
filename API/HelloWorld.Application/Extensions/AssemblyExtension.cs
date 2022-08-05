using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HelloWorld.Application.Extensions
{
    public static class AssemblyExtension
    {
        public static Assembly GetApplicationAssembly(this Assembly assembly)
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}