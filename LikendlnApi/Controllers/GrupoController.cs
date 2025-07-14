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
    public class GrupoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();
        /// <summary>
        /// Obtiene todos los grupos.
        /// </summary>
        /// <returns>Una lista de grupos</returns>
        // GET: api/Grupo
        public IQueryable<Grupo> GetGrupos()
        {
            return db.Grupos;
        }
        /// <summary>
        /// Obtiene  un grupo.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/Grupo/5
        ///
        /// </remarks>
        /// <param name="id">El id de la empresa a actualizar.</param>
        /// <returns>La informacion de  un grupo</returns>
        /// <response code="404">Si la empresa a modificar no fue encontrada</response>
        /// <response code="200">Si la empresa fue modificada</response>
        // GET: api/Grupo/5
        [ResponseType(typeof(Grupo))]
        public async Task<IHttpActionResult> GetGrupo(int id)
        {
            Grupo grupo = await db.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }

            return Ok(grupo);
        }
        /// <summary>
        /// Actualiza completamente una grupo.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/Grupo/5
        ///
        /// </remarks>
        /// <param name="id">El id de la empresa a actualizar.</param>
        /// <param name="grupo">La informacion del grupo a reemplazar</param>
        /// <returns>Vacio si el proceso es hecho con exito</returns>
        /// <response code="400">Los datos ingresados no estan completos</response>
        /// <response code="400">Si el id a actualizar no coincide con el id de informacion a modificar</response>
        /// <response code="404">Si el grupo a modificar no fue encontrado</response>
        /// <response code="204">Si el grupo fue modificado</response>
        // PUT: api/Grupo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGrupo(int id, Grupo grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupo.ID)
            {
                return BadRequest();
            }

            db.Entry(grupo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(id))
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
        /// Crea un nuevo grupo.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/Empresa/5
        ///
        /// </remarks>
        /// <param name="grupo">La informacion del grupo a crear</param>
        /// <response code="400">Los datos ingresados no estan completos</response>
        /// <response code="201">Si el grupo fue creado</response>
        // POST: api/Grupo
        [ResponseType(typeof(Grupo))]
        public async Task<IHttpActionResult> PostGrupo(Grupo grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grupos.Add(grupo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = grupo.ID }, grupo);
        }

        /// <summary>
        /// Elimina un grupo.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/Empresa/5
        ///
        /// </remarks>
        /// <param name="id">El id del grupo a eliminar.</param>
        /// <returns>La informacion del grupo eliminado</returns>
        /// <response code="404">Si el grupo eliminar no fue encontrado</response>
        /// <response code="200">Si el grupo fue elimnado</response>
        // DELETE: api/Grupo/5
        [ResponseType(typeof(Grupo))]
        public async Task<IHttpActionResult> DeleteGrupo(int id)
        {
            Grupo grupo = await db.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }

            db.Grupos.Remove(grupo);
            await db.SaveChangesAsync();

            return Ok(grupo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GrupoExists(int id)
        {
            return db.Grupos.Count(e => e.ID == id) > 0;
        }
    }
}