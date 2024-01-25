namespace PaperLess.DataAccess.Interfaces.DalExceptions;

public class DalDbException : DalExceptionBase
{
    public DalDbException(string message) :  base(message){}
    
    public DalDbException(string message, Exception innerException) : base(message, innerException){}
}