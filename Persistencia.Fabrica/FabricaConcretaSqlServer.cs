using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Contrato;
using Persistencia.SqlServer.ModuloBase;
using Persistencia.SqlServer.ModuloGestionAcademica;

namespace Persistencia.Fabrica
{
    public class FabricaConcretaSqlServer : FabricaAbstractaDePersistencia
    {
        public override IAlumnoPersistencia CrearAlumnoPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos)
        {
            return new AlumnoSQLServer(gestorAccesoBaseDeDatos);
        }

        public override IClasePersistencia CrearClasePersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos)
        {
            return new ClaseSQLServer(gestorAccesoBaseDeDatos);
        }

        public override ICursoPersistencia CrearCursoPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos)
        {
            return new CursoSQLServer(gestorAccesoBaseDeDatos);
        }

        public override IDocentePersistencia CrearDocentePersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos)
        {
            return new DocenteSQLServer(gestorAccesoBaseDeDatos);
        }

        public override IEvaluacionPersistencia CrearEvaluacionPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos)
        {
            return new EvaluacionSQLServer(gestorAccesoBaseDeDatos);
        }

        public override IAccesoBaseDeDatos CrearGestorAccesoDeDatos()
        {
            return new AccesoSQLServer();
        }

        public override IInscripcionPersistencia CrearInscripcionPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos)
        {
            return new InscripcionSQLServer(gestorAccesoBaseDeDatos);
        }

        public override IProductoAcademicoPersistencia CrearProductoAcademicoPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos)
        {
            return new ProductoAcademicoSQLServer(gestorAccesoBaseDeDatos);
        }
    }
}
