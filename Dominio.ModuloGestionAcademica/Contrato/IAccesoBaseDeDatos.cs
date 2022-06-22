using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModuloGestionAcademica.Contrato
{
    public interface IAccesoBaseDeDatos
    {
        void AbrirConexion();
        void CerrarConexion();
        void CancelarTransaccion();
        void IniciarTransaccion();
        void TerminarTransaccion();
    }
}
