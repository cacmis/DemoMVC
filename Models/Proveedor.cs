using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMVC.Models
{
    public class Proveedor
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }
    }
}