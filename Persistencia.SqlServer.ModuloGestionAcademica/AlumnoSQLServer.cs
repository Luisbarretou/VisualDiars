using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio.ModuloGestionAcademica.Entidad;
using Dominio.ModuloGestionAcademica.Contrato;
using Persistencia.SqlServer.ModuloBase;

namespace Persistencia.SqlServer.ModuloGestionAcademica
{
    public class AlumnoSQLServer : IAlumnoPersistencia
    {
        private AccesoSQLServer gestorSQL;

        public AlumnoSQLServer (IAccesoBaseDeDatos gestorSQL)
        {
            this.gestorSQL = (AccesoSQLServer)gestorSQL;
        }

        public List<Alumno> BuscarPorDni(string Dni)
        {
            List<Alumno> listaAlumnos = new List<Alumno>();
            Alumno alumno;
            
            string consultaSQL = "select * from Alumno where DNI like '%" + Dni + "%' ";

            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);
                while (resultadoSQL.Read())
                {
                    alumno = ObtenerAlumno(resultadoSQL);
                    listaAlumnos.Add(alumno);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return listaAlumnos;
        }

        public Alumno BuscarPorId(int idAlumno)
        {
            Alumno alumno;
            string consultaSQL = "select * from Alumno where AlumnoID = " + idAlumno + "";

            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);

                if(resultadoSQL.Read())
                {
                    alumno = ObtenerAlumno(resultadoSQL);
                }
                else
                {
                    throw new Exception("No existe el alumno");
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return alumno;
        }

        public Alumno ObtenerAlumno(SqlDataReader resultadoSQL)
        {
            Alumno alumno = new Alumno();

            alumno.IdAlumno = resultadoSQL.GetInt32(0);
            alumno.DNI1 = resultadoSQL.GetString(4);
            alumno.ApellidoPaterno = resultadoSQL.GetString(2);
            alumno.ApellidoMaterno = resultadoSQL.GetString(3);
            alumno.Nombres1 = resultadoSQL.GetString(1);
            alumno.FechaNacimiento = resultadoSQL.GetDateTime(5);
            alumno.Genero = resultadoSQL.GetString(6);
            alumno.Telefono = resultadoSQL.GetString(7);

            return alumno;
        }
    }
}
