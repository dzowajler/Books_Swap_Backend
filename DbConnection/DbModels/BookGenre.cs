using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection.DbModels
{
    [Table("BookGenres")]
    public class BookGenre
    {
        [Key]
        public int BookGenreId { get; set; }

        public string Genre { get; set; }
    }
}
