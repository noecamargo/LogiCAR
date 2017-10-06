﻿using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioLote
    {
        long CrearLote(Lote lote);
        Lote ObtenerLote(long id);
        IEnumerable<Lote> ObtenerLotes();
        bool ActualizarLote(long id, Lote lote);
    }
}