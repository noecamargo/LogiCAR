using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.CapaAccesoDatos
{
    public class RepositorioSeguridad : IRepositorioSeguridad
    {
        //private static RepositorioContext contexto = new RepositorioContext();

        public RepositorioSeguridad()
        {
        }

        public bool AltaUsuario(Usuario usuario)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                contexto.Usuarios.Add(usuario);
                return contexto.SaveChanges() > 0;
            }
           
        }
        public bool AltaFuncionalidad(Funcionalidad funcionalidad)
        {
            using (var contexto = new RepositorioContext())
            {
                contexto.Funcionalidades.Add(funcionalidad);
                return contexto.SaveChanges() > 0;
            }
        }
        public bool AltaRol(Rol rol)
        {
            using (var contexto = new RepositorioContext())
            {
                contexto.Roles.Add(rol);
                return contexto.SaveChanges() > 0;
            }
        }
        public bool AsignarFuncionalidad(Rol rol, Funcionalidad funcionalidad)
        {
            using (var contexto = new RepositorioContext())
            {
                contexto.Roles.Where(r => r.Nombre.Equals(rol.Nombre)).FirstOrDefault().Permisos.Add(funcionalidad);
                return contexto.SaveChanges() > 0;
            }
        }

        public bool AsignarRol(string nombreUsuario, Rol rol)
        {
            using (var contexto = new RepositorioContext())
            {
                contexto.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault().Rol = rol;
                return contexto.SaveChanges() > 0;
            }
        }
        public ICollection<Usuario> ObtenerUsuarios()
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Usuarios.ToList();
            }
        }
        public ICollection<Rol> ObtenerRoles()
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Roles.ToList();
            }
        }
        public ICollection<Funcionalidad> ObtenerFuncionalidades()
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Funcionalidades.ToList();
            }
        }
    }
}
