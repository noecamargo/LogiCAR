using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioSeguridad : ILogicaNegocioSeguridad
    {
        public LogicaNegocioSeguridad(IRepositorioSeguridad repository)
        {
            repositorioSeguridad = repository;
        }

        public void AltaUsuario(Usuario usuario)
        {
            repositorioSeguridad.AltaUsuario(usuario);
        }
        public void AltaFuncionalidad(string nombre)
        {
            repositorioSeguridad.AltaFuncionalidad(new Funcionalidad(nombre));
        }
        public void AltaRol(string nombre)
        {
            repositorioSeguridad.AltaRol(new Rol(nombre));
        }
        public void AsignarFuncionalidad(string nombreRol, string nombreFuncionalidad) { }
        public void AsignarRol(string nombreUsuario, string nombreRol) { }
        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            //contexto
            return new List<Usuario>();
        }
        public IEnumerable<Rol> ObtenerRoles()
        {
            return new List<Rol>();
            //contexto
        }
        public IEnumerable<Funcionalidad> ObtenerFuncionalidades()
        {
            return new List<Funcionalidad>();
            //contexto
        }
    }
}
