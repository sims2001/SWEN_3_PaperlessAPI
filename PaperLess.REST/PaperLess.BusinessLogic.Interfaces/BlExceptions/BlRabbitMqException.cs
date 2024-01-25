namespace PaperLess.BusinessLogic.Interfaces.BlExceptions;

public class BlRabbitMqException : BlExceptionBase
{
    public BlRabbitMqException(string message) :  base(message){}
    
    public BlRabbitMqException(string message, Exception innerException) : base(message, innerException){}
}