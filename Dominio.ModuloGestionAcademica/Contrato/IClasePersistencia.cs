using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;

namespace Dominio.ModuloGestionAcademica.Contrato
{
    public interface IClasePersistencia
    {
        List<Clase> BuscarPorCurso(string nombreCurso);
        Clase BuscarPorID(int idClase);
        List<Clase> BuscarPorDocente(int idDocente);
        int ObtenerCurso(int idClase);
    }
}
