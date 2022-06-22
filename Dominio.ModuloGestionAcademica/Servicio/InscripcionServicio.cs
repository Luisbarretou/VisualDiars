using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;

namespace Dominio.ModuloGestionAcademica.Servicio
{
    public class InscripcionServicio
    {
        //REGLAS DE NEGOCIO

        public void ValidarFechaLimiteInscripcion(Inscripcion inscripcion)
        {
            if(!inscripcion.ValidarFechaLimiteInscripcion(inscripcion))
            {
                throw new Exception("No se puede inscribir, porque la fecha de inscripción regular termino o no cumple con los requisitos para la inscripción extendida");
            }
        }
    }
}
