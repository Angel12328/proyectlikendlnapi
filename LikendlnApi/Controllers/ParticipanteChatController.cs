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

        // GET: api/ParticipanteChat
        public IQueryable<ParticipanteChat> GetParticipanteChats()
        {
            return db.ParticipanteChats;
        }

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