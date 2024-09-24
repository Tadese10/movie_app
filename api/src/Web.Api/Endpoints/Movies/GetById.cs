using Application.Movie.Get;
using Application.Movie.GetById;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;
using MovieResponse = Application.Movie.GetById.MovieResponse;

namespace Web.Api.Endpoints.Movies;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("movies/{id}", async (string id, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new GetMovieByIdQuery(id);

            Result<MovieResponse> result = await sender.Send<Result<MovieResponse>>(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Movies);
    }
}
