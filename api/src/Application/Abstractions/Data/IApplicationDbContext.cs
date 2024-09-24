using Domain.Movie;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<MovieItem> MovieItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
