using ProjektSemestralny.Logika.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Logika.Data
{
    public class ShopRepository
    {
        private readonly ApplicationDBContext context;
        public ShopRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public List<Item> GetAllItems()
        {
            return context.Items.ToList();
        }
    }
}
