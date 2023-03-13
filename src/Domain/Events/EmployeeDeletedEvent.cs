namespace CleanArchitecture.Domain.Events;

public class EmployeeDeletedEvent : BaseEvent
{
    public EmployeeDeletedEvent(CleanArchitecture.Domain.Entities.Employee item)
    {
        Item = item;
    }

    public Employee Item { get; }
}
