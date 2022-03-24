using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Logika.Data
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public List<string> Message { get; set; } = new List<string>();
        public T Data { get; set; }
    }
}
