namespace PaperLess.DataAccess.Interfaces.DalExceptions;

public class MapperException : DalExceptionBase
{
    public MapperException(string message) :  base(message){}
    
    public MapperException(string message, Exception innerException) : base(message, innerException){}
}