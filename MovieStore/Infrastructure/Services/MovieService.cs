using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;

namespace Infrastructure.Services
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighest30GrossingMovies();
            var movieCards = new List<MovieCardResponseModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title
                });
            }
            return movieCards;
        }
    }
}
