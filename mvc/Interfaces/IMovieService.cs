using mvc.Data.Base;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllWithCinemaAsync();
    }
}
