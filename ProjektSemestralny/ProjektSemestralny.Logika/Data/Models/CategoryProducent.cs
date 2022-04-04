using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Logika.Data.Models
{
    public class CategoryProducent
    {
        public int Id { get; set; }
        
        public Category Category { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Producent Producent { get; set; }

        [ForeignKey("Producent")]
        public int ProducentId { get; set; }

    }
}
