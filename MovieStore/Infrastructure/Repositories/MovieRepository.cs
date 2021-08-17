using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
