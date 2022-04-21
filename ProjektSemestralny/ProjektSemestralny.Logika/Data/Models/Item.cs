using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Logika.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }
        public CategoryProducent CategoryProducent { get; set; }

        [ForeignKey("CategoryProducent")]
        public int CategoryProducentId { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Price}";
        }
    }
}
