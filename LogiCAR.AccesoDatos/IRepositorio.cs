using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.AccesoDatos
{
    public interface IRepositorio
    {
        bool InsertarVehiculo(Vehiculo vehiculo);

        Vehiculo ObtenerVehiculo(Guid vIN);

        IEnumerable<Vehiculo> ObtenerVehiculos();

        bool ActualizarVehiculo(Guid VIN, Vehiculo vehiculo);

        int InsertarInspeccion(Inspeccion inspeccion);

        Inspeccion ObtenerInspeccion(int id);

        IEnumerable<Inspeccion> ObtenerInspecciones();

        bool ActualizarInspeccion(int id, Inspeccion inspeccion);

        int InsertarDanio(Danio danio);

        Danio ObtenerDanio(int id);

        IEnumerable<Danio> ObtenerDanios();

        bool ActualizarDanio(int id, Danio danio);

        long InsertarLote(Lote lote);

        Lote ObtenerLote(long id);

        IEnumerable<Lote> ObtenerLotes();

        bool ActualizarLote(long id, Lote lote);

        long InsertarTransporteLote(TransporteLote transporte);


        TransporteLote ObtenerTransporteLote(long id);

        IEnumerable<TransporteLote> ObtenerTransporteLotes();

        bool ActualizarTransporteLote(long id, TransporteLote transporte);
    }
}
