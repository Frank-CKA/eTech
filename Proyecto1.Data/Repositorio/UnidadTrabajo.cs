
using Proyecto1.Data.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Data.Repositorio //Changed namespace and removed old models imports and unnecessary implementations - Sábado 14
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        //public IBodegaRepositorio Bodega { get; private set; } - Commented as it is not necessary - Sábado 14
        public ICategoriaRepositorio Categoria { get; set; }
        public IMarcaRepositorio Marca { get; set; }

        public IProductoRepositorio Producto {get; set; }

        public IUsuarioAplicacionRepositorio UsuarioAplicacion {get; private set; }

        //public ICompaniaRepositorio Compania { get; private set; } //ADDED COMPANIA - Commented as it is not necessary - Sábado 14

        //public IProveedorRepositorio Proveedor { get; set; } //INSTANCIA DE PROVEEDOR EXAMEN - Commented as it is not necessary - Sábado 14

        //public IExamenRepositorio Examen { get; set; } //INSTANCIA DE PROVEEDOR EXAMEN 2.0 - Commented as it is not necessary - Sábado 14

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            //Bodega = new BodegaRepositorio(_db); //inicializamos unidad Bodega - Commented as it is not necessary - Sábado 14
            Categoria = new CategoriaRepositorio(_db); //inicializamos Categoria
            Marca = new MarcaRepositorio(_db); //inicializamos Marca
            Producto = new ProductoRepositorio(_db); //inicializamos Producto
            UsuarioAplicacion = new UsuarioAplicacionRepositorio(_db);
            //Compania = new CompaniaRepositorio(_db); //ADDED COMPANIA - Commented as it is not necessary - Sábado 14
            //Proveedor = new ProveedorRepositorio(_db); //ADDED PROVEEDOR EXAMEN - Commented as it is not necessary - Sábado 14
            //Examen = new ExamenRepositorio(_db); //AÑADI PROVEEDOR EXAMEN 2.0 - Commented as it is not necessary - Sábado 14
        }
        public void Guardar()
        {
            _db.SaveChanges();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
