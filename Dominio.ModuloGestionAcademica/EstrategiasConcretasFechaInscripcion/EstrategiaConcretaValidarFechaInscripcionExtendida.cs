using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;
using Dominio.ModuloGestionAcademica.EstrategiaFechaInscripcion;

namespace Dominio.ModuloGestionAcademica.EstrategiasConcretasFechaInscripcion
{
    public class EstrategiaConcretaValidarFechaInscripcionExtendida : IEstrategiaValidarFechaInscripcion
    {
        public bool ValidarFechaLimiteInscripcion(Inscripcion inscripcion)
        {
            DateTime claseFechaExtendidad = inscripcion.Clase.FechaInicio;
            claseFechaExtendidad = claseFechaExtendidad.AddDays(7);
            int result1 = DateTime.Compare(inscripcion.Fecha, claseFechaExtendidad);
            int result2 = DateTime.Compare(inscripcion.Fecha, inscripcion.Clase.FechaInicio);
            Console.WriteLine(result1);
            bool comparacion1 = (result2 >= 1 && result1 < 0 && inscripcion.Clase.Cupos < 31) ? true : false;
            return comparacion1;
        }
    }
}
