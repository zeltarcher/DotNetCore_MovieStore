using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    //[Table("Movie")]
    public class Movie
    {
        public int Id { get; set; }

        //[MaxLength(256)]
        public string Title { get; set; }

        public string Overview { get; set; }
        
        //[MaxLength(512)]
        public string Tagline { get; set; }

        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        //[Range(0, 9999999999999999.99)]
        public decimal? Budget { get; set; }

        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        //[Range(0, 9999999999999999.99)]
        public decimal? Revenue { get; set; }

        //[MaxLength(2048)]
        public string ImdbUrl { get; set; }

        //[MaxLength(2048)]
        public string TmdbUrl { get; set; }

        //[MaxLength(2048)]
        public string PosterUrl { get; set; }

        //[MaxLength(2048)]
        public string BackdropUrl { get; set; }

        //[MaxLength(64)]
        public string OriginalLanguage { get; set; }

        public DateTime? ReleaseDate{ get; set; }

        public int? RunTime { get; set; }

        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        //[Range(0, 99999.99)]
        public decimal? Price { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string CreatedBy { get; set; }

        public decimal? Rating { get; set; }

        //Navigation
        public ICollection<Trailer> Trailers { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }

        public ICollection<MovieCrew> MovieCrews { get; set; }
    }
}
