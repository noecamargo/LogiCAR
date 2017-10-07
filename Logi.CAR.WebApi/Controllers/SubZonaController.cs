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
    public class SubZonaController : ApiController
    {
        private ILogicaNegocioPatio logicaNegocioPatio { get; set; }

        public SubZonaController(ILogicaNegocioPatio logicaPatio)
        {
            logicaNegocioPatio = logicaPatio;
        }

        // GET: api/Zona
        public IHttpActionResult Get()
        {
            IEnumerable<SubZona> subZonas = logicaNegocioPatio.ObtenerSubZonas();
            if (subZonas == null)
            {
                return NotFound();
            }
            return Ok(subZonas);

        }

        // GET: api/Zona/5
        public IHttpActionResult Get(int id)
        {
            SubZona subzona = logicaNegocioPatio.ObtenerSubZona(id);
            if (subzona == null)
            {
                return NotFound();
            }
            return Ok(subzona);
        }

        // PUT: api/Zona/5
        public IHttpActionResult Put([FromBody]SubZona subZona)
        {
            try
            {
                bool updateResult = logicaNegocioPatio.ModificarSubZona(subZona);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, subZona);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Zona
        public IHttpActionResult Post([FromBody] SubZona subZona)
        {
            try
            {
                bool resultado = logicaNegocioPatio.AltaSubZona(subZona);
                return CreatedAtRoute("DefaultApi", new { resultado = resultado }, subZona);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE: api/Funcionalida/5
        public HttpResponseMessage Delete(int idZona, int idSubZona)
        {
            try
            {
                bool updateResult = logicaNegocioPatio.BajaSubZona(idZona,idSubZona);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
