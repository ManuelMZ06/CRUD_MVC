using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerAppMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public bool Activo { get; set; }
// ...existing code...
    public byte[] passwordHash { get; set; } = Array.Empty<byte>();
    public byte[] passwordSalt { get; set; } = Array.Empty<byte>();
// ...existing code...
    }
}