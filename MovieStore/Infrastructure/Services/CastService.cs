using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsResponseModel> GetCastDetails(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);

            var castDetailsModel = new CastDetailsResponseModel
            {
                Id = cast.Id,
                ProfilePath = cast.ProfilePath,
                Name = cast.Name,
                Gender = cast.Gender,
            };

            castDetailsModel.Movies = new List<MovieCardResponseModel>();
            foreach (var movie in cast.CastsInMovie) 
            {
                castDetailsModel.Movies.Add(new MovieCardResponseModel
                {
                    Id=movie.MovieId,
                    Title=movie.Movie.Title
                });
            }
            return castDetailsModel;
        }
    }
}
