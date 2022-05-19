using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Data.Repositorio.IRepositorio //Changed namespace and commented unnecessary implementations - Sábado 14
{
    public interface IUnidadTrabajo : IDisposable
    {
        //envolvemos todo lo necesario de todas las entidades del proyecto
        //Como un "Wrapper" ***TODO: Buscar ese concepto
        //Solo gets porque los metodos de actualizar no se dan en esta interfaz
        //Funcion guardar que solo existe acá

        //IBodegaRepositorio Bodega { get; } commented as it is not necessary - Sábado 14
        ICategoriaRepositorio Categoria { get; }
        IMarcaRepositorio Marca { get; }
        IProductoRepositorio Producto { get; }
        IUsuarioAplicacionRepositorio UsuarioAplicacion { get; }

        //ICompaniaRepositorio Compania { get; } Commented as it is not necessary - Sábado 14

        //IProveedorRepositorio Proveedor { get; } //INSTANCIA DE PROVEEDOR EXAMEN - Commented as it is not necessary - Sábado 14

        //IExamenRepositorio Examen { get; } //INSTANCIA DE PROVEEDOR EXAMEN 2.0 - Commented as it is not necessary - Sábado 14
        void Guardar();
    }
}
