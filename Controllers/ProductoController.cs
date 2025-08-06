using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MiPrimerAppMVC.Models;
using MiPrimerAppMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MiPrimerAppMVC.Data.Repository.Interfaces;

namespace MiPrimerAppMVC.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductosContext _context;
        private readonly IProductoRepository _productoRepository;

        // Constructor que recibe el contexto de la base de datos
        // Esto permite que el controlador pueda interactuar con la base de datos
        // a través del contexto inyectado
        // Esto es útil para realizar operaciones CRUD en la base de datos
        // public ProductoController(ProductosContext context)
        // {
        //     _context = context;
        // }

        // Constructor que recibe el repositorio de productos
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IActionResult> Index()
        {
            //var productos = GetData();
            // Aquí podrías obtener una lista de productos y pasarlos a la vista

            var productos = await _productoRepository.GetAllAsync(); // Obtener productos desde el repositorio
            //var productos = await _context.Productos.ToListAsync(); // Obtener productos desde la base de datos
            return View(productos);
        }

        public IActionResult Inicio()
        {
            return View();
        }


        // CREAR REGISTROS ------------------------------------------------------------------

        // GET: Producto/Create - para mostrar el formulario de creación de un nuevo producto
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create - para manejar la creación de un nuevo producto
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
                {
                    try
                    {
                        producto.FechaDeAlta = DateTime.Now;
                        await _productoRepository.CreateAsync(producto);
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = "Error al crear el producto: " + ex.Message;
                        return View(producto);
                    }
                }
                return View(producto);
        }


        // EDITAR REGISTROS ------------------------------------------------------------------

        //GET: Producto/Edit/5 - para mostrar el formulario de edición de un producto
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var producto = await _productoRepository.GetByIdAsync(id);  // Método del repo
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: Producto/Edit/5 - para manejar la edición de un producto, enviar la info
        // a la base de datos
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _productoRepository.UpdateAsync(producto);  // Método del repo
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // BORRAR REGISTROS ------------------------------------------------------------------

        // GET: Producto/Delete/5 - para mostrar el formulario de confirmación de eliminación
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var producto = await _productoRepository.GetByIdAsync(id);  // Método del repo
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: Producto/Delete/5 - para manejar la eliminación de un producto
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null)
                return NotFound();

            await _productoRepository.DeleteAsync(id);  // Método del repo
            return RedirectToAction(nameof(Index));
        }
        
        // Método para obtener una lista de productos
        public List<Producto> GetData()
        {
            List<Producto> productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Cafe",Descripcion = "Cafe en grano", Precio = 10.0m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1)},
                new Producto { Id = 2, Nombre = "Te", Descripcion = "Te verde", Precio = 5.0m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-2)},
                new Producto { Id = 3, Nombre = "Leche", Descripcion = "Leche descremada", Precio = 3.0m, Activo = false, FechaDeAlta = DateTime.Now.AddDays(-3)},
                new Producto { Id = 4, Nombre = "Azucar", Descripcion = "Azucar morena", Precio = 2.5m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-4)},
                new Producto { Id = 5, Nombre = "Miel", Descripcion = "Miel natural", Precio = 8.0m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-5)},
                new Producto { Id = 6, Nombre = "Chocolate", Descripcion = "Chocolate amargo", Precio = 12.0m, Activo = false, FechaDeAlta = DateTime.Now.AddDays(-6)} ,
                new Producto { Id = 7, Nombre = "Galletas", Descripcion = "Galletas integrales", Precio = 4.0m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-7)},
                new Producto { Id = 8, Nombre = "Pan", Descripcion = "Pan artesanal", Precio = 6.0m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-8)},
                new Producto { Id = 9, Nombre = "Queso", Descripcion = "Queso cheddar", Precio = 15.0m, Activo = false, FechaDeAlta = DateTime.Now.AddDays(-9)},
                new Producto { Id = 10, Nombre = "Yogur", Descripcion = "Yogur natural", Precio = 7.0m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-10)}

            };

            return productos;
        }

    }
}

