namespace EventRsvpPlatform.Filters;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message) { }
}