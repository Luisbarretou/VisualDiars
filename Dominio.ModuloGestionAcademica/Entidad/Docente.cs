using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModuloGestionAcademica.Entidad
{
    public class Docente
    {
        private int idDocente;
        private string nombre;
        private string apellidoPaterno; 
        private string apellidoMaterno;
        private string email;
        private string telefono;

        public int IdDocente { get => idDocente; set => idDocente = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
