using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Movie;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedKernel;

namespace Application.Movie.Get;

internal sealed class GetMoviesQueryHandler() : IQueryHandler<GetMoviesQuery, List<MovieResponse>>
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2016:Forward the 'CancellationToken' parameter to methods", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
    public async Task<Result<List<MovieResponse>>> Handle(GetMoviesQuery query, CancellationToken cancellationToken)
    {

        using (var client = new HttpClient())
        {
            try
            {
#pragma warning disable CA2234 // Pass system uri objects instead of strings
#pragma warning disable S1075 // URIs should not be hardcoded
                HttpResponseMessage response = await client.GetAsync("https://www.omdbapi.com/?s=latest&apikey=8ad0afd1");
#pragma warning restore S1075 // URIs should not be hardcoded
#pragma warning restore CA2234 // Pass system uri objects instead of strings
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (JObject.Parse(responseBody).GetValue("Response").ToString() == "True")
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    List<MovieResponse>? data = JsonConvert.DeserializeObject<List<MovieResponse>>(JObject.Parse(responseBody).GetValue("Search").ToString());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    return data;
                }
                else
                {
                    return new List<MovieResponse> { };
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
          
        return new List<MovieResponse> { };
    }
}
