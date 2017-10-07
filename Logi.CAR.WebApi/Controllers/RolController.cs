using System;
using System.Collections.Generic;
using System.Web.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;
using System.Net.Http;
using System.Net;

namespace LogiCAR.WebApi.Controllers
{
    public class RolController : ApiController
    {

        private ILogicaNegocioSeguridad logicaNegocioSeguridad { get; set; }

        public RolController(ILogicaNegocioSeguridad logicaSeguridad)
        {
            logicaNegocioSeguridad = logicaSeguridad;
        }

        // GET: api/Rol
        public IHttpActionResult Get()
        {
            IEnumerable<Rol> roles = logicaNegocioSeguridad.ObtenerRoles();
            if (roles == null)
            {
                return NotFound();
            }
            return Ok(roles);

        }

        // GET: api/Rol/5
        public IHttpActionResult Get(string nombreRol)
        {
            Rol rol = logicaNegocioSeguridad.ObtenerRol(nombreRol);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        // PUT: api/Rol/5
        public IHttpActionResult Put(int id,[FromBody]Rol rol)
        {
            try
            {
                bool updateResult = logicaNegocioSeguridad.ModificarRol(id,rol);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, rol);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Rol
        public IHttpActionResult Post([FromBody] Rol Rol)
        {
            try
            {
                bool updateResult = logicaNegocioSeguridad.AltaRol(Rol);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, Rol);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    

        //DELETE: api/Rol/5
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
    }
}