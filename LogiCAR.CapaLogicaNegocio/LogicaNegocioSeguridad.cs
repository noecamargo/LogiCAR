using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioSeguridad : ILogicaNegocioSeguridad
    {
        private IRepositorioSeguridad repositorioSeguridad;

        public LogicaNegocioSeguridad(IRepositorioSeguridad repositorio)
        {
            repositorioSeguridad = repositorio;
        }

        public Guid LogIn(string nombreUsuario, string contrasenia)
        {
            //todo: validar usuario y contraseña 
            return repositorioSeguridad.LogIn(nombreUsuario, contrasenia);
        }
        public bool LogOff(string nombreUsuario)
        {
            return repositorioSeguridad.LogOff(nombreUsuario);
        }
        public int AltaUsuario(Usuario usuario)
        {
            validacionInsertarUsuario(usuario);
            return repositorioSeguridad.AltaUsuario(usuario);
        }
        public bool ModificarUsuario(int Id,Usuario usuario)
        {
            return repositorioSeguridad.ModificarUsuario(Id,usuario);
        }
        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            return repositorioSeguridad.ObtenerUsuario(nombreUsuario);
        }
        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return repositorioSeguridad.ObtenerUsuarios();
        }
        public bool BajaUsuario(string nombreUsuario)
        {
            return repositorioSeguridad.BajaUsuario(nombreUsuario);
        }

       
        public bool AltaRol(Rol rol)
        {
            validacionInsertarRol(rol);
            return repositorioSeguridad.AltaRol(rol);
        }

        private void validacionInsertarRol(Rol rol)
        {
            if (rol == null)
                throw new ArgumentNullException("El rol es vacio.");
            if (rol.Nombre == null)
                throw new ArgumentNullException("El rol debe tener un nombre.");
            if (ExisteRol(rol.Nombre))
                throw new Exception("El Rol ya existe en el sistema");
        }

        public bool ModificarRol(int Id,Rol rol)
        {
            return repositorioSeguridad.ModificarRol(Id,rol);
        }
        public bool BajaRol(string nombre)
        {
            return repositorioSeguridad.BajaFuncionalidad(nombre);
        }
        public Rol ObtenerRol(string nombreRol)
        {
            return repositorioSeguridad.ObtenerRol(nombreRol);
        }
        public IEnumerable<Rol> ObtenerRoles()
        {
            return repositorioSeguridad.ObtenerRoles();
        }
        public bool AsignarRol(string nombreUsuario, string nombreRol)
        {
            return repositorioSeguridad.AsignarRol(nombreUsuario, nombreRol);
        }

        public bool AltaFuncionalidad(string nombre)
        {
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = nombre;
            return repositorioSeguridad.AltaFuncionalidad(funcion);
        }
        public bool AsignarFuncionalidad(string nombreRol, string nombreFuncionalidad)
        {
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = nombreFuncionalidad;
            return repositorioSeguridad.AsignarFuncionalidad(nombreRol, funcion);
        }
        public IEnumerable<Funcionalidad> ObtenerFuncionalidades()
        {
            return repositorioSeguridad.ObtenerFuncionalidades();
        }
        public Funcionalidad ObtenerFuncionalidad(string nombreFuncionalidad)
        {
            return repositorioSeguridad.ObtenerFuncionalidad(nombreFuncionalidad);
        }
        public bool ModificarFuncionalidad(string nombreFuncionalidad)
        {
            return repositorioSeguridad.ModificarFuncionalidad(nombreFuncionalidad);
        }
        public bool BajaFuncionalidad(string nombreFuncionalidad)
        {
            return repositorioSeguridad.BajaFuncionalidad(nombreFuncionalidad);
        }

        private void validacionInsertarUsuario(Usuario usuario)
        {
            if (usuario.Nombre == null || usuario.Apellido == null || usuario.Contrasenia == null || usuario.NombreUsuario == null)
                throw new ArgumentNullException("Faltan datos necesarios para el usuario.");
            if (ExisteUsuario(usuario.NombreUsuario))
                throw new Exception("El usuario ya existe en el sistema");
            //if(ObtenerRolPorId(usuario.Rol.Id) == null)
            //    throw new Exception("El rol asignado para el usuario no existe en el sistema.");

        }

        private Rol ObtenerRolPorId(int IdRol)
        {
            return repositorioSeguridad.ObtenerRolPorId(IdRol);
        }

        private bool ExisteUsuario(string nombreUsuario)
        {
            return repositorioSeguridad.ObtenerUsuario(nombreUsuario) != null;
        }

        private bool ExisteRol(string nombreUsuario)
        {
            return repositorioSeguridad.ObtenerRol(nombreUsuario) != null;
        }






    }
}
