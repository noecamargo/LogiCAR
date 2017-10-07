using System;
using System.Collections.Generic;
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
        public IHttpActionResult Get(Guid VIN)
        {
            Vehiculo vehiculo = logicaNegocioVehiculo.ObtenerVehiculo(VIN);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return Ok(vehiculo);
        }

        // PUT: api/Vehiculo/5
        [HttpPut]
        public IHttpActionResult Put(Guid VIN, [FromBody]Vehiculo vehiculo)
        {
            try
            {
                bool updateResult = logicaNegocioVehiculo.ActualizarVehiculo(VIN, vehiculo);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, vehiculo);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Vehiculo
        public IHttpActionResult Post([FromBody] Vehiculo vehiculo)
        {
            try
            {
                bool resultado = logicaNegocioVehiculo.CrearVehiculo(vehiculo);
                return CreatedAtRoute("DefaultApi", new { id = vehiculo.VIN }, vehiculo);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    // DELETE: api/Vehiculo/5
    //public void Delete(int id)
    //{
    //}
}

