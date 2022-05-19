
using Proyecto1.Data.Repositorio.IRepositorio;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Data.Repositorio //Changed namespace and removed old models import - Sábado 14
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Producto producto)
        {
            var productoDb = _db.Productos.FirstOrDefault(p => p.Id == producto.Id);
            if (productoDb != null)
            {
                if (producto.ImageUrl != null)
                {
                    productoDb.ImageUrl = producto.ImageUrl;
                }
                if (producto.PadreId == 0)
                {
                    productoDb.PadreId = null;
                }
                else
                {
                    productoDb.PadreId = producto.PadreId;
                }
                productoDb.NumeroSerie = producto.NumeroSerie;
                productoDb.Descripcion = producto.Descripcion;
                productoDb.Precio = producto.Precio;
                productoDb.Costo = producto.Costo;
                productoDb.CategoriaId = producto.CategoriaId;
                productoDb.MarcaId = producto.MarcaId;
            }
        }
    }
}
