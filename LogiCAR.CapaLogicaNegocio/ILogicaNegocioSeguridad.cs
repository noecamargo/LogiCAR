using LogiCAR.Entidades;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioSeguridad
    {
        bool AltaFuncionalidad(string nombre);
        bool AltaRol(Rol rol);
        int AltaUsuario(Usuario usuario);
        bool AsignarFuncionalidad(string nombreRol, string nombreFuncionalidad);
        bool AsignarRol(string nombreUsuario, string nombreRol);
        IEnumerable<Funcionalidad> ObtenerFuncionalidades();
        IEnumerable<Rol> ObtenerRoles();
        IEnumerable<Usuario> ObtenerUsuarios();
        Funcionalidad ObtenerFuncionalidad(string nombreFuncionalidad);
        Rol ObtenerRol(string nombreRol);
        Usuario ObtenerUsuario(string nombreUsuario);
        //void BajaRol(string nombre);
        bool BajaUsuario(string nombreUsuario);
        bool BajaFuncionalidad(string nombreFuncionalidad);
        bool ModificarRol(int id,Rol rol);
        bool ModificarUsuario(int id,Usuario nombreUsuario);
        bool ModificarFuncionalidad(string nombreFuncionalidad);

    }
}