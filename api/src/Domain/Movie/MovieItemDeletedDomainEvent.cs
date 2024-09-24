using SharedKernel;

namespace Domain.Movie;

public sealed record MovieItemDeletedDomainEvent(Guid Id) : IDomainEvent;
