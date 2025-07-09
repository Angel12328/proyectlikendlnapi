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

        // GET: api/ChatParticipante
        public IQueryable<ChatParticipante> GetChatParticipantes()
        {
            return db.ChatParticipantes;
        }

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