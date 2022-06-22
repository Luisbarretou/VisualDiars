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
    public class ClaseSQLServer : IClasePersistencia
    {
        private AccesoSQLServer gestorSQL;

        public ClaseSQLServer (IAccesoBaseDeDatos gestorSQL)
        {
            this.gestorSQL = (AccesoSQLServer)gestorSQL;
        }

        public List<Clase> BuscarPorCurso(string nombreCurso)
        {
            List<Clase> listaClases = new List<Clase>();
            Clase clase;
            string consultaSQL;
            if (nombreCurso == null)
            {
                consultaSQL = "select * from Clase";
            }
            else
            {
                //consultaSQL = "SELECT Clase.ClaseID, Clase.Fechainicio, Clase.Fechafin, Clase.Dias, Clase.Hora, Clase.Salon, Clase.Cupos,Docente.Apellidopaterno,Docente.Apellidomaterno,Curso.Area, Curso.Nombre, Curso.CursoID FROM Clase inner join Curso on Clase.ClaseID = Curso.CursoID inner join Docente on Clase.DocenteID = Docente.DocenteID where Clase.CursoID in (select CursoID from Curso where Nombre like '%" + nombre + "%') and cupos > 0";
                consultaSQL = "select * from Clase where CursoID in (select CursoID from Curso where Nombre like '%" + nombreCurso + "%')";
            }
            
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);
                while (resultadoSQL.Read())
                {
                    clase = ObtenerClase(resultadoSQL);
                    listaClases.Add(clase);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return listaClases;
        }

        public List<Clase> BuscarPorDocente(int idDocente)
        {
            List<Clase> listaClases = new List<Clase>();
            Clase clase;
            string consultaSQL;
            string id = Convert.ToString(idDocente);
            if (id == null)
            {
                consultaSQL = "select * from Clase";
            }
            else
            {
                consultaSQL = "select * from Clase where DocenteID = '" + idDocente + "'";
            }
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);
                while (resultadoSQL.Read())
                {
                    clase = ObtenerClase(resultadoSQL);
                    listaClases.Add(clase);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return listaClases;
        }

        public Clase BuscarPorID(int idClase)
        {
            Clase clase;
            string consultaSQL = "select * from Clase where ClaseID = " + idClase ;

            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);

                if (resultadoSQL.Read())
                {
                    clase = ObtenerClase(resultadoSQL);
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
            return clase;
        }

        public int ObtenerCurso(int idClase)
        {
            string consultaSQL = "select CursoID from Clase where ClaseID = " + idClase;
            int codigo;

            SqlCommand resultadoSQL = gestorSQL.ObtenerComandoSQL(consultaSQL);
            codigo = Convert.ToInt32(resultadoSQL.ExecuteScalar());

            return codigo;
        }

        public Clase ObtenerClase(SqlDataReader resultadoSQL)
        {
            Clase clase = new Clase();
            int docente = resultadoSQL.GetInt32(2);
            clase.IdClase = resultadoSQL.GetInt32(0);
            clase.FechaInicio = resultadoSQL.GetDateTime(3);
            clase.FechaFin = resultadoSQL.GetDateTime(4);
            clase.Dias = resultadoSQL.GetString(5);
            clase.Horas = resultadoSQL.GetString(6);
            clase.AlumnosInscritos = resultadoSQL.GetInt32(7);
            clase.Cupos = resultadoSQL.GetInt32(8);
            clase.Salon = resultadoSQL.GetString(10);

            return clase;
        }


    }
}
