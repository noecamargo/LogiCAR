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
    public class ZonaController : ApiController
    {
        private ILogicaNegocioPatio logicaNegocioPatio { get; set; }

        public ZonaController(ILogicaNegocioPatio logicaPatio)
        {
            logicaNegocioPatio = logicaPatio;
        }

        // GET: api/Zona
        public IHttpActionResult Get()
        {
            IEnumerable<Zona> zonas = logicaNegocioPatio.ObtenerZonas();
            if (zonas == null)
            {
                return NotFound();
            }
            return Ok(zonas);

        } 

        // GET: api/Zona/5
        public IHttpActionResult Get(int id)
        {
            Zona zona = logicaNegocioPatio.ObtenerZona(id);
            if (zona == null)
            {
                return NotFound();
            }
            return Ok(zona);
        }

        // PUT: api/Zona/5
        public IHttpActionResult Put([FromBody]Zona zona)
        {
            try
            {
                bool updateResult = logicaNegocioPatio.ModificarZona(zona);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, zona);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Zona
        public IHttpActionResult Post([FromBody] Zona zona)
        {
            try
            {
                bool resultado = logicaNegocioPatio.AltaZona(zona);
                return CreatedAtRoute("DefaultApi", new { resultado = resultado }, zona);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE: api/Zona
        public HttpResponseMessage Delete(int idZona)
        {
            try
            {
                bool updateResult = logicaNegocioPatio.BajaZona(idZona);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
