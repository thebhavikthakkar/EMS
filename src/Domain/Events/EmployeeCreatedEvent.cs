namespace CleanArchitecture.Domain.Events;

public class EmployeeCreatedEvent : BaseEvent
{
    public EmployeeCreatedEvent(CleanArchitecture.Domain.Entities.Employee item)
    {
        Item = item;
    }

    public Employee Item { get; }
}
