using System.Collections.Generic;
using LogiCAR.Entidades;

namespace LogiCAR.CapaAccesoDatos
{
    public interface IRepositorioSeguridad
    {
        bool AltaFuncionalidad(Funcionalidad funcionalidad);
        bool AltaRol(Rol rol);
        bool AltaUsuario(Usuario usuario);
        bool AsignarFuncionalidad(Rol rol, Funcionalidad funcionalidad);
        bool AsignarRol(string nombreUsuario, Rol rol);
        ICollection<Funcionalidad> ObtenerFuncionalidades();
        ICollection<Rol> ObtenerRoles();
        ICollection<Usuario> ObtenerUsuarios();
    }
}