using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModuloGestionAcademica.Entidad
{
    public class ProductoAcademico
    {
        private int idProductoAcademico;
        private string nombre;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private double peso;

        public int IdProductoAcademico { get => idProductoAcademico; set => idProductoAcademico = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Peso { get => peso; set => peso = value; }

        //REGLAS DE NEGOCIO
        public bool ValidarFechaLimite()
        {
            DateTime fecha = DateTime.Now;
            if (fecha <= fechaFin && fecha >= fechaInicio)
            {
                return true;
            }
            return false;
        }
    }
}
