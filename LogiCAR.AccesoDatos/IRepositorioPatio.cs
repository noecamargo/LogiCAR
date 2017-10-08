using System;
using System.Collections.Generic;
using LogiCAR.Entidades;

namespace LogiCAR.CapaAccesoDatos
{
    public interface IRepositorioPatio
    {
        bool AltaPatio(Patio patio);
        bool AltaPuerto(Puerto puerto);
        bool AltaSubZona(SubZona subZona);
        bool AltaZona(Zona zona);
        bool BajaSubZona(int idZona, int idSubZona);
        bool BajaZona(int idZona);
        int ConsultarSubZona(int IdSubZona);
        Dictionary<int, int> ConsultarZona(Zona zona);
        bool ModificarPatio(Patio patio);
        bool ModificarSubZona(SubZona subZona);
        bool ModificarZona(Zona zona);
        Patio ObtenerPatio();
        Puerto ObtenerPuerto();
        bool ModificarPuerto(List<Vehiculo> vehiculos); 
        SubZona ObtenerSubZona(int id);
        ICollection<SubZona> ObtenerSubZonas();
        Zona ObtenerZona(int id);
        ICollection<Zona> ObtenerZonas();
        bool QuitarVehiculoPatio(Patio patio, Guid VIN);
        bool QuitarVehiculoPuerto(Puerto puerto, Guid VIN);
        int QuitarVehiculoSubZona(int idSubZona, Guid VIN);
        int SetearCapacidadSubZona(int idZona, int idSubZona, int capacidad);
    }
}