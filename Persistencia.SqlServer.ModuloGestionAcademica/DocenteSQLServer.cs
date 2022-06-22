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
    public class DocenteSQLServer : IDocentePersistencia
    {
        private AccesoSQLServer gestorSQL;

        public DocenteSQLServer(IAccesoBaseDeDatos gestorSQL)
        {
            this.gestorSQL = (AccesoSQLServer)gestorSQL;
        }

        public List<Docente> BuscarPorClase(int idClase)
        {
            List<Docente> listaDocentes = new List<Docente>();
            Docente docente;
            string consultaSQL;

            if (idClase == null)
            {
                consultaSQL = "select * from Docente";
            }
            else
            {
                 consultaSQL = "select * from Docente where ClaseID in (select ClaseID from Clase where ClaseID=" + idClase;
            }

            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);
                while (resultadoSQL.Read())
                {
                    docente = ObtenerDocente(resultadoSQL);
                    listaDocentes.Add(docente);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return listaDocentes;
        }

        public Docente BuscarPorApellido(string apellidoDocente)
        {
            Docente docente;

            string consultaSQL = "select * from Docente where Apellidopaterno  ="+ apellidoDocente;
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);
                if (resultadoSQL.Read())
                {
                    docente = ObtenerDocente(resultadoSQL);
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
            return docente;
        }

        public Docente BuscarPorID(int idDocente)
        {
            Docente docente;

            string consultaSQL = "select * from Docente where DocenteID  =" + idDocente;
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.EjecutarConsulta(consultaSQL);
                if (resultadoSQL.Read())
                {
                    docente = ObtenerDocente(resultadoSQL);
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
            return docente;
        }

        public Docente ObtenerDocente(SqlDataReader resultadoSQL)
        {
            Docente docente = new Docente();

            docente.IdDocente = resultadoSQL.GetInt32(0);
            docente.Nombre = resultadoSQL.GetString(1);
            docente.ApellidoPaterno = resultadoSQL.GetString(2);
            docente.ApellidoMaterno = resultadoSQL.GetString(3);
            docente.Email = resultadoSQL.GetString(4);
            docente.Telefono = resultadoSQL.GetString(5);

            return docente;
        }
    }
}
