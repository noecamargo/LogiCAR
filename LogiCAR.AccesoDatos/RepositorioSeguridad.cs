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
        public Guid LogIn(Usuario usuario)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                var usuarioObtenido = contexto.Usuarios.Where(u => u.NombreUsuario.Equals(usuario.NombreUsuario)).SingleOrDefault();
                usuario.Token = Guid.NewGuid();
                contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return usuario.Token;
            }
        }
        public bool LogOff(Guid token)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Usuario usuarioLogueado = contexto.Usuarios.Where(u => u.Token.Equals(token)).SingleOrDefault();
                usuarioLogueado.Token = Guid.Empty;
                contexto.Entry(usuarioLogueado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }

        }
        public int AltaUsuario(Usuario usuario,Guid token)
        {
           using (RepositorioContext contexto = new RepositorioContext())
            {
                contexto.Roles.Attach(usuario.Rol);
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
                return usuario.Id;
            }
        }
        public Usuario ObtenerUsuarioLogueado(Guid token)
        {
            Usuario usuarioLogueado = new Usuario();
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return usuarioLogueado = contexto.Usuarios.Where(u => u.Token.Equals(token)).SingleOrDefault();
            }
        }
        public bool NoEsAdministrador(Guid token)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                bool resultado = false;
                var usuarioLogueado = contexto.Usuarios.Where(u => u.Token.Equals(token)).SingleOrDefault();
                if (usuarioLogueado.Rol.Nombre != "ADMINISTRADOR")
                    resultado = true;
                return resultado;
            }
        }
        public List<Funcionalidad> FuncionalidadesAprobadas(Guid token)
        {
            List<Funcionalidad> funcionesPermitidas = new List<Funcionalidad>();
            Usuario usuarioLogueado = new Usuario();
            using (RepositorioContext contexto = new RepositorioContext())
            {
                usuarioLogueado = contexto.Usuarios.Where(u => u.Token.Equals(token)).SingleOrDefault();
                return usuarioLogueado.Rol.Permisos;
            }
        }
        public bool ModificarUsuario(int Id, Usuario usuario)
        {
            using (var contexto = new RepositorioContext())
            {
                Usuario usuarioResultado = contexto.Usuarios.Where(u => u.Id.Equals(usuario.Id)).FirstOrDefault();
                usuarioResultado.Nombre = usuario.Nombre;
                usuarioResultado.Apellido = usuario.Apellido;
                usuarioResultado.Contrasenia = usuario.Contrasenia;
                usuarioResultado.Rol = usuario.Rol;
                usuarioResultado.Telefono = usuario.Telefono;
                usuarioResultado.Habilitado = usuario.Habilitado;

                contexto.Entry(usuarioResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault();
            }
        }
        public ICollection<Usuario> ObtenerUsuarios()
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Usuarios.Include("Rol").ToList();
            }
        }
        public bool BajaUsuario(string nombreUsuario)
        {
            using (var contexto = new RepositorioContext())
            {
                Usuario usuarioResultado = contexto.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault();
                usuarioResultado.Habilitado = false;
                contexto.Entry(usuarioResultado).State = System.Data.Entity.EntityState.Modified;
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
        public bool ModificarFuncionalidad(string nombreFuncionalidad)
        {
            using (var contexto = new RepositorioContext())
            {
                return true;
            }
        }
        public Funcionalidad ObtenerFuncionalidad(string nombreFuncionalidad)
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Funcionalidades.Where(f => f.Nombre.Equals(nombreFuncionalidad)).FirstOrDefault();
            }
        }
        public ICollection<Funcionalidad> ObtenerFuncionalidades()
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Funcionalidades.ToList();
            }
        }
        public bool BajaFuncionalidad(string nombreFuncionalidad)
        {
            using (var contexto = new RepositorioContext())
            {
                Funcionalidad funcionRetorno = contexto.Funcionalidades.Where(f => f.Nombre.Equals(nombreFuncionalidad)).SingleOrDefault();
                contexto.Funcionalidades.Remove(funcionRetorno);
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
        public bool ModificarRol(int Id,Rol rol)
        {
            using (var contexto = new RepositorioContext())
            {
                Rol rolResultado = contexto.Roles.Where(r => r.Id.Equals(Id)).FirstOrDefault();
                rolResultado.Nombre = rol.Nombre;
                rolResultado.Permisos = rol.Permisos;
                contexto.Entry(rolResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
        public Rol ObtenerRol(string nombreRol)
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Roles.Where(r => r.Nombre.Equals(nombreRol)).FirstOrDefault();
            }
        }
        public ICollection<Rol> ObtenerRoles()
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Roles.ToList();
            }
        }
        public bool BajaRol(string nombreRol)
        {
            using (var contexto = new RepositorioContext())
            {
                Rol rolRetorno = contexto.Roles.Where(r => r.Nombre.Equals(nombreRol)).SingleOrDefault();
                contexto.Roles.Remove(rolRetorno);
                return contexto.SaveChanges() > 0;
            }
        }
        public bool AsignarFuncionalidad(int idRol, Funcionalidad funcionalidad)
        {
            using (var contexto = new RepositorioContext())
            {
                contexto.Roles.Where(r => r.Nombre.Equals(idRol)).FirstOrDefault().Permisos.Add(funcionalidad);
                return contexto.SaveChanges() > 0;
            }
        }
        public bool AsignarRol(string nombreUsuario, int idRol)
        {
            using (var contexto = new RepositorioContext())
            {
                Usuario usuarioResultado = contexto.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault();
                Rol rolResultado = contexto.Roles.Where(r => r.Id.Equals(idRol)).FirstOrDefault();
                usuarioResultado.Rol = rolResultado;
                contexto.Entry(usuarioResultado).State = System.Data.Entity.EntityState.Modified;
                contexto.Entry(rolResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }

        public Rol ObtenerRolPorId(int IdRol)
        {
            using (var contexto = new RepositorioContext())
            {
                return contexto.Roles.Where(r => r.Id.Equals(IdRol)).FirstOrDefault();
            }
        }
    }
}