using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;

namespace Dominio.ModuloGestionAcademica.Contrato
{
    public interface IEvaluacionPersistencia
    {
        List<Evaluacion> BuscarPorProductoAcademico(int idProductoAcademico);

        Evaluacion BuscarPorID(int idEvaluacion);

        int IdAlumnoEvaluacion(int idEvaluacion);

        void actualizarNota(float nota, int idEvaluacion);

        int IDevaluNombreProAcad(string Nom, string ApllP, string AplliM, int prodAcademico);

    }
}
