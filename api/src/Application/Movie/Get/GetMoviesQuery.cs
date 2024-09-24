using Application.Abstractions.Messaging;

namespace Application.Movie.Get;

public sealed record GetMoviesQuery(): IQuery<List<MovieResponse>>;
