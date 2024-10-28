using DemoMVC.Models;
using DemoMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoMVC.ViewModel;

namespace DemoMVC.Controllers
{
    public class ProductoController : Controller
    {

        private readonly DataContext _context;

        public ProductoController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index( string SearchText)
        {
            //var producto = new Models.Producto{Id = 1, Nombre = "Producto 1", Descripcion = "Descripcion del producto 1", Precio = 100};
            var productos = _context.Productos.Include(p => p.Categoria).Include(p => p.Proveedor).ToList();
            if(!string.IsNullOrEmpty(SearchText))
            {
                productos = productos.Where(p => p.Nombre.Contains(SearchText)).ToList();
            }
            var productoViewModel = new ProductoViewModel();
            productoViewModel.Productos = productos;
            productoViewModel.SearchText = SearchText;
            
            return View(productoViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }


        [HttpGet]
        public async Task< IActionResult> Create()
        {
            ViewBag.Categorias = await _context.Categorias.ToListAsync();
            ViewBag.Proveedores = await _context.Proveedores.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,CategoriaId,ProveedorId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = await _context.Categorias.ToListAsync();
            ViewBag.Proveedores = await _context.Proveedores.ToListAsync();

            return View(producto);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Categorias = await _context.Categorias.ToListAsync();
            ViewBag.Proveedores = await _context.Proveedores.ToListAsync();

            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,CategoriaId,ProveedorId")] Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            //var productoDb = await _context.Productos.FindAsync(id);
            if(ModelState.IsValid)
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = await _context.Categorias.ToListAsync();
            ViewBag.Proveedores = await _context.Proveedores.ToListAsync();

            return View(producto);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}