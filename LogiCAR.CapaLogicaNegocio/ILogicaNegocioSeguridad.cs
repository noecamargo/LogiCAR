using LogiCAR.Entidades;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioSeguridad
    {
        void AltaFuncionalidad(string nombre);
        void AltaRol(string nombre);
        void AltaUsuario(Usuario usuario);
        void AsignarFuncionalidad(string nombreRol, string nombreFuncionalidad);
        void AsignarRol(string nombreUsuario, string nombreRol);
        IEnumerable<Funcionalidad> ObtenerFuncionalidades();
        IEnumerable<Rol> ObtenerRoles();
        IEnumerable<Usuario> ObtenerUsuarios();
    }
}