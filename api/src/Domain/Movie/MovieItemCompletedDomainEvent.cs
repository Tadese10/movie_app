using SharedKernel;

namespace Domain.Movie;

public sealed record MovieItemCompletedDomainEvent(Guid Id) : IDomainEvent;
