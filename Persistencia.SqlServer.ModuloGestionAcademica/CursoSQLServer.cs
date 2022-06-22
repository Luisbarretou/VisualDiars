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
    public class CursoSQLServer : ICursoPersistencia
    {
        private AccesoSQLServer gestorSQL;

        public CursoSQLServer(IAccesoBaseDeDatos gestorSQL)
        {
            this.gestorSQL = (AccesoSQLServer)gestorSQL;
        }

        public Curso BuscarPorID(int CursoID)
        {
            Curso curso;

            string consultaSQL = "select * from Curso where CursoID  =" + CursoID;
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);
                if (resultadoSQL.Read())
                {
                    curso = ObtenerCurso(resultadoSQL);
                }
                else
                {
                    throw new Exception("No existe el docente.");
                }
            }
            catch (Exception err)
            {
                throw err;
                //throw new Exception("Ocurrio un problema al intentar guardar,inverifique que el número de venta no exista.", err);
            }
            return curso;
        }

        public Curso ObtenerCurso(SqlDataReader resultadoSQL)
        {
            Curso curso = new Curso();
            curso.IdCurso = resultadoSQL.GetInt32(0);
            curso.Nombre = resultadoSQL.GetString(1);
            curso.Area = resultadoSQL.GetString(2);

            return curso;
        }
    }
}
