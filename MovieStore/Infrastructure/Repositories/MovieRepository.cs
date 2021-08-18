using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
        {

        }

        public async Task<IEnumerable<Movie>> Get30HighestRevenueMovie()
        {
            //get 30 movies from movie table order by revenue
            //ToList/Count/loop
            // I/O bound operation
            //EF has methods that have both async and non-async
            return await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            //movie table, then genres, then cast and rating
            //Include() ThenInclude() means including data
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                throw new Exception($"No movie Found for the ID {id}");
            }
            var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == id).DefaultIfEmpty()
                .AverageAsync(r=>r==null?0:r.Rating);

            movie.Rating = movieRating;
            return movie;
        }
    }
}
