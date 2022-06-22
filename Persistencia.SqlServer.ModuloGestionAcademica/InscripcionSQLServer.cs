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
    public class InscripcionSQLServer : IInscripcionPersistencia
    {
        private AccesoSQLServer gestorSQL;

        public InscripcionSQLServer(IAccesoBaseDeDatos gestorSQL)
        {
            this.gestorSQL = (AccesoSQLServer)gestorSQL;
        }

        public bool ValidarInscripcionClaseAlumno(Inscripcion inscripcion)
        {
            string obtenerInscripcion = "select count(*) from Inscripcion where AlumnoID = @AlumnoID and ClaseID = @ClaseID";
            int validar;

                SqlCommand funcion;

                funcion = gestorSQL.ObtenerComandoSQL(obtenerInscripcion);
                funcion.Parameters.AddWithValue("@AlumnoID", inscripcion.Alumno.IdAlumno);
                funcion.Parameters.AddWithValue("@ClaseID", inscripcion.Clase.IdClase);

                validar = Convert.ToInt32(funcion.ExecuteScalar());

            if (validar == 1)
            {
                return true;
            }

            return false;
        }

        public void Guardar(Inscripcion inscripcion)
        {
            string insertarInscripcionSQL, actualizarCuposClase, actualizarAlumnosInscritosClase;

            insertarInscripcionSQL = "insert into Inscripcion (InscripcionID, Fecha, AlumnoID, ClaseID)" + "values(@InscripcionID, @Fecha, @AlumnoID, @ClaseID)";
            actualizarCuposClase = "update Clase set Cupos = @Cupos where ClaseID = @ClaseID"; 
            actualizarAlumnosInscritosClase = "update Clase set AlumnosInscritos = @AlumnosInscritos where ClaseID = @ClaseID";
            
            try
            {
                SqlCommand comando;
                
                //Guandando inscripción
                comando = gestorSQL.ObtenerComandoSQL(insertarInscripcionSQL);
                comando.Parameters.AddWithValue("@InscripcionID", inscripcion.IdInscripcion);
                comando.Parameters.AddWithValue("@Fecha", inscripcion.Fecha);
                comando.Parameters.AddWithValue("@AlumnoID", inscripcion.Alumno.IdAlumno);
                comando.Parameters.AddWithValue("@ClaseID", inscripcion.Clase.IdClase);

                comando.ExecuteNonQuery();

                //Actualizando cupos de clase
                comando = gestorSQL.ObtenerComandoSQL(actualizarCuposClase);
                comando.Parameters.AddWithValue("@Cupos", inscripcion.ActualizarCupos());
                comando.Parameters.AddWithValue("@ClaseID", inscripcion.Clase.IdClase);

                comando.ExecuteNonQuery();

                //Actualizando alumnos inscritos a la clase
                comando = gestorSQL.ObtenerComandoSQL(actualizarAlumnosInscritosClase);
                comando.Parameters.AddWithValue("@AlumnosInscritos", inscripcion.ActualizarAlumnosInscritos());
                comando.Parameters.AddWithValue("@ClaseID", inscripcion.Clase.IdClase);

                comando.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Ocurrio un problema al intentar guardar,\nverifique que el número de la inscripcion no exista.", err);
            }
            
        }

        public int PosIdInscripcion()
        {
            string obtenerInscripcion = "select count(*) from Inscripcion";
            int pos;

            SqlCommand funcion;

            funcion = gestorSQL.ObtenerComandoSQL(obtenerInscripcion);
            pos = Convert.ToInt32(funcion.ExecuteScalar());

            return pos;
        }
    }
}
