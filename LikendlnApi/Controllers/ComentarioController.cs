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
    public class ComentarioController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        ///     obtiene todos los comentarios disponibles.
        /// </summary>
        /// <returns>Comentarios del sistema</returns>
        /// <response code="200">Listado de comentarios disponible para consulta</response>
        // GET: api/Comentario
        public IQueryable<Comentario> GetComentarios()
        {
            return db.Comentarios;
        }


        /// <summary>
        /// Obtiene un comentario específico por su ID.
        /// </summary>
        /// <remarks>
        /// Recupera los detalles de un comentario en particular identificado por su ID único.
        /// Si el comentario no existe, retorna un código 404 (Not Found).
        /// </remarks>
        /// <param name="id">ID del comentario a recuperar.</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con el comentario solicitado si existe
        /// - 404 (Not Found) si no existe un comentario con el ID proporcionado
        /// </returns>
        /// <response code="200">Comentario encontrado y devuelto en el cuerpo de la respuesta</response>
        /// <response code="404">No se encontró ningún comentario con el ID especificado</response>
        // GET: api/Comentario/5
        [ResponseType(typeof(Comentario))]
        public async Task<IHttpActionResult> GetComentario(int id)
        {
            Comentario comentario = await db.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        /// <summary>
        /// Actualiza un comentario existente en el sistema.
        /// </summary>
        /// <remarks>
        /// Realiza la actualización completa (PUT) de un comentario identificado por su ID.
        /// Requiere que el objeto comentario proporcionado tenga un ID coincidente con el parámetro de ruta.
        /// 
        /// Nota: Este es una operación de reemplazo completo (PUT), no una actualización parcial (PATCH).
        /// </remarks>
        /// <param name="id">ID del comentario a actualizar </param>
        /// <param name="comentario">Objeto Comentario con los nuevos valores (desde el cuerpo de la solicitud)</param>
        /// <returns>
        /// Retorna:
        /// - 204 (No Content) si la actualización fue exitosa
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - El ID de la URL no coincide con el ID del objeto comentario
        /// - 404 (Not Found) si el comentario no existe
        /// </returns>
        /// <response code="204">Actualización realizada con éxito</response>
        /// <response code="400">Solicitud mal formada (validación fallida)</response>
        /// <response code="404">Comentario no encontrado</response>
       
        // PUT: api/Comentario/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComentario(int id, Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentario.ID)
            {
                return BadRequest();
            }

            db.Entry(comentario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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
        /// Crea un nuevo comentario en el sistema.
        /// </summary>
        /// <remarks>
        /// Crea una nueva entrada de comentario con los datos proporcionados.
        /// Si la operación es exitosa, retorna la ubicación del nuevo recurso en el encabezado 'Location'
        /// y el objeto creado en el cuerpo de la respuesta.
        /// </remarks>
        /// <param name="comentario">Objeto Comentario con los datos a crear</param>
        /// <returns>
        /// Retorna:
        /// - 201 (Created) con el nuevo comentario si la creación fue exitosa
        /// - 400 (Bad Request) si los datos del comentario son inválidos
        /// </returns>
        /// <response code="201">Devuelve el comentario recién creado</response>
        /// <response code="400">Los datos proporcionados son inválidos</response>
        // POST: api/Comentario
        [ResponseType(typeof(Comentario))]
        public async Task<IHttpActionResult> PostComentario(Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            comentario.Fecha = DateTime.Now;
            db.Comentarios.Add(comentario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = comentario.ID }, comentario);
        }

        /// <summary>
        /// Elimina un comentario específico del sistema.
        /// </summary>
        /// <remarks>
        /// Realiza una eliminación permanente (hard delete) del comentario identificado por el ID proporcionado.
        /// Si la operación es exitosa, retorna el objeto eliminado en el cuerpo de la respuesta.
        /// </remarks>
        /// <param name="id">ID del comentario a eliminar</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con el comentario eliminado si la operación fue exitosa
        /// - 404 (Not Found) si no existe un comentario con el ID especificado
        /// </returns>
        /// <response code="200">Comentario eliminado exitosamente (devuelve el objeto eliminado)</response>
        /// <response code="404">No se encontró el comentario con el ID especificado</response>
        // DELETE: api/Comentario/5
        [ResponseType(typeof(Comentario))]
        public async Task<IHttpActionResult> DeleteComentario(int id)
        {
            Comentario comentario = await db.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            db.Comentarios.Remove(comentario);
            await db.SaveChangesAsync();

            return Ok(comentario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentarioExists(int id)
        {
            return db.Comentarios.Count(e => e.ID == id) > 0;
        }
    }
}