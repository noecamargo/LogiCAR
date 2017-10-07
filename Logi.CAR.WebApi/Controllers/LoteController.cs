using System;
using System.Collections.Generic;
using System.Web.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;

namespace LogiCAR.WebApi.Controllers
{
    public class LoteController : ApiController
    {

        private ILogicaNegocioLote logicaLote { get; set; }

        public LoteController(ILogicaNegocioLote logicaLote)
        {
            this.logicaLote = logicaLote;
        }

        public LoteController()
        {

            logicaLote = new LogicaNegocioLote();

        }

        // GET: api/Lote/Lote
        public IHttpActionResult Get()
        {
            IEnumerable<Lote> lotees = logicaLote.ObtenerLotes();
            if (lotees == null)
            {
                return NotFound();
            }
            return Ok(lotees);

        }

        // GET: api/Lote/5
        public IHttpActionResult Get(long id)
        {
            Lote lote = logicaLote.ObtenerLote(id);
            if (lote == null)
            {
                return NotFound();
            }
            return Ok(lote);
        }

        // POST: api/Lote
        public IHttpActionResult Post([FromBody] Lote lote)
        {
            try
            {
                long id = logicaLote.CrearLote(lote);
                return CreatedAtRoute("DefaultApi", new { id = id }, lote);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Lote/5
        public IHttpActionResult Put(long id, [FromBody]Lote lote)
        {
            try
            {
                bool resultado = logicaLote.ActualizarLote(id, lote);
                return CreatedAtRoute("DefaultApi", new { updated = resultado }, lote);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

