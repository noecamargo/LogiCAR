using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.AccesoDatos
{
    public class RepositorioSeguridad : IRepositorioSeguridad
    {
        private static RepositorioContext contexto = new RepositorioContext();

        public RepositorioSeguridad()
        {
        }

        public bool AltaUsuario(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            return contexto.SaveChanges() > 0;
        }
        public bool AltaFuncionalidad(Funcionalidad funcionalidad)
        {
            contexto.Funcionalidades.Add(funcionalidad);
            return contexto.SaveChanges() > 0;
        }
        public bool AltaRol(Rol rol)
        {
            contexto.Roles.Add(rol);
            return contexto.SaveChanges() > 0;
        }
        public bool AsignarFuncionalidad(Rol rol, Funcionalidad funcionalidad)
        {
            contexto.Roles.Where(r => r.Nombre.Equals(rol.Nombre)).FirstOrDefault().Permisos.Add(funcionalidad);
            return contexto.SaveChanges() > 0;
        }

        public bool AsignarRol(string nombreUsuario, Rol rol)
        {
            contexto.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault().Rol = rol;
            return contexto.SaveChanges() > 0;
        }
        public ICollection<Usuario> ObtenerUsuarios()
        {
            return contexto.Usuarios.ToList();
        }
        public ICollection<Rol> ObtenerRoles()
        {
            return contexto.Roles.ToList();
        }
        public ICollection<Funcionalidad> ObtenerFuncionalidades()
        {
            return contexto.Funcionalidades.ToList();
        }
    }
}
