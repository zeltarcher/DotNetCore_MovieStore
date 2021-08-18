using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var movieDetailsModel = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                ImdbUrl = movie.ImdbUrl,
                BackdropUrl = movie.BackdropUrl,
                Budget = movie.Budget,
                Overview = movie.Overview,
                Price = movie.Price,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate,
                PosterUrl = movie.PosterUrl,
                RunTime = movie.RunTime,
                Rating = movie.Rating,
                Tagline = movie.Tagline
            };
            movieDetailsModel.Casts = new List<CastResponseModel>();
            foreach (var cast in movie.MovieCasts)
            {
                movieDetailsModel.Casts.Add(new CastResponseModel 
                { 
                    Id = cast.CastId,
                    ProfilePath = cast.Cast.ProfilePath,
                    Name = cast.Cast.Name,
                    Character = cast.Character
                });
            }

            movieDetailsModel.genres = new List<GenreResponseModel>();
            foreach (var genre in movie.Genres)
            {
                movieDetailsModel.genres.Add(new GenreResponseModel 
                { 
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            return movieDetailsModel;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.Get30HighestRevenueMovie();

            var movieCards = new List<MovieCardResponseModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
            }

            return movieCards;
        }


    }
}
