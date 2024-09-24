using SharedKernel;

namespace Domain.Movie;

public static class MovieItemErrors
{
    public static Error NotFound(Guid Id) => Error.NotFound(
        "Movie.NotFound",
        $"The movie  with the Id = '{Id}' was not found");

    public static Error Empty() => Error.None;
}
