using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Logika.Data.Models
{
    public class CategoryProducent
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Producent Producent { get; set; }

    }
}
