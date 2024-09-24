using Domain.Movie;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movie;

internal sealed class MovieItemConfiguration : IEntityTypeConfiguration<MovieItem>
{
    public void Configure(EntityTypeBuilder<MovieItem> builder)
    {
        builder.HasKey(t => t.Id);
    }
}
