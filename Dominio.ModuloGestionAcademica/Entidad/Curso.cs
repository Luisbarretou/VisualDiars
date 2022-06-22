using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ModuloGestionAcademica.Entidad
{
    public class Curso
    {
        private int idCurso;
        private string area;
        private string nombre;

        public int IdCurso { get => idCurso; set => idCurso = value; }
        public string Area { get => area; set => area = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
