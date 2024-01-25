namespace PaperLess.BusinessLogic.Interfaces.BlExceptions;

public class BlExceptionBase : Exception
{
    public BlExceptionBase(string message) :  base(message){}
    
    public BlExceptionBase(string message, Exception innerException) : base(message, innerException){}
}