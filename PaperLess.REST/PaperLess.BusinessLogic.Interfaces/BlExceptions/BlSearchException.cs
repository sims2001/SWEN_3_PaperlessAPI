namespace PaperLess.BusinessLogic.Interfaces.BlExceptions;

public class BlSearchException : BlExceptionBase
{
    public BlSearchException(string message) :  base(message){}
    
    public BlSearchException(string message, Exception innerException) : base(message, innerException){}
}