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

        public void AltaUsuario(Usuario usuario)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
            }

        }
        public void ModificarUsuario(Usuario usuario)
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
                contexto.SaveChanges();
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
        public void BajaUsuario(string nombreUsuario)
        {
            using (var contexto = new RepositorioContext())
            {
                Usuario usuarioResultado = contexto.Usuarios.Where(u => u.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault();
                usuarioResultado.Habilitado = false;
                contexto.Entry(usuarioResultado).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
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
        public void ModificarFuncionalidad(string nombreFuncionalidad)
        {
            using (var contexto = new RepositorioContext())
            {
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
        public void BajaFuncionalidad(string nombreFuncionalidad) { }
        public bool AltaRol(Rol rol)
        {
            using (var contexto = new RepositorioContext())
            {
                contexto.Roles.Add(rol);
                return contexto.SaveChanges() > 0;
            }
        }
        public void ModificarRol(Rol rol)
        {
            using (var contexto = new RepositorioContext())
            {
                Rol rolResultado = contexto.Roles.Where(r => r.Nombre.Equals(rol.Nombre)).FirstOrDefault();
                rolResultado.Nombre = rol.Nombre;
                rolResultado.Permisos = rol.Permisos;
                contexto.Entry(rolResultado).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
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
        //public void BajaRol(string nombreRol)
        //{
        //    using (var contexto = new RepositorioContext())
        //    {
        //        AlumnoSeleccionado.EstudiosEntity.Clear();
        //        Contexto.SaveChanges();
        //    }
        //}
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
