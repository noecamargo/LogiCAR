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
        SubZona ObtenerSubZona(int id);
        Zona ObtenerZona(int id);
        bool QuitarVehiculoPatio(Patio patio, Guid VIN);
        int QuitarVehiculoSubZona(int idSubZona, Guid VIN);
        int SetearCapacidadSubZona(int idZona, int idSubZona, int capacidad);
        bool QuitarVehiculoPuerto(Puerto puerto, Guid VIN);
    }
}