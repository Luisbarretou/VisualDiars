using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Entidad;
using Dominio.ModuloGestionAcademica.Servicio;
using Persistencia.SqlServer.ModuloBase;
using Persistencia.SqlServer.ModuloGestionAcademica;
using Dominio.ModuloGestionAcademica.Contrato;
using Persistencia.Fabrica;

namespace Aplicacion.ModuloGestionAcademica.Servicio
{
    public class ProcesarInscripcionServicio
    {
        private Inscripcion inscripcion;
        private IAccesoBaseDeDatos accesoSQLServer;
        private IClasePersistencia claseDAO;
        private IAlumnoPersistencia alumnoDAO;
        private IInscripcionPersistencia inscripcionDAO;


        public Inscripcion Inscripcion { get =>inscripcion; set => inscripcion = value; }

        public ProcesarInscripcionServicio()
        {
            inscripcion = new Inscripcion();
            FabricaAbstractaDePersistencia fabrica = FabricaAbstractaDePersistencia.CrearInstancia();
            accesoSQLServer = fabrica.CrearGestorAccesoDeDatos();
            claseDAO = fabrica.CrearClasePersistencia(accesoSQLServer);
            alumnoDAO = fabrica.CrearAlumnoPersistencia(accesoSQLServer);
            inscripcionDAO = fabrica.CrearInscripcionPersistencia(accesoSQLServer);
        }

        //REGLAS DE NEGOCIO
        public List<Clase> BuscarClases(string nombreCurso)
        {
            accesoSQLServer.AbrirConexion();
            List<Clase> listaDeClases = claseDAO.BuscarPorCurso(nombreCurso);
            accesoSQLServer.CerrarConexion();
            return listaDeClases;
        }

        public Alumno BuscarAlumno(int idAlumno)
        {
            accesoSQLServer.AbrirConexion();
            Alumno alumno = alumnoDAO.BuscarPorId(idAlumno);
            accesoSQLServer.CerrarConexion();
            return alumno;
        }

        public Clase BuscarClase(int idClase)
        {
            accesoSQLServer.AbrirConexion();
            Clase clase = claseDAO.BuscarPorID(idClase);
            accesoSQLServer.CerrarConexion();
            return clase;
        }

        public List<Alumno > BuscarAlumnos(string dniAlumno)
        {
            accesoSQLServer.AbrirConexion();
            List<Alumno> listaDeAlumnos = alumnoDAO.BuscarPorDni(dniAlumno);
            accesoSQLServer.CerrarConexion();
            return listaDeAlumnos;
        }
        
        public bool ValidarInscripcionClaseAlumno()
        {
            bool validar;
            accesoSQLServer.IniciarTransaccion();
            validar = inscripcionDAO.ValidarInscripcionClaseAlumno(inscripcion);
            accesoSQLServer.TerminarTransaccion();

            return validar;
        }

        public void GuardarInscripcion()
        {
            
            InscripcionServicio registroInscripcion = new InscripcionServicio();
            
            if (ValidarInscripcionClaseAlumno() == true)
            {
                throw new Exception("El alumno ya se encuentra registrado en está clase.");
            }
            registroInscripcion.ValidarFechaLimiteInscripcion(inscripcion);
            accesoSQLServer.IniciarTransaccion();
            inscripcionDAO.Guardar(inscripcion);
            accesoSQLServer.TerminarTransaccion();
        }

        public int posCodigoInscripcion()
        {
            int posID;
            accesoSQLServer.IniciarTransaccion();
            posID = inscripcionDAO.PosIdInscripcion();
            accesoSQLServer.TerminarTransaccion();

            return posID + 1;
        }
    }
}
