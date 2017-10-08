using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogiCAR.AccesoDatos
{
    public class RepositorioVehiculo : IRepositorioVehiculo
    {
        public bool InsertarVehiculo(Vehiculo vehiculo)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {

                contexto.Vehiculos.Add(vehiculo);
                return contexto.SaveChanges() > 0;
            }

        }

        public Vehiculo ObtenerVehiculo(Guid VIN)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Vehiculos
                    .Where(v => v.VIN.Equals(VIN))
                    .FirstOrDefault();
            }
        }

        public ICollection<Vehiculo> ObtenerVehiculos()
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Vehiculos.ToList();
            }

        }

        public bool ActualizarVehiculo(Guid VIN, Vehiculo vehiculo)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Vehiculo vehiculoViejo = ObtenerVehiculo(VIN);
                if (vehiculo == null)
                {
                    return false;
                }
                vehiculoViejo.Anio = vehiculo.Anio;
                vehiculoViejo.Color = vehiculo.Color;
                vehiculoViejo.Marca = vehiculo.Marca;
                vehiculoViejo.Modelo = vehiculo.Modelo;
                vehiculoViejo.ProntoParaPartir = vehiculo.ProntoParaPartir;

                contexto.Entry(vehiculoViejo).State = System.Data.Entity.EntityState.Modified;
                int modificado = contexto.SaveChanges();

                if (vehiculoViejo.ProntoParaPartir != vehiculo.ProntoParaPartir)
                    VerifcarPartidaLote(vehiculo);

                return modificado > 0;
            }
        }

        public void VerifcarPartidaLote(Vehiculo vehiculo)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                
                var  loteARevisar = contexto.Lotes.Where(l => l.Id.Equals(vehiculo.lote.Id)).FirstOrDefault();

                foreach (var vehiculoRevisar in loteARevisar.Vehiculos)
                {
                    if (vehiculoRevisar.ProntoParaPartir == false)
                        return;
                }
                RepositorioLote lote = new RepositorioLote();
                loteARevisar.ProntoParaPartida = true;
                lote.ActualizarLote(loteARevisar.Id,loteARevisar);
            }
        }
    }
}
