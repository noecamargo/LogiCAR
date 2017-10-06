using System;
using System.Collections.Generic;
using System.Web.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;

namespace LogiCAR.WebApi.Controllers
{
    public class DanioController : ApiController
    {

        private ILogicaNegocioDanio logicaNegocioDanio { get; set; }

        public DanioController(ILogicaNegocioDanio logicaDanio)
        {
            logicaNegocioDanio = logicaDanio;
        }

        // GET: api/Danio
        public IHttpActionResult Get()
        {
            IEnumerable<Danio> danios = logicaNegocioDanio.ObtenerDanios();
            if (danios == null)
            {
                return NotFound();
            }
            return Ok(danios);

        }

        // GET: api/Danio/5
        public IHttpActionResult Get(int id)
        {
            Danio danio = logicaNegocioDanio.ObtenerDanio(id);
            if (danio == null)
            {
                return NotFound();
            }
            return Ok(danio);
        }

        // PUT: api/Danio/5
        public IHttpActionResult Put(int id, [FromBody]Danio danio)
        {
            try
            {
                bool updateResult = logicaNegocioDanio.ActualizarDanio(id, danio);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, danio);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Danio
        public IHttpActionResult Post([FromBody] Danio danio)
        {
            try
            {
                int id = logicaNegocioDanio.CrearDanio(danio);
                return CreatedAtRoute("DefaultApi", new { id = id }, danio);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    // DELETE: api/Danio/5
    //public void Delete(int id)
    //{
    //}
}

