using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;

namespace Dominio.ModuloGestionAcademica.EstrategiaFechaInscripcion
{
    public interface IEstrategiaValidarFechaInscripcion
    {
        bool ValidarFechaLimiteInscripcion(Inscripcion inscripcion);
    }
}
