using System.Collections.Generic;
using LogiCAR.Entidades;
using System;

namespace LogiCAR.CapaAccesoDatos
{
    public interface IRepositorioSeguridad
    {
        Guid LogIn(string nombreUsuario, string contrasenia);
        bool LogOff(string nombreUsuario);
        bool AltaFuncionalidad(Funcionalidad funcionalidad);
        bool AltaRol(Rol rol);
        int AltaUsuario(Usuario usuario);
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
        bool ModificarRol(int Id,Rol rol);
        bool ModificarUsuario(int id,Usuario usuario);
        bool ModificarFuncionalidad(string nombreFuncionalidad);
        Rol ObtenerRolPorId(int idRol);
    }
}