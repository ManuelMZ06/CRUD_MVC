using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC.Data.Repository.Interfaces;
using MiPrimerAppMVC.Models;

namespace MiPrimerAppMVC.Data.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        // Implementar una interfaz para el repositorio de productos
        // Esto permitirá una mejor separación de preocupaciones y facilitará las pruebas unitarias 

        // Inyectar el contexto de la base de datos en el repositorio
        private readonly ProductosContext _context;
        // Constructor que recibe el contexto de la base de datos
        // Esto permite que el repositorio pueda interactuar con la base de datos
        public ProductoRepository(ProductosContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            var productos = await _context.Productos.ToListAsync();
            return productos;
        }

        //GetById
        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        // Métodos para crear, actualizar y eliminar productos

        //Create
        public async Task CreateAsync(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
        }
        //Update
        public async Task UpdateAsync(Producto producto)
        {
            _context.Update(producto);
            await _context.SaveChangesAsync();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}