using System;
using System.Collections.Generic;
using System.Web.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;

namespace LogiCAR.WebApi.Controllers
{
    public class TransporteLoteController : ApiController
    {

        private ILogicaNegocioTransporteLote logicaTransporteLote { get; set; }

        public TransporteLoteController(ILogicaNegocioTransporteLote logicaTransporteLote)
        {
            this.logicaTransporteLote = logicaTransporteLote;
        }

        // GET: api/TransporteLote/TransporteLote
        public IHttpActionResult Get()
        {
            IEnumerable<TransporteLote> transportes = logicaTransporteLote.ObtenerTransporteLotes();
            if (transportes == null)
            {
                return NotFound();
            }
            return Ok(transportes);

        }

        // GET: api/TransporteLote/5
        public IHttpActionResult Get(long id)
        {
            TransporteLote TransportLote = logicaTransporteLote.ObtenerTransporteLote(id);
            if (TransportLote == null)
            {
                return NotFound();
            }
            return Ok(TransportLote);
        }

        // POST: api/TransporteLote
        public IHttpActionResult Post([FromBody] TransporteLote transporte)
        {
            try
            {
                long id = logicaTransporteLote.CrearTransporteLote(transporte);
                return CreatedAtRoute("DefaultApi", new { id = id }, transporte);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/TransporteLote/5
        public IHttpActionResult Put(long id, [FromBody]TransporteLote transporteLote)
        {
            try
            {
                bool resultado = logicaTransporteLote.ActualizarTransporteLote(id, transporteLote);
                return CreatedAtRoute("DefaultApi", new { updated = resultado }, transporteLote);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

