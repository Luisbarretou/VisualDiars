using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModuloGestionAcademica.Entidad
{
    public class Evaluacion
    {
        private int idEvaluacion;
        private double nota;
        private ProductoAcademico productoAcademico;
        private Alumno alumno;

        public int IdEvaluacion { get => idEvaluacion; set => idEvaluacion = value; }
        public double Nota { get => nota; set => nota = value; }
        public ProductoAcademico ProductoAcademico { get => productoAcademico; set => productoAcademico = value; }
        public Alumno Alumno { get => alumno; set => alumno = value; }


        //REGLAS DE NEGOCIO
        public bool NotaAprobada()
        {
            //AUN ESTA EN DEBATE
            return false;
        }

        public bool ValidarNota(Evaluacion evaluacion)
        {
            if(nota < 0 || nota >20)
            {
                return false;
            }
            return true;
        }
    }
}
