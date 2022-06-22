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
    public class ProcesarRegistroDeNotasServicio
    {
        private Evaluacion evaluacion;
        private IAccesoBaseDeDatos accesoSQLServer;
        private IProductoAcademicoPersistencia productoAcademicoDAO;
        private IAlumnoPersistencia alumnoDAO;
        private IEvaluacionPersistencia evaluacionDAO;
        private IClasePersistencia claseDAO;
        private IDocentePersistencia docentePersistencia;
        private ICursoPersistencia cursoPersistencia;

        public Evaluacion Evaluacion { get => evaluacion; set => evaluacion = value; }

        public ProcesarRegistroDeNotasServicio()
        {
            evaluacion = new Evaluacion();
            FabricaAbstractaDePersistencia fabrica = FabricaAbstractaDePersistencia.CrearInstancia();
            accesoSQLServer = fabrica.CrearGestorAccesoDeDatos();
            productoAcademicoDAO = fabrica.CrearProductoAcademicoPersistencia(accesoSQLServer);
            alumnoDAO = fabrica.CrearAlumnoPersistencia(accesoSQLServer);
            evaluacionDAO = fabrica.CrearEvaluacionPersistencia(accesoSQLServer);
            claseDAO = fabrica.CrearClasePersistencia(accesoSQLServer);
            docentePersistencia = fabrica.CrearDocentePersistencia(accesoSQLServer);
            cursoPersistencia = fabrica.CrearCursoPersistencia(accesoSQLServer);
        }

        //REGLAS DE NEGOCIO
        public Alumno BuscarAlumno(int idAlumno)
        {
            accesoSQLServer.AbrirConexion();
            Alumno alumno = alumnoDAO.BuscarPorId(idAlumno);
            accesoSQLServer.CerrarConexion();
            return alumno;
        }

        public List<Alumno> BuscarAlumnos(string dniAlumno)
        {
            accesoSQLServer.AbrirConexion();
            List<Alumno> listaDeAlumnos = alumnoDAO.BuscarPorDni(dniAlumno);
            accesoSQLServer.CerrarConexion();
            return listaDeAlumnos;
        }

        public ProductoAcademico BuscarProductoAcademico(int idProductoAcademico)
        {
            accesoSQLServer.AbrirConexion();
            ProductoAcademico productoAcademico = productoAcademicoDAO.BuscarPorID(idProductoAcademico);
            accesoSQLServer.CerrarConexion();
            return productoAcademico;
        }

        public List<ProductoAcademico> BuscarProductosAcademicos(int idClase)
        {
            accesoSQLServer.AbrirConexion();
            List<ProductoAcademico> listaDeProductoAcademicos = productoAcademicoDAO.BuscarPorClase(idClase);
            accesoSQLServer.CerrarConexion();
            return listaDeProductoAcademicos;
        }

        public List<Clase> BuscarPorDocente(int idDocente)
        {
            accesoSQLServer.AbrirConexion();
            List<Clase> listaClases = claseDAO.BuscarPorDocente(idDocente);
            accesoSQLServer.CerrarConexion();
            return listaClases;
        }

        public Docente BuscarPorDocenteId(int idDocente)
        {
            accesoSQLServer.AbrirConexion();
            Docente docente = docentePersistencia.BuscarPorID(idDocente);
            accesoSQLServer.CerrarConexion();
            return docente;
        }

        public Curso BuscarPorCursoId(int cursoId)
        {
            accesoSQLServer.AbrirConexion();
            Curso curso = cursoPersistencia.BuscarPorID(cursoId);
            accesoSQLServer.CerrarConexion();
            return curso;
        }

        public int codigoClase(int claseID)
        {
            int codigo;
            accesoSQLServer.IniciarTransaccion();
            codigo = claseDAO.ObtenerCurso(claseID);
            accesoSQLServer.TerminarTransaccion();

            return codigo;
        }

        public List<Evaluacion> BuscarEvaluacionesProductoAcdemicoID(int idProductoAcademico)
        {
            accesoSQLServer.AbrirConexion();
            List<Evaluacion> listaEvaluaciones = evaluacionDAO.BuscarPorProductoAcademico(idProductoAcademico);
            accesoSQLServer.CerrarConexion();
            return listaEvaluaciones;
        }

        public int codigoAlumnoEvaluacion(int idEvaluacion)
        {
            int codigo;
            accesoSQLServer.IniciarTransaccion();
            codigo = evaluacionDAO.IdAlumnoEvaluacion(idEvaluacion);
            accesoSQLServer.TerminarTransaccion();

            return codigo;
        }

        public Alumno obtenerAlumno(int idAlumno)
        {
            accesoSQLServer.AbrirConexion();
            Alumno alumno = alumnoDAO.BuscarPorId(idAlumno);
            accesoSQLServer.CerrarConexion();
            return alumno;
        }

        public int codigoEvaluacion(string Nom, string ApllP, string AplliM, int pA)
        {
            int codigo;
            accesoSQLServer.IniciarTransaccion();
            codigo = evaluacionDAO.IDevaluNombreProAcad(Nom, ApllP, AplliM, pA);
            accesoSQLServer.TerminarTransaccion();

            return codigo;
        }

        public void actualizarNotas(float nota, int idEvaluacion)
        {
            accesoSQLServer.IniciarTransaccion();
            evaluacionDAO.actualizarNota(nota, idEvaluacion);
            accesoSQLServer.TerminarTransaccion();
        }
        /*public void GuardarRegistroDeNotas()
        {
            RegistroNotasServicio registroNotas = new RegistroNotasServicio();
            registroNotas.ValidarNota(evaluacion);
            accesoSQLServer.IniciarTransaccion();
            evaluacionDAO.Guardar(evaluacion);
            accesoSQLServer.TerminarTransaccion();
        }*/

    }
}
