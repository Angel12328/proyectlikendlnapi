using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LikendlnApi.Models;

namespace LikendlnApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// obtiene todos los usuarios registrados en el sistema.
        /// </summary>
        /// <returns></returns>
        // GET: api/Usuario
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }

        /// <summary>
        /// Obtiene un usuario específico por su identificador único.
        /// </summary>
        /// <param name="id">Identificador numérico del usuario</param>
        /// <returns>
        /// Respuesta HTTP con el objeto Usuario si existe, 
        /// o código de error si no se encuentra.
        /// </returns>
        /// <response code="200">Usuario encontrado y retornado correctamente</response>
        /// <response code="404">No existe usuario con el ID proporcionado</response>
        // GET: api/Usuario/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <param name="id">Identificador del usuario a actualizar</param>
        /// <param name="usuario">Objeto Usuario con los datos actualizados</param>
        /// <returns>
        /// Respuesta HTTP sin contenido en caso de éxito,
        /// o código de error correspondiente si falla la operación.
        /// </returns>
        /// <response code="204">Actualización realizada correctamente</response>
        /// <response code="400">Solicitud inválida (modelo no válido o IDs no coincidentes)</response>
        /// <response code="404">Usuario no encontrado</response>
        // PUT: api/Usuario/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.ID)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Crea un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuario">Datos del usuario a crear</param>
        /// <returns>
        /// Respuesta HTTP con el usuario creado y ubicación del nuevo recurso.
        /// </returns>
        /// <response code="201">Usuario creado exitosamente</response>
        /// <response code="400">Datos de usuario inválidos o incompletos</response>
        // POST: api/Usuario
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usuario.ID }, usuario);
        }

        /// <summary>
        /// Elimina un usuario existente del sistema.
        /// </summary>
        /// <param name="id">Identificador único del usuario a eliminar</param>
        /// <returns>
        /// Respuesta HTTP con el usuario eliminado en caso de éxito,
        /// o código de error correspondiente.
        /// </returns>
        /// <response code="200">Usuario eliminado exitosamente (retorna el usuario eliminado)</response>
        /// <response code="404">No se encontró usuario con el ID especificado</response>
        // DELETE: api/Usuario/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> DeleteUsuario(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            await db.SaveChangesAsync();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.ID == id) > 0;
        }
    }
}