namespace Vshope.Common.Exception
{
    public class BadRequestException : System.Exception
    {
        public BadRequestException(string code) : base(code)
        {
        }

        public BadRequestException()
        {
        }
    }
}
