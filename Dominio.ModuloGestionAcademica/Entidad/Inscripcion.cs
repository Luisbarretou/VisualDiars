using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.EstrategiaFechaInscripcion;
using Dominio.ModuloGestionAcademica.EstrategiasConcretasFechaInscripcion;

namespace Dominio.ModuloGestionAcademica.Entidad
{
    public class Inscripcion
    {
        private int idInscripcion;
        private DateTime fecha = DateTime.Now;
        private Alumno alumno;
        private Clase clase;
        private IEstrategiaValidarFechaInscripcion estrategiaValidarFechaInscripcion;

        public int IdInscripcion { get => idInscripcion; set => idInscripcion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Alumno Alumno { get => alumno; set => alumno = value; }
        public Clase Clase { get => clase; set => clase = value; }

        public Inscripcion()
        {
            estrategiaValidarFechaInscripcion = new EstrategiaConcretaValidarFechaInscripcion();
            //estrategiaValidarFechaInscripcion = new EstrategiaConcretaValidarFechaInscripcionExtendida();
        }
        
        public int ActualizarCupos()
        {
            return clase.Cupos = clase.Cupos - 1;
        }
        
        
        public int ActualizarAlumnosInscritos()
        {
            return clase.AlumnosInscritos = clase.AlumnosInscritos + 1;
        }
        
        public bool ValidarFechaLimiteInscripcion(Inscripcion inscripcion)
        {
            return estrategiaValidarFechaInscripcion.ValidarFechaLimiteInscripcion(this);
        }
    }
}