using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMVC.ViewModel
{
    public class ProductoViewModel
    {
        public List<Models.Producto> Productos { get; set; } = new List<Models.Producto>();
        public string SearchText { get; set; }=string.Empty;
    }
}