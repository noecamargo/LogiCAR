
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
    public class PatioController : ApiController
    {
        private ILogicaNegocioPatio logicaNegocioPatio { get; set; }

        public PatioController(ILogicaNegocioPatio logicaPatio)
        {
            logicaNegocioPatio = logicaPatio;
        }

        // GET: api/Patio
        public IHttpActionResult Get()
        {
           Patio patio = logicaNegocioPatio.ObtenerPatio();
            if (patio == null)
            {
                return NotFound();
            }
            return Ok(patio);

        }

       
        // PUT: api/Patio/5
        public IHttpActionResult Put([FromBody]Patio patio)
        {
            try
            {
                bool updateResult = logicaNegocioPatio.ModificarPatio(patio);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, patio);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Patio
        public IHttpActionResult Post([FromBody] Patio patio)
        {
            try
            {
                bool updateResult = logicaNegocioPatio.AltaPatio(patio);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, patio);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
