using Application.Abstractions.Messaging;

namespace Application.Movie.GetById;

public sealed record GetMovieByIdQuery(string Id) : IQuery<MovieResponse>;
