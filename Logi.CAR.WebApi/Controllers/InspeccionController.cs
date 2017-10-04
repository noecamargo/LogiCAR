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
    }

}

