namespace PaperLess.DataAccess.Interfaces.DalExceptions;

public class DalExceptionBase : Exception
{
    public DalExceptionBase(string message) :  base(message){}
    
    public DalExceptionBase(string message, Exception innerException) : base(message, innerException){}
}