using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection.DbModels
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(350)]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required] 
        public decimal Price { get; set; }

        public int BookGenreId { get; set; }

        [ForeignKey("BookGenreId")]
        public BookGenre BookGenre { get; set; }
    }
}
