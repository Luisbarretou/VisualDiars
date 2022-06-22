using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ModuloGestionAcademica.Contrato;
namespace Persistencia.Fabrica
{
    public abstract class FabricaAbstractaDePersistencia { 
    public static FabricaAbstractaDePersistencia CrearInstancia()
    {

        return new FabricaConcretaSqlServer();

    }
    public abstract IAccesoBaseDeDatos CrearGestorAccesoDeDatos();
    public abstract IAlumnoPersistencia CrearAlumnoPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos);

    public abstract IClasePersistencia CrearClasePersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos);

    public abstract IInscripcionPersistencia CrearInscripcionPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos);

    public abstract ICursoPersistencia CrearCursoPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos);

    public abstract IDocentePersistencia CrearDocentePersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos);

    public abstract IEvaluacionPersistencia CrearEvaluacionPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos);

    public abstract IProductoAcademicoPersistencia CrearProductoAcademicoPersistencia(IAccesoBaseDeDatos gestorAccesoBaseDeDatos);
    }
}

