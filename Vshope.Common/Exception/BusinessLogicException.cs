namespace Vshope.Common.Exception
{
    public class BusinessLogicException : System.Exception
    {
        public BusinessLogicException(string code) : base(code)
        {
        }

        public BusinessLogicException(string code, System.Exception innerException) : base(code, innerException)
        {
        }

        public BusinessLogicException()
        {
        }
    }
}
