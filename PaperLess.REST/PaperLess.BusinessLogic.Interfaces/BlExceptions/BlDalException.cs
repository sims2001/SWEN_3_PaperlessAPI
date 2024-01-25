namespace PaperLess.BusinessLogic.Interfaces.BlExceptions;

public class BlDalException : BlExceptionBase
{
    public BlDalException(string message) :  base(message){}
    
    public BlDalException(string message, Exception innerException) : base(message, innerException){}
}