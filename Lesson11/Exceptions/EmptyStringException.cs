namespace Lesson11.Exceptions;
internal class EmptyStringException : Exception
{
    public EmptyStringException()
    {
    }

    public EmptyStringException(string message) : base(message)
    {
    }
}

