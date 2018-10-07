using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestipsSignalFunctions.Models
{
    [Table("Signal")]
    public class Signal
    {
        public int Id { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
