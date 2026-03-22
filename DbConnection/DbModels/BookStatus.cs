using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection.DbModels
{
    [Table("BooksStatuses")]
    public class BookStatus
    {
        [Key]
        public int BookStatusId { get; set; }

        public string Status { get; set; }
    }
}
