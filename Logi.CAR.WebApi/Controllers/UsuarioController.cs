using System;
using System.Collections.Generic;
using System.Web.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;
using System.Net.Http;
using System.Net;

namespace LogiCAR.WebApi.Controllers
{
    public class UsuarioController : ApiController
    {

        private ILogicaNegocioSeguridad logicaNegocioSeguridad { get; set; }

        public UsuarioController(ILogicaNegocioSeguridad logicaSeguridad)
        {
            logicaNegocioSeguridad = logicaSeguridad;
        }

        // GET: api/Usuario
        public IHttpActionResult Get()
        {
            IEnumerable<Usuario> usuarios = logicaNegocioSeguridad.ObtenerUsuarios();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);

        }

        // GET: api/Usuario/5
        public IHttpActionResult Get(string nombreUsuario)
        {
            Usuario usuario = logicaNegocioSeguridad.ObtenerUsuario(nombreUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // PUT: api/Usuario/5
        public IHttpActionResult Put([FromBody]Usuario usuario)
        {
            try
            {
                bool updateResult = logicaNegocioSeguridad.ModificarUsuario(usuario);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, usuario);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Usuario
        public IHttpActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
               bool updateResult = logicaNegocioSeguridad.AltaUsuario(usuario);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, usuario);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE: api/Rol/5
        public HttpResponseMessage Delete(string nombreUsuario)
        {
            try
            {
                bool updateResult = logicaNegocioSeguridad.BajaUsuario(nombreUsuario);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }

}