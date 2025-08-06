# CRUD de Productos - ASP.NET Core MVC

Este proyecto es una aplicación web desarrollada con **ASP.NET Core MVC** y **Entity Framework Core**, que permite gestionar productos mediante operaciones CRUD (Crear, Leer, Actualizar, Eliminar).

##  Tecnologías utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Razor Pages (MVC)
- Visual Studio / Visual Studio Code

##  Estructura del proyecto

- **Models**: Contiene las clases de entidad (`Producto.cs`).
- **Data / Contexto**: Contexto de EF Core (`ProductosContext.cs`).
- **Controllers**: Controladores MVC para manejar la lógica del CRUD.
- **Views**: Vistas Razor para crear la interfaz de usuario.

##  Configuración de la base de datos

En `appsettings.json`:

```json
"ConnectionStrings": {
  "ProductosContext": "Server=localhost\\SQLEXPRESS;Database=ProductosDB;Trusted_Connection=True;"
}
```
