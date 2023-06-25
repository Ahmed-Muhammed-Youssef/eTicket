using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Base;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        public MovieService(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
