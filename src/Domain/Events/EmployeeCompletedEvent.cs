namespace CleanArchitecture.Domain.Events;

public class EmployeeCompletedEvent : BaseEvent
{
    public EmployeeCompletedEvent(CleanArchitecture.Domain.Entities.Employee item)
    {
        Item = item;
    }

    public Employee Item { get; }
}
