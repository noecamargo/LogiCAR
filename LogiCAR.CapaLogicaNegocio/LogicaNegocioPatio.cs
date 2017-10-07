using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioPatio
    {
        private IRepositorioPatio repositorioPatio;

        public LogicaNegocioPatio(IRepositorioPatio repositorio)
        {
            repositorioPatio = repositorio;
        }

        public bool AltaPatio(Patio patio)
        {
            return repositorioPatio.AltaPatio(patio);
        }
        public bool AltaPuerto(Puerto puerto)
        {
            return repositorioPatio.AltaPuerto(puerto);
        }
        public bool AltaSubZona(SubZona subZona)
        {
            return repositorioPatio.AltaSubZona(subZona);
        }
        public bool AltaZona(Zona zona)
        {
            return repositorioPatio.AltaZona(zona);
        }
        public bool BajaSubZona(int idZona, int idSubZona)
        {
            return repositorioPatio.BajaSubZona(idZona, idSubZona);
        }
        public bool BajaZona(int idZona)
        {
            return repositorioPatio.BajaZona(idZona);
        }
        public int ConsultarSubZona(int IdSubZona)
        {
            return repositorioPatio.ConsultarSubZona(IdSubZona);
        }
        public Dictionary<int, int> ConsultarZona(Zona zona)
        {
            return repositorioPatio.ConsultarZona(zona);
        }
        public bool ModificarPatio(Patio patio)
        {
            return repositorioPatio.ModificarPatio(patio);
        }
        public bool ModificarSubZona(SubZona subZona)
        {
            return repositorioPatio.ModificarSubZona(subZona);
        }
        public bool ModificarZona(Zona zona)
        {
            return repositorioPatio.ModificarZona(zona);
        }
        public SubZona ObtenerSubZona(int id)
        {
            return repositorioPatio.ObtenerSubZona(id);
        }
        public IEnumerable<SubZona> ObtenerSubZonas()
        {
            return repositorioPatio.ObtenerSubZonas();
        }
        public Zona ObtenerZona(int id)
        {
            return repositorioPatio.ObtenerZona(id);
        }
        public IEnumerable<Zona> ObtenerZonas()
        {
            return repositorioPatio.ObtenerZonas();
        }
        public Patio ObtenerPatio()
        {
            return repositorioPatio.ObtenerPatio();
        }
        public Puerto ObtenerPuerto()
        {
            return repositorioPatio.ObtenerPuerto();
        }
        bool ModificarPuerto(List<Vehiculo> vehiculos)
        {
            return repositorioPatio.ModificarPuerto(vehiculos);
        }
        public bool QuitarVehiculoPatio(Patio patio, Guid VIN)
        {
            return repositorioPatio.QuitarVehiculoPatio(patio, VIN);
        }
        public int QuitarVehiculoSubZona(int idSubZona, Guid VIN)
        {
            return repositorioPatio.QuitarVehiculoSubZona(idSubZona, VIN);
        }
        public int SetearCapacidadSubZona(int idZona, int idSubZona, int capacidad)
        {
            return repositorioPatio.SetearCapacidadSubZona(idZona, idSubZona, capacidad);
        }
        public bool QuitarVehiculoPuerto(Puerto puerto, Guid VIN)
        {
            return repositorioPatio.QuitarVehiculoPuerto(puerto, VIN);
        }
    }
}
