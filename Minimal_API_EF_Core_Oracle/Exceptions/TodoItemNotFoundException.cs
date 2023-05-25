namespace Minimal_API_EF_Core_Oracle.Exceptions
{
    public class TodoNotFoundException : Exception
    {
        public TodoNotFoundException(string message)
            : base(message)
        {
        }
    }
}