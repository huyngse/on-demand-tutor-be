namespace OnDemandTutor.DataAccess.ExceptionModels;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message)
    {
    }
    public BadRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public BadRequestException()
    {
    }
}