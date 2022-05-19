
using Proyecto1.Data.Repositorio.IRepositorio;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Data.Repositorio //Changed namespace and removed old models import - Sábado 14
{
    public class UsuarioAplicacionRepositorio : Repositorio<UsuarioAplicacion>,
                                                IUsuarioAplicacionRepositorio
    {
        private readonly ApplicationDbContext _db;
        public UsuarioAplicacionRepositorio(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
    }
}
