using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Utilidades
{
    public static class Utilidades
    {

        public static Usuario CrearUsuarioFalso()
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = "Pedro";
            usuario.Apellido = "Perez";
            usuario.NombreUsuario = "pperez";
            usuario.Contrasenia = "peperez2015";
            usuario.Telefono = "27120515";
            usuario.Habilitado = true;
            return usuario;
        }
        public static IEnumerable<Usuario> CrearUsuariosDummy()
        {
            List<Usuario> retorno = new List<Usuario>();
            retorno.Add(CrearUsuarioFalso());
            Usuario usuario = new Usuario();
            usuario.Nombre = "Pablo";
            usuario.Apellido = "Jeres";
            usuario.NombreUsuario = "jj2017";
            usuario.Contrasenia = "jj2017";
            usuario.Telefono = "27120000";
            usuario.Habilitado = true;
            retorno.Add(usuario);
            return retorno;
        }

        public static IEnumerable<Rol> CrearRolesDummy()
        {
            return new List<Rol>
            {
                new Rol
                {
                    Nombre = "Admin"
                },
                new Rol
                {
                   Nombre = "Operario Patio"
                }
            };
        }
        public static IEnumerable<Funcionalidad> CrearFuncionalidadesDummy()
        {
            return new List<Funcionalidad>
            {
                new Funcionalidad
                {
                    Nombre = "Alta Zona"
                },
                new Funcionalidad
                {
                   Nombre = "Alta SubZona"
                }
            };
        }

        public static string CrearNombreUsuarioFalso()
        {
            return "vrodriguez";
        }
        public static Rol CrearRolFalso()
        {
            Rol rol = new Rol();
            rol.Nombre = "Admin";
            rol.Permisos = new List<Funcionalidad>();
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = "Alta Zona";
            rol.Permisos.Add(funcion);
            return rol;

        }
    }
}
