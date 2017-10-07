
using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Logi.CAR.WebApi.Controllers
{
    public class PuertoController : ApiController
    {
        private ILogicaNegocioPatio logicaNegocioPatio { get; set; }

        public PuertoController(ILogicaNegocioPatio logicaPatio)
        {
            logicaNegocioPatio = logicaPatio;
        }

        // GET: api/Puerto
        public IHttpActionResult Get()
        {
           Puerto puerto = logicaNegocioPatio.ObtenerPuerto();
            if (puerto == null)
            {
                return NotFound();
            }
            return Ok(puerto);

        }

       
        // PUT: api/Puerto/5
        public IHttpActionResult Put([FromBody]List<Vehiculo> vehiculos)
        {
            try
            {
                bool updateResult = logicaNegocioPatio.ModificarPuerto(vehiculos);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, vehiculos);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Puerto
        public IHttpActionResult Post([FromBody] Puerto puerto)
        {
            try
            {
                bool updateResult = logicaNegocioPatio.AltaPuerto(puerto);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, puerto);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
