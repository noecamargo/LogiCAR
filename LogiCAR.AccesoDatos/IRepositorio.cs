﻿using LogiCAR.Entidades;
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

        bool InsertarInspeccion(Inspeccion inspeccion);

        Inspeccion ObtenerInspeccion(int id);

        IEnumerable<Inspeccion> ObtenerInspecciones();

        bool ActualizarInspeccion(int id, Inspeccion inspeccion);

    }
}
