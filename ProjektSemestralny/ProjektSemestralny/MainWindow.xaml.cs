using ProjektSemestralny.Logika;
using ProjektSemestralny.Logika.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektSemestralny
{
    public partial class MainWindow : Window
    {
        private ApplicationDBContext context;
        private ShopRepository shopRepository;
        public MainWindow()
        {
            InitializeComponent();
            
            context = new ApplicationDBContext();
            shopRepository = new ShopRepository(context);
        }
    }
}
