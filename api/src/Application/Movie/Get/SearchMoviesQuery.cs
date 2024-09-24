using Application.Abstractions.Messaging;

namespace Application.Movie.Get;

public sealed record SearchMoviesQuery(string query): IQuery<List<MovieResponse>>;
