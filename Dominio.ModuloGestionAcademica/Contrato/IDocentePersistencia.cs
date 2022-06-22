using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;

namespace Dominio.ModuloGestionAcademica.Contrato
{
    public interface IDocentePersistencia
    {
        List<Docente> BuscarPorClase(int idClase);

        Docente BuscarPorApellido(string apellidoDocente);

        Docente BuscarPorID(int idDocente);
    }
}
