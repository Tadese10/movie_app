using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Movie;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SharedKernel;

namespace Application.Movie.GetById;

internal sealed class GetMovieByIdQueryHandler() : IQueryHandler<GetMovieByIdQuery, MovieResponse>
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2016:Forward the 'CancellationToken' parameter to methods", Justification = "<Pending>")]
    public async Task<Result<MovieResponse>> Handle(GetMovieByIdQuery query, CancellationToken cancellationToken)
    {
        using (var client = new HttpClient())
        {
            try
            {
#pragma warning disable CA2234 // Pass system uri objects instead of strings
#pragma warning disable S1075 // URIs should not be hardcoded
                HttpResponseMessage response = await client.GetAsync($"https://www.omdbapi.com/?i={query.Id}&apikey=8ad0afd1");
#pragma warning restore S1075 // URIs should not be hardcoded
#pragma warning restore CA2234 // Pass system uri objects instead of strings
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (JObject.Parse(responseBody).GetValue("Response").ToString() == "True")
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                   MovieResponse? data = JsonConvert.DeserializeObject<MovieResponse>(responseBody);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    return data;
                }
                else
                {
                    return new MovieResponse { };
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

        }
        return new MovieResponse { };
    }
}
