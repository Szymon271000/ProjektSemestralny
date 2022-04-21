using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Logika.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public User User { get; set; }
        public bool Paid { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        [NotMapped]
        public double? Price
        {
            get
            {
                if (Items != null && Items.Count > 0)
                {
                    return Items.Select(x => x.Product?.Price).Sum();
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
