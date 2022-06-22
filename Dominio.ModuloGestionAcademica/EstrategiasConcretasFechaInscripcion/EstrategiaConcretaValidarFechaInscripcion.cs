using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;
using Dominio.ModuloGestionAcademica.EstrategiaFechaInscripcion;

namespace Dominio.ModuloGestionAcademica.EstrategiasConcretasFechaInscripcion
{
    public class EstrategiaConcretaValidarFechaInscripcion : IEstrategiaValidarFechaInscripcion
    {
        public bool ValidarFechaLimiteInscripcion(Inscripcion inscripcion)
        {
            int result1 = DateTime.Compare(inscripcion.Fecha, inscripcion.Clase.FechaInicio);
            Console.WriteLine(result1);
            bool comparacion1 = (result1 < 0) ? true : false;
            return comparacion1;
        }
    }
}
