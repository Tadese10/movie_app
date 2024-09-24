using Application.Movie.Get;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Movies;

internal sealed class Search : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("movies/{search_text}/search", async (string search_text, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new SearchMoviesQuery(search_text);

            Result<List<MovieResponse>> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Movies);
    }
}
