namespace Tournament.Domain.MovieContext.Contracts
{
    public interface IMovie
    {
        string Id { get; }

        string Title { get; }

        int Year { get; }

        decimal Rate { get; }
    }
}