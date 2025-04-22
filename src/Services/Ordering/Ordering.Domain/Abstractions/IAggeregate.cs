namespace Ordering.Domain.Abstractions;

public interface IAggeregate<T> : IAggeregate, IEntity<T>
{
    // ...
}

public interface IAggeregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}