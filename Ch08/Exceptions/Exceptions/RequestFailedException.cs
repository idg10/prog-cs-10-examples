namespace Exceptions;

// Dummy type to enable Example 6 to compile
class RequestFailedException : Exception
{
    public RequestFailedException(int status)
    {
        Status = status;
    }

    public int Status { get; }
}
