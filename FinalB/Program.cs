
public abstract class TicketType
{
    
}



public class BugReport : TicketType
{
    public string ErrorCodes { get; set; }

    public string ErrorLogs { get; set; }


}

public class ServiceRequest : TicketType
{
    public Request Request { get; set; }


}

public enum Request
{
    RequestForInformation;
    ChangeRequest;
}


/// <summary>
/// 2
/// </summary>
public interface IDeadlineCalculator
{
    int ResponseDeadline(int priority);

    int BreachDeadline(int priority);
}

public class BugReportCalculator : IDeadlineCalculator
{
    public int ResponseDeadline(int priority)
    {
        return priority * 2;
    }

    public int BreachDeadline(int priority)
    {
        return priority * 3;
    }
}



public class ServiceRequestCalculator : IDeadlineCalculator
{
    public int ResponseDeadline(int priority)
    {
        return priority * 4;
    }

    public int BreachDeadline(int priority)
    {
        return priority * 5;
    }
}



public class Ticket
{
    private IDeadlineCalculator deadlineCalculator;

    public Ticket(IDeadlineCalculator calculator)
    {
        this.deadlineCalculator = calculator;
    }


    public int ResponseDeadline(int priority)
    {
        return deadlineCalculator.ResponseDeadline(priority);
    }

    public int BreachDeadline(int priority)
    {
        return deadlineCalculator.BreachDeadline(priority);
    }
}



