namespace PaperLess.BusinessLogic.Interfaces.BlExceptions;

public class BlValidationException : BlExceptionBase
{
    public BlValidationException(string message) :  base(message){}
    
    public BlValidationException(string message, Exception innerException) : base(message, innerException){}
}