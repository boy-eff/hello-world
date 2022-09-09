using System.Reflection;

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