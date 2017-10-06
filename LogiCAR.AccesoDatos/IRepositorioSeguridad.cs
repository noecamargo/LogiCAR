using System.Collections.Generic;
using LogiCAR.Entidades;

namespace LogiCAR.CapaAccesoDatos
{
    public interface IRepositorioSeguridad
    {
        bool AltaFuncionalidad(Funcionalidad funcionalidad);
        bool AltaRol(Rol rol);
        bool AltaUsuario(Usuario usuario);
        bool AsignarFuncionalidad(string nombreRol, Funcionalidad funcionalidad);
        bool AsignarRol(string nombreUsuario, string nombreRol);
        ICollection<Funcionalidad> ObtenerFuncionalidades();
        ICollection<Rol> ObtenerRoles();
        ICollection<Usuario> ObtenerUsuarios();
        Funcionalidad ObtenerFuncionalidad(string nombreFuncionalidad);
        Rol ObtenerRol(string nombreRol);
        Usuario ObtenerUsuario(string nombreUsuario);
        //void BajaRol(string nombreRol);
        bool BajaUsuario(string nombreUsuario);
        bool BajaFuncionalidad(string nombreFuncionalidad);
        bool ModificarRol(Rol rol);
        bool ModificarUsuario(Usuario usuario);
        bool ModificarFuncionalidad(string nombreFuncionalidad);
    }
}