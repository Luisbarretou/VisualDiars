using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModuloGestionAcademica.Entidad
{
    public class Alumno
    {
        private int idAlumno;
        private string Nombres;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string DNI;
        private DateTime fechaNacimiento;
        private string genero;
        private string telefono;

        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        public string DNI1 { get => DNI; set => DNI = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Nombres1 { get => Nombres; set => Nombres = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        

        //REGLAS DE NEGOCIO
        public bool ApruebaEvaluacion(Evaluacion evaluacion)
        {
            if(evaluacion.Nota >= 12)
            {
                return true;
            }
            return false;
        }
    }
}
