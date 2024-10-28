
namespace DemoMVC.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }
    }
}