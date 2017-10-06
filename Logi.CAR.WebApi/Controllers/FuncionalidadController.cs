using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;

namespace LogiCAR.WebApi.Controllers
{
    public class FuncionalidadController : ApiController
    {

        private ILogicaNegocioSeguridad logicaNegocioSeguridad{ get; set; }

        public FuncionalidadController(ILogicaNegocioSeguridad logicaSeguridad)
        {
            logicaNegocioSeguridad = logicaSeguridad;
        }

        // GET: api/Usuario
        public IHttpActionResult Get()
        {
            IEnumerable<Funcionalidad> funcionalidades = logicaNegocioSeguridad.ObtenerFuncionalidades();
            if (funcionalidades == null)
            {
                return NotFound();
            }
            return Ok(funcionalidades);

        }

        // GET: api/Usuario/5
        public IHttpActionResult Get(string nombreFuncionalidad)
        {
            Funcionalidad funcionalidad = logicaNegocioSeguridad.ObtenerFuncionalidad(nombreFuncionalidad);
            if (funcionalidad == null)
            {
                return NotFound();
            }
            return Ok(funcionalidad);
        }


        public IHttpActionResult Put( [FromBody]string nombreFuncionalidad)
        {
            try
            {
                bool updateResult = logicaNegocioSeguridad.ModificarFuncionalidad(nombreFuncionalidad);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, nombreFuncionalidad);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/Funcionalidad
        public IHttpActionResult Post([FromBody] string nombreFuncionalidad)
        {
            try
            {
                bool updateResult = logicaNegocioSeguridad.AltaFuncionalidad(nombreFuncionalidad);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, nombreFuncionalidad);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        //DELETE: api/Funcionalida/5
        public HttpResponseMessage Delete(string nombreFuncionalidad)
        {
            try
            {
                bool updateResult = logicaNegocioSeguridad.BajaFuncionalidad(nombreFuncionalidad);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        ////[Route("breed/{breedId:guid}/hairs/{hairId:int}")]
        ////[HttpGet]
        ////public IHttpActionResult Get(Guid breedId, int hairId)
        ////{
        ////    if (hairId == 1)
        ////    {
        ////        return Ok("Wonderful redish color!");
        ////    }
        ////    return NotFound();

        ////    /*HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Test");
        ////    response.Headers.CacheControl = new CacheControlHeaderValue()
        ////    {
        ////        MaxAge = TimeSpan.FromMinutes(20),
        ////    };
        ////    return response;*/

        ////    //return new ForbiddenResult(Request, "Because I say so");
        ////}
    }
}
