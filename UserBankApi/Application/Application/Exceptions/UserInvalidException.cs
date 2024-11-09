
namespace Application.Exceptions
{
    public class UserInvalidException : Exception
    {
        public UserInvalidException() : base("The data info can not be null or empty") {}

        public UserInvalidException(string message) : base(message)
        {}
    }
}
