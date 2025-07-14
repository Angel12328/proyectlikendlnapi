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
    public class ChatParticipanteController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        ///     obtiene todos los participantes de chat disponibles.
        /// </summary>
        /// <returns></returns>
        // GET: api/ChatParticipante
        public IQueryable<ChatParticipante> GetChatParticipantes()
        {
            return db.ChatParticipantes;
        }

        /// <summary>
        /// Obtiene un participante de chat específico por su ID.
        /// </summary>
        /// <remarks>
        /// Recupera la información detallada de un participante en un chat identificado por su ID único.
        /// 
        /// Ejemplo de respuesta exitosa:
        /// {
        ///   "id": 15,
        ///   "usuarioId": 42,
        ///   "chatId": 7,
        ///   "fechaUnion": "2023-04-10T14:30:00Z",
        ///   "rol": "miembro"
        /// }
        /// </remarks>
        /// <param name="id">ID único del participante del chat</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con los datos del participante si existe
        /// - 404 (Not Found) si no se encuentra el participante
        /// </returns>
        /// <response code="200">Participante encontrado y devuelto</response>
        /// <response code="404">No existe un participante con el ID especificado</response>
        // GET: api/ChatParticipante/5
        [ResponseType(typeof(ChatParticipante))]
        public async Task<IHttpActionResult> GetChatParticipante(int id)
        {
            ChatParticipante chatParticipante = await db.ChatParticipantes.FindAsync(id);
            if (chatParticipante == null)
            {
                return NotFound();
            }

            return Ok(chatParticipante);
        }

        /// <summary>
        /// Actualiza la información de un participante de chat existente.
        /// </summary>
        /// <remarks>
        /// Realiza una actualización completa (PUT) de un participante de chat.
        /// Requiere que el ID en la URL coincida con el ID en el objeto proporcionado.
        /// 
        /// Ejemplo de solicitud:
        /// PUT /api/ChatParticipantes/5
        /// {
        ///   "id": 5,
        ///   "usuarioId": 42,
        ///   "chatId": 7,
        ///   "rol": "administrador"
        /// }
        /// </remarks>
        /// <param name="id">ID del participante a actualizar (debe coincidir con el ID en el objeto)</param>
        /// <param name="chatParticipante">Objeto ChatParticipante con los nuevos datos</param>
        /// <returns>
        /// Retorna:
        /// - 204 (No Content) si la actualización fue exitosa
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - Los IDs no coinciden
        /// - 404 (Not Found) si el participante no existe
        /// - 409 (Conflict) si ocurre un error de concurrencia
        /// </returns>
        /// <response code="204">Actualización realizada con éxito</response>
        /// <response code="400">Solicitud mal formada</response>
        /// <response code="404">Participante no encontrado</response>
        /// <response code="409">Conflicto de concurrencia detectado</response>
        // PUT: api/ChatParticipante/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChatParticipante(int id, ChatParticipante chatParticipante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatParticipante.Id)
            {
                return BadRequest();
            }

            db.Entry(chatParticipante).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatParticipanteExists(id))
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
        /// Crea un nuevo participante en un chat.
        /// </summary>
        /// <remarks>
        /// Añade un nuevo usuario como participante en un chat específico.
        /// </remarks>
        /// <param name="chatParticipante">Objeto ChatParticipante con los datos del nuevo participante</param>
        /// <returns>
        /// Retorna:
        /// - 201 (Created) con el participante creado si la operación es exitosa
        /// - 400 (Bad Request) si los datos son inválidos
        /// </returns>
        /// <response code="201">Participante creado exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        // POST: api/ChatParticipante
        [ResponseType(typeof(ChatParticipante))]
        public async Task<IHttpActionResult> PostChatParticipante(ChatParticipante chatParticipante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatParticipantes.Add(chatParticipante);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = chatParticipante.Id }, chatParticipante);
        }

        /// <summary>
        /// Elimina un participante de un chat.
        /// </summary>
        /// <remarks>
        /// Remueve permanentemente a un participante de un chat identificado por su ID.
        /// </remarks>
        /// <param name="id">ID del participante a eliminar</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con el participante eliminado si la operación es exitosa
        /// - 404 (Not Found) si el participante no existe
        /// </returns>
        /// <response code="200">Participante eliminado exitosamente (devuelve los datos eliminados)</response>
        /// <response code="404">No se encontró el participante con el ID especificado</response>
        // DELETE: api/ChatParticipante/5
        [ResponseType(typeof(ChatParticipante))]
        public async Task<IHttpActionResult> DeleteChatParticipante(int id)
        {
            ChatParticipante chatParticipante = await db.ChatParticipantes.FindAsync(id);
            if (chatParticipante == null)
            {
                return NotFound();
            }

            db.ChatParticipantes.Remove(chatParticipante);
            await db.SaveChangesAsync();

            return Ok(chatParticipante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatParticipanteExists(int id)
        {
            return db.ChatParticipantes.Count(e => e.Id == id) > 0;
        }
    }
}