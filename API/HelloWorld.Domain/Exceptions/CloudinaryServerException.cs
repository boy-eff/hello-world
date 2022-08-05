namespace HelloWorld.Domain.Exceptions
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