using System;
using System.Collections.Generic;
using System.Web.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;

namespace LogiCAR.WebApi.Controllers
{
    public class InspeccionController : ApiController
    {

        private ILogicaNegocioInspeccion logicaInspeccion { get; set; }

        public InspeccionController(ILogicaNegocioInspeccion logicaInspeccion)
        {
            this.logicaInspeccion = logicaInspeccion;
        }

        // GET: api/Inspeccion/Inspeccion
        public IHttpActionResult Get()
        {
            IEnumerable<Inspeccion> inspecciones = logicaInspeccion.ObtenerInspecciones();
            if (inspecciones == null)
            {
                return NotFound();
            }
            return Ok(inspecciones);

        }

        // GET: api/Inspeccion/5
        public IHttpActionResult Get(int id)
        {
            Inspeccion inspeccion = logicaInspeccion.ObtenerInspeccion(id);
            if (inspeccion == null)
            {
                return NotFound();
            }
            return Ok(inspeccion);
        }

        // POST: api/Inspeccion
        public IHttpActionResult Post([FromBody] Inspeccion inspeccion)
        {
            try
            {
                int id = logicaInspeccion.CrearInspeccion(inspeccion);
                return CreatedAtRoute("DefaultApi", new { id = id }, inspeccion);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Inspeccion/5
        public IHttpActionResult Put(int id, [FromBody]Inspeccion inspeccion)
        {
            try
            {
                bool resultado = logicaInspeccion.ActualizarInspeccion(id, inspeccion);
                return CreatedAtRoute("DefaultApi", new { updated = resultado }, inspeccion);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

