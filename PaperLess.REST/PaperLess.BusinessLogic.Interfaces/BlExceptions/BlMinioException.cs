namespace PaperLess.BusinessLogic.Interfaces.BlExceptions;

public class BlMinioException : BlExceptionBase
{
    public BlMinioException(string message) :  base(message){}
    
    public BlMinioException(string message, Exception innerException) : base(message, innerException){}
}