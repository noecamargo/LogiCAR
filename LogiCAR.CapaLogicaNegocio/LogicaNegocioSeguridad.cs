using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioSeguridad : ILogicaNegocioSeguridad
    {
        private IRepositorioSeguridad repositorioSeguridad;

        public LogicaNegocioSeguridad(IRepositorioSeguridad repository)
        {
            repositorioSeguridad = repository;
        }

        public bool AltaUsuario(Usuario usuario)
        {
            return repositorioSeguridad.AltaUsuario(usuario);
        }
        public bool ModificarUsuario(Usuario usuario)
        {
            return repositorioSeguridad.ModificarUsuario(usuario);
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

       
        public bool AltaRol(string nombre)
        {
            return repositorioSeguridad.AltaRol(new Rol(nombre));
        }
        public bool ModificarRol(Rol rol)
        {
            return repositorioSeguridad.ModificarRol(rol);
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
       
       
      



    }
}
