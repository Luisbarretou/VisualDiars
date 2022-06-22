using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;

namespace Dominio.ModuloGestionAcademica.Servicio
{
    public class RegistroNotasServicio
    {
        public void ValidarNota(Evaluacion evaluacion)
        {
            if(!evaluacion.ValidarNota(evaluacion))
            {
                throw new Exception("Nota incorrecta");
            }
        }
    }
}
