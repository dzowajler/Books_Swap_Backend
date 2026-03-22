using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection.DbModels
{
    [Table("BookConditions")]
    public class BookCondition
    {
        [Key]
        public int BookConditionId { get; set; }

        public string Condition { get; set; }
    }
}
