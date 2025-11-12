namespace TheDependencyProblem;

public class Greeter(IDateTimeProvider dateTimeProvider)
{
    public string CreateGreetMessage()
    {
        var dateTimeNow = dateTimeProvider.DateTimeNow;
        return dateTimeNow.Hour switch
        {
            >= 5 and < 12 => "Good morning",
            >= 12 and < 18 => "Good afternoon",
            _ => "Good evening"
        };
    }
}

public interface IDateTimeProvider
{
    public DateTime DateTimeNow { get; }
}

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime DateTimeNow => DateTime.Now;
}