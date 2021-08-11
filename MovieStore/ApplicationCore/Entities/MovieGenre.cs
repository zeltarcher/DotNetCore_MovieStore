using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("MovieGenre")]
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
    }
}
