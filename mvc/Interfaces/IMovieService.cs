using mvc.Data.Base;
using mvc.Data.ViewModels;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<Movie?> GetByIdWithInclusionAsync(int id);
        Task<Movie> AddMovieVMAsync(MovieVM movieVM);
        Task<Movie?> UpdateMovieVMAsync(MovieVM movieVM);
    }
}
