using LogiCAR.Entidades;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioSeguridad
    {
        void AltaFuncionalidad(string nombre);
        void AltaRol(string nombre);
        void AltaUsuario(Usuario usuario);
        void AsignarFuncionalidad(string nombreRol, string nombreFuncionalidad);
        void AsignarRol(string nombreUsuario, string nombreRol);
        System.Collections.Generic.IEnumerable<Funcionalidad> ObtenerFuncionalidades();
        System.Collections.Generic.IEnumerable<Rol> ObtenerRoles();
        System.Collections.Generic.IEnumerable<Usuario> ObtenerUsuarios();
    }
}