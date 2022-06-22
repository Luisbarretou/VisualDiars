using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.EstrategiaFechaInscripcion;
using Dominio.ModuloGestionAcademica.EstrategiasConcretasFechaInscripcion;

namespace Dominio.ModuloGestionAcademica.Entidad
{
    public class Clase
    {
        private int idClase;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private string dias;
        private string horas;
        private int alumnosInscritos;
        private int cupos;
        private bool estado;
        private string salon;
        private Curso curso;
        private Docente docente;
        private List<ProductoAcademico> listaProductosAcademicos;
        private IEstrategiaValidarFechaInscripcion estrategiaValidarFechaInscripcion;
        
        public int IdClase { get => idClase; set => idClase = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string Dias { get => dias; set => dias = value; }
        public string Horas { get => horas; set => horas = value; }
        public int AlumnosInscritos { get => alumnosInscritos; set => alumnosInscritos = value; }
        public int Cupos { get => cupos; set => cupos = value; }
        public bool Estado { get => estado; set => estado = value; }
        public Curso Curso { get => curso; set => curso = value; }
        public Docente Docente { get => docente; set => docente = value; }
        public List<ProductoAcademico> ListaProductosAcademicos { get => listaProductosAcademicos; }
        public string Salon { get => salon; set => salon = value; }

        public Clase()
        {
            estrategiaValidarFechaInscripcion = new EstrategiaConcretaValidarFechaInscripcion();
        }


        //REGLAS DE NEGOCIO
        public double CalcularPromedio(Evaluacion evaluacion)//REVISAR
        {
            return listaProductosAcademicos[idClase].Peso * evaluacion.Nota;
        }

        public bool ClaseLlena()
        {
            if (cupos == 0)
            {
                return false;
            }
            return true;
        }

        public bool EstadoClase()
        {
            int fecha = DateTime.Compare(DateTime.Now , FechaFin.AddDays(7));
            if(cupos < 10 && fecha < 1)
            {
                return false;
            }
            return true;
        }

        

       /* public void CrearPA()
        {
            listaProductosAcademicos.Add(new ProductoAcademico(idClase)); //REVISAR
        }*/
    }
}
