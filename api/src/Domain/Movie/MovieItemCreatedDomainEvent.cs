using SharedKernel;

namespace Domain.Movie;

public sealed record MovieItemCreatedDomainEvent(Guid Id) : IDomainEvent;
