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
    public class EvaluacionSQLServer : IEvaluacionPersistencia
    {
        private AccesoSQLServer gestorSQL;

        public EvaluacionSQLServer(IAccesoBaseDeDatos gestorSQL)
        {
            this.gestorSQL = (AccesoSQLServer)gestorSQL;
        }

        public List<Evaluacion> BuscarPorProductoAcademico(int idProductoAcademico)
        {
            List<Evaluacion> listaEvaluaciones = new List<Evaluacion>();
            Evaluacion evaluacion;
            string consultaSQL;

            consultaSQL = "select E.EvaluacionID, E.Nota from Evaluacion E inner join Alumno A on A.AlumnoID = E.AlumnoID where ProductoacademicoID =" + idProductoAcademico + "order by A.Nombres";



            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);
                while (resultadoSQL.Read())
                {
                    evaluacion = ObtenerEvaluacion(resultadoSQL);
                    listaEvaluaciones.Add(evaluacion);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return listaEvaluaciones;
        }

        public Evaluacion BuscarPorID(int idEvaluacion)
        {
            Evaluacion evaluacion;
            string consultaSQL = "select * from Evaluacion where EvaluacionID =" + idEvaluacion;
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);

                if (resultadoSQL.Read())
                {
                    evaluacion = ObtenerEvaluacion(resultadoSQL);
                }
                else
                {
                    throw new Exception("No existe la evaluacion");
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return evaluacion;
        }

         public int IdAlumnoEvaluacion(int idEvaluacion)
        {
            string obtenerIdAlumno = "select AlumnoID from Evaluacion where EvaluacionID =" + idEvaluacion;
            int id;

            SqlCommand funcion;

            funcion = gestorSQL.ObtenerComandoSQL(obtenerIdAlumno);
            id = Convert.ToInt32(funcion.ExecuteScalar());

            return id;
        }

        public int IDevaluNombreProAcad(string Nom, string ApllP, string AplliM, int prodAcademico)
        {
            int IDalumno;
            string consultaSQL = "select EvaluacionID from Evaluacion E inner join Alumno A on A.AlumnoID = E.AlumnoID where ProductoacademicoID = " + prodAcademico + " and Nombres ='" + Nom + "'and Apellidopaterno ='" + ApllP + "'and Apellidomaterno = '" + AplliM +"'";

            SqlCommand funcion;

            funcion = gestorSQL.ObtenerComandoSQL(consultaSQL);
            IDalumno = Convert.ToInt32(funcion.ExecuteScalar());

            return IDalumno;
        }
        //Actualizar
        public void actualizarNota(float nota, int idEvaluacion)
        {
            string insertarEvaluacion, actualizarEvaluacion;
            //insertarEvaluacion = "insert into Evaluacion (EvaluacionID, Nota, ProductoacademicoID)" + "values(@EvaluacionID, @Nota, @ProductoacademicoID";
            actualizarEvaluacion = "update Evaluacion set Nota =" + nota + "where EvaluacionID = " + idEvaluacion;
            
            try
            {
                SqlCommand comando;
                /*/Insertar
                comando = gestorSQL.ObtenerComandoSQL(insertarEvaluacion);
                comando.Parameters.AddWithValue("@EvaluacionID", evaluacion.IdEvaluacion);
                comando.Parameters.AddWithValue("@Nota", evaluacion.Nota);
                comando.Parameters.AddWithValue("@ProductoacademicoID", evaluacion.ProductoAcademico);
                comando.ExecuteNonQuery();
                /*/
                //Actualizar
                comando = gestorSQL.ObtenerComandoSQL(actualizarEvaluacion);
                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {

                throw new Exception("Ocurrio un problema al intentar guardar,\nverifique que el número de registro no exista.", err);
            }
        }

        public Evaluacion ObtenerEvaluacion(SqlDataReader resultadoSQL)
        {
            Evaluacion evaluacion = new Evaluacion();

            evaluacion.IdEvaluacion = resultadoSQL.GetInt32(0);
            evaluacion.Nota = resultadoSQL.GetFloat(1);
            return evaluacion;
        }
    }
}
