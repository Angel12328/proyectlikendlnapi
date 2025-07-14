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
    public class ParticipanteChatController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// Obtiene todos los participantes de chat.
        /// </summary>
        /// <returns>Una lista de participantes de chat</returns>
        // GET: api/ParticipanteChat
        public IQueryable<ParticipanteChat> GetParticipanteChats()
        {
            return db.ParticipanteChats;
        }

        /// <summary>
        /// Obtiene un participante de chat específico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/ParticipanteChat/5
        ///
        /// </remarks>
        /// <param name="id">El id del participante de chat a obtener</param>
        /// <returns>Información del participante de chat</returns>
        /// <response code="404">Si el participante de chat no fue encontrado</response>
        /// <response code="200">Si el participante de chat fue encontrado</response>
        // GET: api/ParticipanteChat/5
        [ResponseType(typeof(ParticipanteChat))]
        public async Task<IHttpActionResult> GetParticipanteChat(int id)
        {
            ParticipanteChat participanteChat = await db.ParticipanteChats.FindAsync(id);
            if (participanteChat == null)
            {
                return NotFound();
            }

            return Ok(participanteChat);
        }

        /// <summary>
        /// Actualiza completamente un participante de chat.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/ParticipanteChat/5
        ///
        /// </remarks>
        /// <param name="id">El id del participante de chat a actualizar</param>
        /// <param name="participanteChat">La información del participante de chat a reemplazar</param>
        /// <returns>Vacío si el proceso es exitoso</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="400">Si el id no coincide con el participante de chat</response>
        /// <response code="404">Si el participante de chat no fue encontrado</response>
        /// <response code="204">Si el participante de chat fue actualizado</response>
        // PUT: api/ParticipanteChat/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParticipanteChat(int id, ParticipanteChat participanteChat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participanteChat.ID)
            {
                return BadRequest();
            }

            db.Entry(participanteChat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteChatExists(id))
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
        /// Crea un nuevo participante de chat.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // POST: api/ParticipanteChat
        ///
        /// </remarks>
        /// <param name="participanteChat">La información del participante de chat a crear</param>
        /// <returns>El participante de chat recién creado</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="201">Si el participante de chat fue creado exitosamente</response>
        // POST: api/ParticipanteChat
        [ResponseType(typeof(ParticipanteChat))]
        public async Task<IHttpActionResult> PostParticipanteChat(ParticipanteChat participanteChat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParticipanteChats.Add(participanteChat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = participanteChat.ID }, participanteChat);
        }

        /// <summary>
        /// Elimina un participante de chat específico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // DELETE: api/ParticipanteChat/5
        ///
        /// </remarks>
        /// <param name="id">El id del participante de chat a eliminar</param>
        /// <returns>El participante de chat eliminado</returns>
        /// <response code="404">Si el participante de chat no fue encontrado</response>
        /// <response code="200">Si el participante de chat fue eliminado exitosamente</response>
        // DELETE: api/ParticipanteChat/5
        [ResponseType(typeof(ParticipanteChat))]
        public async Task<IHttpActionResult> DeleteParticipanteChat(int id)
        {
            ParticipanteChat participanteChat = await db.ParticipanteChats.FindAsync(id);
            if (participanteChat == null)
            {
                return NotFound();
            }

            db.ParticipanteChats.Remove(participanteChat);
            await db.SaveChangesAsync();

            return Ok(participanteChat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipanteChatExists(int id)
        {
            return db.ParticipanteChats.Count(e => e.ID == id) > 0;
        }
    }
}