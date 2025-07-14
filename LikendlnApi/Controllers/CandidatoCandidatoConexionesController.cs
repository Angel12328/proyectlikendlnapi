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
    public class CandidatoCandidatoConexionesController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// obtiene todas las conexiones entre candidatos disponibles.
        /// </summary>
        /// <returns></returns>
        // GET: api/CandidatoCandidatoConexiones
        public IQueryable<CandidatoCandidatoConexiones> GetCandidatoCandidatoConexiones()
        {
            return db.CandidatoCandidatoConexiones;
        }

        /// <summary>
        /// Obtiene una conexión específica entre candidatos por su ID.
        /// </summary>
        /// <param name="id">ID único de la conexión Candidato-Candidato que se desea recuperar</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 200 OK con el objeto CandidatoCandidatoConexiones si existe
        /// - 404 Not Found si no se encuentra la conexión con el ID especificado
        /// </returns>
        /// <remarks>
        /// Ejemplo de solicitud:
        /// GET /api/CandidatoCandidatoConexiones/15
        ///
        /// Ejemplo de respuesta exitosa:
        /// HTTP/1.1 200 OK
        /// Campos importantes:
        /// - CandidatoOrigenId: ID del candidato que originó la conexión
        /// - CandidatoDestinoId: ID del candidato que recibió la conexión
        /// - TipoConexion: Tipo de relación entre los candidatos
        /// </remarks>
        /// <response code="200">Retorna la conexión Candidato-Candidato solicitada</response>
        /// <response code="404">Si no existe ninguna conexión con el ID proporcionado</response>
        // GET: api/CandidatoCandidatoConexiones/5
        [ResponseType(typeof(CandidatoCandidatoConexiones))]
        public async Task<IHttpActionResult> GetCandidatoCandidatoConexiones(int id)
        {
            CandidatoCandidatoConexiones candidatoCandidatoConexiones = await db.CandidatoCandidatoConexiones.FindAsync(id);
            if (candidatoCandidatoConexiones == null)
            {
                return NotFound();
            }

            return Ok(candidatoCandidatoConexiones);
        }

        /// <summary>
        /// Actualiza una conexión existente entre dos candidatos.
        /// </summary>
        /// <param name="id">ID de la conexión a actualizar (debe coincidir con el ID en el objeto)</param>
        /// <param name="candidatoCandidatoConexiones">Objeto con los datos actualizados de la conexión</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 204 No Content si la actualización fue exitosa
        /// - 400 Bad Request si el modelo es inválido o los IDs no coinciden
        /// - 404 Not Found si no existe la conexión con el ID especifica
        /// </returns>
        /// <remarks>
        /// Ejemplo de solicitud:
        /// PUT /api/CandidatoCandidatoConexiones/25
        /// Validaciones importantes:
        /// 1. El ID en la URL debe coincidir con el ID en el cuerpo
        /// 2. Todos los campos requeridos deben ser válidos
        /// 3. No se puede modificar el CandidatoOrigenId o CandidatoDestinoId después de creada
        /// </remarks>
        /// <response code="204">La conexión fue actualizada exitosamente</response>
        /// <response code="400">Si hay errores de validación o discrepancia en los IDs</response>
        /// <response code="404">Si no se encuentra la conexión a actualizar</response>

        // PUT: api/CandidatoCandidatoConexiones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoCandidatoConexiones(int id, CandidatoCandidatoConexiones candidatoCandidatoConexiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoCandidatoConexiones.ID)
            {
                return BadRequest();
            }

            db.Entry(candidatoCandidatoConexiones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoCandidatoConexionesExists(id))
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
        /// Crea una nueva conexión de red profesional entre dos candidatos.
        /// </summary>
        /// <param name="candidatoCandidatoConexiones">Objeto con los datos de la nueva conexión</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 201 Created con la nueva conexión creada y URL de ubicación
        /// - 400 Bad Request si el modelo es inválido o faltan datos requeridos
        /// </returns>
        /// <remarks>
        /// Reglas de validación:
        /// 1. CandidatoOrigenId y CandidatoDestinoId deben ser diferentes
        /// 2. TipoConexion debe ser uno de los valores permitidos
        /// 3. FechaConexion no puede ser futura
        /// </remarks>
        /// <response code="201">Retorna la conexión creada con la URL para acceder al recurso</response>
        /// <response code="400">Si los datos proporcionados son inválidos o incompletos</response>
        // POST: api/CandidatoCandidatoConexiones
        [ResponseType(typeof(CandidatoCandidatoConexiones))]
        public async Task<IHttpActionResult> PostCandidatoCandidatoConexiones(CandidatoCandidatoConexiones candidatoCandidatoConexiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatoCandidatoConexiones.Add(candidatoCandidatoConexiones);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoCandidatoConexiones.ID }, candidatoCandidatoConexiones);
        }

        /// <summary>
        /// Elimina una conexión específica entre candidatos según su ID.
        /// </summary>
        /// <param name="id">ID de la conexión Candidato-Candidato que se desea eliminar</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 200 OK con la conexión eliminada si la operación fue exitosa
        /// - 404 Not Found si no se encuentra la conexión con el ID especificado
        /// </returns>
        /// <remarks> 
        /// Advertencias importantes:
        /// - La eliminación es PERMANENTE y no puede deshacerse
        /// - Se recomienda implementar un borrado lógico si se necesita conservar historial
        /// - Verificar dependencias antes de eliminar
        /// </remarks>
        /// <response code="200">Retorna el objeto CandidatoCandidatoConexiones eliminado</response>
        /// <response code="404">Si no existe ninguna conexión con el ID proporcionado</response>
        // DELETE: api/CandidatoCandidatoConexiones/5
        [ResponseType(typeof(CandidatoCandidatoConexiones))]
        public async Task<IHttpActionResult> DeleteCandidatoCandidatoConexiones(int id)
        {
            CandidatoCandidatoConexiones candidatoCandidatoConexiones = await db.CandidatoCandidatoConexiones.FindAsync(id);
            if (candidatoCandidatoConexiones == null)
            {
                return NotFound();
            }

            db.CandidatoCandidatoConexiones.Remove(candidatoCandidatoConexiones);
            await db.SaveChangesAsync();

            return Ok(candidatoCandidatoConexiones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoCandidatoConexionesExists(int id)
        {
            return db.CandidatoCandidatoConexiones.Count(e => e.ID == id) > 0;
        }
    }
}