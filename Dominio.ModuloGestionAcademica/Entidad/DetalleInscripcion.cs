using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModuloGestionAcademica.Entidad
{
    public class DetalleInscripcion
    {
        Clase clase;

        public Clase Clase { get => clase; set => clase = value; }

        public DetalleInscripcion(Clase clase)
        {
            this.clase = clase;
        }

        public void ActualizarCupos()
        {
            Clase.LimiteCupos = clase.LimiteCupos - 1;
        }
    }
}
