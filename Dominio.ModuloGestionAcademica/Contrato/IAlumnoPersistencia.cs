using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;

namespace Dominio.ModuloGestionAcademica.Contrato
{
    public interface IAlumnoPersistencia
    {
        List<Alumno> BuscarPorDni(string Dni);
        Alumno BuscarPorId(int idAlumno);
    }
}
