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
    public class ChatController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// obtiene todos los chats disponibles.
        /// </summary>
        /// <returns></returns>
        // GET: api/Chat
        public IQueryable<Chat> GetChats()
        {
            return db.Chats;
        }

        /// <summary>
        /// Obtiene los detalles de un chat específico.
        /// </summary>
        /// <remarks>
        /// Recupera la información completa de un chat identificado por su ID único,
        /// incluyendo sus metadatos básicos.
        /// </remarks>
        /// <param name="id">ID único del chat a recuperar</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con los datos del chat si existe
        /// - 404 (Not Found) si no se encuentra el chat
        /// </returns>
        /// <response code="200">Chat encontrado y devuelto</response>
        /// <response code="404">No existe un chat con el ID especificado</response>
        // GET: api/Chat/5
        [ResponseType(typeof(Chat))]
        public async Task<IHttpActionResult> GetChat(int id)
        {
            Chat chat = await db.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            return Ok(chat);
        }

        /// <summary>
        /// Actualiza la información de un chat existente.
        /// </summary>
        /// <remarks>
        /// Realiza una actualización completa (PUT) de un chat identificado por su ID.
        /// Requiere que el objeto chat proporcionado tenga un ID coincidente con el parámetro de ruta.
        /// </remarks>
        /// <param name="id">ID del chat a actualizar (desde la URL)</param>
        /// <param name="chat">Objeto Chat con los datos actualizados (desde el cuerpo)</param>
        /// <returns>
        /// Retorna:
        /// - 204 (No Content) si la actualización fue exitosa
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - El ID de la URL no coincide con el ID del objeto
        /// - 404 (Not Found) si el chat no existe
        /// </returns>
        /// <response code="204">Chat actualizado exitosamente</response>
        /// <response code="400">Solicitud mal formada o datos inválidos</response>
        /// <response code="404">Chat no encontrado</response>
        // PUT: api/Chat/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChat(int id, Chat chat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chat.ID)
            {
                return BadRequest();
            }

            db.Entry(chat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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
        /// Crea un nuevo chat en el sistema.
        /// </summary>
        /// <remarks>
        /// Endpoint para la creación de nuevos chats. Al crearse exitosamente, devuelve
        /// la ubicación del nuevo recurso en el header 'Location' y el objeto creado.
        /// </remarks>
        /// <param name="chat">Objeto Chat con los datos del nuevo chat</param>
        /// <returns>
        /// Retorna:
        /// - 201 (Created) con el chat creado si es exitoso
        /// - 400 (Bad Request) si los datos son inválidos
        /// </returns>
        /// <response code="201">Chat creado exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        // POST: api/Chat
        [ResponseType(typeof(Chat))]
        public async Task<IHttpActionResult> PostChat(Chat chat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chats.Add(chat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = chat.ID }, chat);
        }

        /// <summary>
        /// Elimina un chat existente del sistema.
        /// </summary>
        /// <remarks>
        /// Realiza una eliminación permanente de un chat identificado por su ID.
        /// Devuelve los datos del chat eliminado para confirmación.
        /// </remarks>
        /// <param name="id">ID del chat a eliminar</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con el chat eliminado si es exitoso
        /// - 404 (Not Found) si el chat no existe
        /// </returns>
        /// <response code="200">Chat eliminado exitosamente (datos devueltos)</response>
        /// <response code="404">Chat no encontrado</response>
        // DELETE: api/Chat/5
        [ResponseType(typeof(Chat))]
        public async Task<IHttpActionResult> DeleteChat(int id)
        {
            Chat chat = await db.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            db.Chats.Remove(chat);
            await db.SaveChangesAsync();

            return Ok(chat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatExists(int id)
        {
            return db.Chats.Count(e => e.ID == id) > 0;
        }
    }
}