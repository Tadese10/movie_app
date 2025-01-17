﻿using SharedKernel;

namespace Domain.Movie;

public sealed class MovieItem : Entity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string imdbID { get; set; }
    public string Type { get; set; }
    public string Poster { get; set; }
}
