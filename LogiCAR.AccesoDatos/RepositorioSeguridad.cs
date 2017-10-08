using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.CapaAccesoDatos
{
    public class RepositorioSeguridad : IRepositorioSeguridad
    {

        public Guid LogIn(string nombreUsuario, string contrasenia)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Guid token = Guid.Empty;
                try
                {
                    token = Guid.NewGuid();
                    Usuario usuario = new Usuario();
                    usuario.NombreUsuario = nombreUsuario;
                    usuario.Contrasenia = contrasenia;
                    usuario.Token = token;
                    contexto.Usuarios.Add(usuario);
                    contexto.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
               
               
                return token;
            }
        }

        public bool LogOff(string nombreUsuario)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Usuario usuarioLogueado = contexto.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).SingleOrDefault();
                usuarioLogueado.Token = Guid.Empty;
                contexto.Entry(usuarioLogueado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }

        }

        public bool AltaUsuario(Usuario usuario)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
               List<Usuario> listUsuarios = contexto.Usuarios.ToList();
                if (!(listUsuarios.Exists(u => u.NombreUsuario.Equals(usuario.NombreUsuario))))
                    contexto.Usuarios.Add(usuario);
                return contexto.SaveChanges() > 0;
            }

        }
        public bool ModificarUsuario(Usuario usuario)
        {
            using (var contexto = new RepositorioContext())
            {
                Usuario usuarioResultado = contexto.Usuarios.Where(u => u.NombreUsuario.Equals(usuario.NombreUsuario)).FirstOrDefault();
                usuarioResultado.Nombre = usuario.Nombre;
                usuarioResultado.Apellido = usuario.Apellido;
                usuarioResultado.Contrasenia = usuario.Contrasenia;
                usuarioResultado.Rol = usuario.Rol;
                usuarioResultado.Telefono = usuario.Telefono;
                usuarioResultado.Habilitado = usuario.Habilitado;
                contexto.Entry(usuarioResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges()>0;
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
                return contexto.Usuarios.ToList();
            }
        }
        public bool BajaUsuario(string nombreUsuario)
        {
            using (var contexto = new RepositorioContext())
            {
                Usuario usuarioResultado = contexto.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault();
                usuarioResultado.Habilitado = false;
                contexto.Entry(usuarioResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges()>0;
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
        public bool ModificarRol(Rol rol)
        {
            using (var contexto = new RepositorioContext())
            {
                Rol rolResultado = contexto.Roles.Where(r => r.Nombre.Equals(rol.Nombre)).FirstOrDefault();
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
        public bool AsignarFuncionalidad(string nombreRol, Funcionalidad funcionalidad)
        {
            using (var contexto = new RepositorioContext())
            {
                contexto.Roles.Where(r => r.Nombre.Equals(nombreRol)).FirstOrDefault().Permisos.Add(funcionalidad);
                return contexto.SaveChanges() > 0;
            }
        }
        public bool AsignarRol(string nombreUsuario, string nombreRol)
        {
            using (var contexto = new RepositorioContext())
            {
                Usuario usuarioResultado = contexto.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault();
                Rol rolResultado = contexto.Roles.Where(r => r.Nombre.Equals(nombreRol)).FirstOrDefault();
                usuarioResultado.Rol = rolResultado;
                contexto.Entry(usuarioResultado).State = System.Data.Entity.EntityState.Modified;
                contexto.Entry(rolResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }

              
       
      
    
             
    }
}
