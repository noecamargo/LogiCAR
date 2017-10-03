using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;

namespace LogiCAR.WebApi.Controllers
{
    public class VehiculoController : ApiController
    {

        private ILogicaNegocioVehiculo logicaNegocioVehiculo { get; set; }

        public VehiculoController(ILogicaNegocioVehiculo logicaVehiculo)
        {
            logicaNegocioVehiculo = logicaVehiculo;
        }

        // GET: api/Vehiculo
        public IHttpActionResult Get()
        {
            IEnumerable<Vehiculo> vehiculos = logicaNegocioVehiculo.ListaVehiculos();
            if (vehiculos == null)
            {
                return NotFound();
            }
            return Ok(vehiculos);
            
        }

        // GET: api/Vehiculo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vehiculo
        //public void Post([FromBody]string value)
        //{
        //    logicaNegocioVehiculo.Post(value);
        //}

        // PUT: api/Vehiculo/5
        public void Put(int id, [FromBody]string value)
        {
            logicaNegocioVehiculo.Put(id, value);
        }

        // DELETE: api/Vehiculo/5
        public void Delete(int id)
        {
        }
    }
}
