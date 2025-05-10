namespace BuildingBlocks.Messaging.Events;

public class IntegrationEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime OccurredOn { get; set; } = DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName;
}