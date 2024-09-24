namespace Application.Movie.GetById;

public sealed class MovieResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Year { get; set; }
    public string? imdbID { get; set; }
    public string? Type { get; set; }
    public string? Poster { get; set; }
    public string? Plot { get; set; }
    public string? ImdbRating { get; set; }
}
