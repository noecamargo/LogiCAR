using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LogiCAR.CapaAccesoDatos
{
    public class RepositorioPatio : IRepositorioPatio
    {
        #region Metodos de Zona
        public bool AltaZona(Zona zona)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {

                contexto.Zonas.Add(zona);
                return contexto.SaveChanges() > 0;
               
            }
        }
        public Zona ObtenerZona(int id)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Zonas
                    .Where(z => z.IdZona.Equals(id))
                    .FirstOrDefault();
            }
        }
        public bool ModificarZona(Zona zona)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Zona zonaResultado = contexto.Zonas.Where(z => z.IdZona.Equals(zona.IdZona)).FirstOrDefault();
                zonaResultado.Nombre = zona.Nombre;
                zonaResultado.SubZonas = zona.SubZonas;
                zonaResultado.Capacidad = zona.Capacidad;
                contexto.Entry(zonaResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// Retorna un diccionario conteniendo el id de subZona con los lugares disponible de la misma 
        /// </summary>
        public Dictionary<int, int> ConsultarZona(Zona zona)
        {
            Dictionary<int, int> retorno = new Dictionary<int, int>();
            foreach (var subZona in zona.SubZonas)
            {
                retorno.Add(subZona.IdSubZona, subZona.Disponible);
            };
            return retorno;
        }
        public bool BajaZona(int idZona)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Zona zonaResultado = contexto.Zonas.Where(z => z.IdZona.Equals(idZona)).FirstOrDefault();
                contexto.Zonas.Remove(zonaResultado);
                return contexto.SaveChanges() > 0;
            }
        }
        #endregion

        #region Metodos de SubZona
        public bool AltaSubZona(SubZona subZona)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                contexto.SubZonas.Add(subZona);
                return contexto.SaveChanges() > 0;
            }
        }
        public SubZona ObtenerSubZona(int id)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.SubZonas
                    .Where(z => z.IdSubZona.Equals(id))
                    .FirstOrDefault();
            }
        }
        public bool ModificarSubZona(SubZona subZona)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                SubZona subZonaResultado = contexto.SubZonas.Where(z => z.IdSubZona.Equals(subZona.IdSubZona)).FirstOrDefault();
                subZonaResultado.Nombre = subZona.Nombre;
                subZonaResultado.Capacidad = subZona.Capacidad;
                contexto.Entry(subZonaResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// Consulta SubZona
        /// </summary>
        /// <param name="IdSubZona"></param>
        /// <returns>Devuelve los lugares disponibles</returns>
        public int ConsultarSubZona(int IdSubZona)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                SubZona subZonaResultado = contexto.SubZonas.Where(z => z.IdSubZona.Equals(IdSubZona)).FirstOrDefault();
                return subZonaResultado.Disponible;
            }
        }
        /// <summary>
        /// Quita el vehiculo de la subZona e incrementa los lugares disponibles
        /// </summary>
        public int QuitarVehiculoSubZona(int idSubZona, Guid VIN)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                SubZona subZonaResultado = contexto.SubZonas.Where(z => z.IdSubZona.Equals(idSubZona)).FirstOrDefault();
                Vehiculo vehiculoResultado = subZonaResultado.Vehiculos.Where(v => v.VIN.Equals(VIN)).SingleOrDefault();
                subZonaResultado.Vehiculos.Remove(vehiculoResultado);
                subZonaResultado.Disponible++;
                contexto.Entry(subZonaResultado).State = System.Data.Entity.EntityState.Modified;
                contexto.Entry(vehiculoResultado).State = System.Data.Entity.EntityState.Modified;
                //return contexto.SaveChanges() > 0;
                return subZonaResultado.Disponible;
            }
        }
        /// <summary>
        /// Verifico que la capacidad maxima de las subZonas ya creadas no superen el maximo 
        /// si es asi, seteo la capacidad de mi nueva subzona
        /// </summary>
        /// <param name="idZona"></param>
        /// <param name="idSubZona"></param>
        /// <param name="capacidad"></param>
        /// <returns></returns>
        public int SetearCapacidadSubZona(int idZona, int idSubZona, int capacidad)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Zona zonaResultado = contexto.Zonas.Where(z => z.IdZona.Equals(idZona)).FirstOrDefault();
                SubZona subZonaResultado = contexto.SubZonas.Where(z => z.IdSubZona.Equals(idSubZona)).FirstOrDefault();
                int capacidadActual = 0;
                foreach (var subZona in zonaResultado.SubZonas)
                {
                    capacidadActual = subZona.Capacidad;
                }
                int capacidadDisponible = zonaResultado.Capacidad - capacidadActual;
                if (capacidadDisponible >= capacidad)
                {
                    subZonaResultado.Capacidad = capacidad;
                    contexto.Entry(subZonaResultado).State = System.Data.Entity.EntityState.Modified;

                }

                return capacidadDisponible;

            }
        }
        /// <summary>
        /// Al ser una composicion si la zona se queda sin subZonas debe dejar de existir
        /// </summary>
        public bool BajaSubZona(int idZona, int idSubZona)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Zona zonaResultado = contexto.Zonas.Where(z => z.IdZona.Equals(idZona)).FirstOrDefault();
                SubZona subZonaResultado = contexto.SubZonas.Where(s => s.IdSubZona.Equals(idSubZona)).FirstOrDefault();
                zonaResultado.SubZonas.Remove(subZonaResultado);
                contexto.Entry(zonaResultado).State = System.Data.Entity.EntityState.Modified;
                if (zonaResultado.SubZonas.Count == 0)
                    BajaZona(idZona);
                contexto.Entry(subZonaResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
        #endregion

        #region Metodos de Patio
        public bool AltaPatio(Patio patio)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                contexto.Patios.Add(patio);
                return contexto.SaveChanges() > 0;
            }
        }
        public bool ModificarPatio(Patio patio)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Patio patioResultado = contexto.Patios.Where(z => z.IdPatio.Equals(patio.IdPatio)).FirstOrDefault();
                patioResultado.Nombre = patio.Nombre;
                patioResultado.vehiculos = patio.vehiculos;
                contexto.Entry(patioResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
        public bool QuitarVehiculoPatio(Patio patio, Guid VIN)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Patio patioResultado = contexto.Patios.Where(z => z.IdPatio.Equals(patio.IdPatio)).FirstOrDefault();
                Vehiculo vehiculoResultado = contexto.Vehiculos.Where(v => v.VIN.Equals(VIN)).FirstOrDefault();
                patioResultado.vehiculos.Remove(vehiculoResultado);
                contexto.Entry(patioResultado).State = System.Data.Entity.EntityState.Modified;
                contexto.Entry(vehiculoResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
        #endregion

        #region Metodos de Puerto
        public bool AltaPuerto(Puerto puerto)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                contexto.Puertos.Add(puerto);
                return contexto.SaveChanges() > 0;
            }
        }
        public bool QuitarVehiculoPuerto(Puerto puerto, Guid VIN)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Puerto puertoResultado = contexto.Puertos.Where(p => p.IdPuerto.Equals(puerto.IdPuerto)).FirstOrDefault();
                Vehiculo vehiculoResultado = contexto.Vehiculos.Where(v => v.VIN.Equals(VIN)).FirstOrDefault();
                puertoResultado.Vehiculos.Remove(vehiculoResultado);
                contexto.Entry(puertoResultado).State = System.Data.Entity.EntityState.Modified;
                contexto.Entry(vehiculoResultado).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
        #endregion












    }
}
