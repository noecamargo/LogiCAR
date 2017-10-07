using LogiCAR.AccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;


namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioLote : ILogicaNegocioLote
    {
        private IRepositorioLote respositorioLote;

        public LogicaNegocioLote(IRepositorioLote respositorio)
        {
            this.respositorioLote = respositorio;
        }

        public LogicaNegocioLote()
        {
            this.respositorioLote = new RepositorioLote();
        }

        public long CrearLote(Lote lote)
        {
            ValidacionCrearEditarLote(lote);
            return respositorioLote.InsertarLote(lote);
        }

        private void ValidacionCrearEditarLote(Lote lote)
        {
            if(lote.Vehiculos.Count == 0)
                throw new ArgumentNullException("El lote debe tener almenos un Vehiculo");
        }

        public Lote ObtenerLote(long id)
        {
            return respositorioLote.ObtenerLote(id);
        }

        public IEnumerable<Lote> ObtenerLotes()
        {
            return respositorioLote.ObtenerLotes();
        }

        public bool ActualizarLote(long id, Lote lote)
        {
            ValidacionCrearEditarLote(lote);
            return respositorioLote.ActualizarLote(id, lote);
        }

        public bool AgregarVehiculosALote(long id, List<Vehiculo> vehiculos)
        {
            Lote loteViejo = ObtenerLote(id);
            
            foreach (Vehiculo vehiculo in vehiculos)
            {
                if (!loteViejo.Vehiculos.Exists(v => v.VIN.Equals(vehiculo.VIN)))
                {
                    loteViejo.Vehiculos.Add(vehiculo);
                    respositorioLote.ActualizarLote(id, loteViejo);
                    
                }
            }

            return true;
        }


    }
}