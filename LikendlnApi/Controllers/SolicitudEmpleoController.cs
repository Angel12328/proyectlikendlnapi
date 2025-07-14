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
    public class SolicitudEmpleoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// obtiene todas las solicitudes de empleo registradas en el sistema.
        /// </summary>
        /// <returns></returns>
        // GET: api/SolicitudEmpleo
        public IQueryable<SolicitudEmpleo> GetSolicitudEmpleos()
        {
            return db.SolicitudEmpleos;
        }

        /// <summary>
        /// Obtiene una solicitud de empleo específica por su ID
        /// </summary>
        /// <param name="id">ID único de la solicitud de empleo</param>
        /// <returns>
        /// Respuesta HTTP con la solicitud de empleo si existe,
        /// o código de error si no se encuentra
        /// </returns>
        /// <response code="200">Solicitud de empleo encontrada y retornada exitosamente</response>
        /// <response code="404">No existe solicitud de empleo con el ID proporcionado</response>
        // GET: api/SolicitudEmpleo/5
        [ResponseType(typeof(SolicitudEmpleo))]
        public async Task<IHttpActionResult> GetSolicitudEmpleo(int id)
        {
            SolicitudEmpleo solicitudEmpleo = await db.SolicitudEmpleos.FindAsync(id);
            if (solicitudEmpleo == null)
            {
                return NotFound();
            }

            return Ok(solicitudEmpleo);
        }

        /// <summary>
        /// Actualiza una solicitud de empleo existente
        /// </summary>
        /// <param name="id">ID de la solicitud de empleo a actualizar</param>
        /// <param name="solicitudEmpleo">Datos actualizados de la solicitud</param>
        /// <returns>
        /// Respuesta HTTP sin contenido en caso de éxito,
        /// o código de error correspondiente
        /// </returns>
        /// <response code="204">Solicitud actualizada exitosamente</response>
        /// <response code="400">Solicitud inválida (datos incorrectos o IDs no coincidentes)</response>
        // PUT: api/SolicitudEmpleo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSolicitudEmpleo(int id, SolicitudEmpleo solicitudEmpleo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitudEmpleo.ID)
            {
                return BadRequest();
            }

            db.Entry(solicitudEmpleo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudEmpleoExists(id))
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
        /// Crea una nueva solicitud de empleo en el sistema
        /// </summary>
        /// <param name="solicitudEmpleo">Datos completos de la nueva solicitud</param>
        /// <returns>
        /// Respuesta HTTP con la solicitud creada y ubicación del nuevo recurso
        /// </returns>
        /// <response code="201">Solicitud creada exitosamente</response>
        /// <response code="400">Datos de solicitud inválidos o incompletos</response>
        // POST: api/SolicitudEmpleo
        [ResponseType(typeof(SolicitudEmpleo))]
        public async Task<IHttpActionResult> PostSolicitudEmpleo(SolicitudEmpleo solicitudEmpleo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SolicitudEmpleos.Add(solicitudEmpleo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = solicitudEmpleo.ID }, solicitudEmpleo);
        }

        /// <summary>
        /// Elimina una solicitud de empleo específica del sistema
        /// </summary>
        /// <param name="id">Identificador único de la solicitud de empleo</param>
        /// <returns>
        /// Respuesta HTTP con la solicitud eliminada en caso de éxito,
        /// o código de error correspondiente
        /// </returns>
        /// <response code="200">Solicitud eliminada exitosamente (retorna la solicitud eliminada)</response>
        /// <response code="404">No se encontró la solicitud con el ID especificado</response>
        /// <response code="500">Error interno del servidor durante la eliminación</response>
        // DELETE: api/SolicitudEmpleo/5
        [ResponseType(typeof(SolicitudEmpleo))]
        public async Task<IHttpActionResult> DeleteSolicitudEmpleo(int id)
        {
            SolicitudEmpleo solicitudEmpleo = await db.SolicitudEmpleos.FindAsync(id);
            if (solicitudEmpleo == null)
            {
                return NotFound();
            }

            db.SolicitudEmpleos.Remove(solicitudEmpleo);
            await db.SaveChangesAsync();

            return Ok(solicitudEmpleo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolicitudEmpleoExists(int id)
        {
            return db.SolicitudEmpleos.Count(e => e.ID == id) > 0;
        }
    }
}