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
    public class CandidatoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();
        /// <summary>
        /// obtiene todos los candidatos registrados en el sistema.
        /// </summary>
        /// <returns>Los Candidatos registrados en el sistema</returns>
        // GET: api/Candidato
        public IQueryable<Candidato> GetCandidatos()
        {
            return db.Candidatos;
        }

        /// <summary>
        /// Obtiene los datos completos de un candidato específico por su ID.
        /// </summary>
        /// <param name="id">ID único del candidato que se desea recuperar</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 200 OK con el objeto Candidato si existe
        /// - 404 Not Found si no se encuentra el candidato con el ID especificado
        /// </returns>
        /// <remarks>
        /// Campos sensibles no incluidos:
        /// - Información de contacto personal
        /// - Documentación identificatoria
        /// - Historial salarial
        /// </remarks>
        /// <response code="200">Retorna el objeto Candidato solicitado</response>
        /// <response code="404">Si no existe ningún candidato con el ID proporcionado</response>
        // GET: api/Candidato/5
        [ResponseType(typeof(Candidato))]
        public async Task<IHttpActionResult> GetCandidato(int id)
        {
            Candidato candidato = await db.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            return Ok(candidato);
        }

        /// <summary>
        /// Actualiza los datos completos de un candidato específico por su ID.
        /// </summary>
        /// <param name="id">ID único del candidato que se desea actualizar</param>
        /// <param name="candidato">Objeto Candidato con los datos actualizados</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 204 No Content si la actualización fue exitosa
        /// - 400 Bad Request si los datos son inválidos o los IDs no coinciden
        /// - 404 Not Found si no existe el candidato con el ID especificado
        /// </returns>
        /// <remarks>
        /// Validaciones importantes:
        /// - El ID en la URL debe coincidir con el ID en el cuerpo del objeto
        /// - Todos los campos requeridos deben estar presentes
        /// - El formato de email y teléfono deben ser válidos
        /// 
        /// Campos que no pueden ser modificados:
        /// - FechaCreacion (mantiene el valor original)
        /// - ID (no puede ser cambiado)
        /// </remarks>
        /// <response code="204">La actualización fue exitosa (no retorna contenido)</response>
        /// <response code="400">Si el modelo es inválido, los IDs no coinciden o hay errores de validación</response>
        /// <response code="404">Si no existe ningún candidato con el ID proporcionado</response>
        /// <response code="500">Error interno del servidor durante la actualización</response>
        // PUT: api/Candidato/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidato(int id, Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidato.Id)
            {
                return BadRequest();
            }

            db.Entry(candidato).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
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
        /// Crea un nuevo registro de candidato en el sistema.
        /// </summary>
        /// <param name="candidato">Objeto Candidato con los datos del nuevo registro</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 201 Created con el objeto Candidato creado y la URL de ubicación
        /// - 400 Bad Request si los datos son inválidos o incompletos
        /// </returns>
        /// <remarks>
        /// Campos requeridos obligatorios:
        /// - Nombre (máx. 100 caracteres)
        /// - Email (formato válido)
        /// - NivelExperiencia (Junior, Mid-level, Senior, Lead)
        /// </remarks>
        /// <response code="201">Retorna el nuevo candidato creado con su URL de ubicación</response>
        /// <response code="400">Si el modelo es inválido o faltan campos requeridos</response>
        /// <response code="500">Error interno del servidor durante la creación</response>
        // POST: api/Candidato
        [ResponseType(typeof(Candidato))]
        public async Task<IHttpActionResult> PostCandidato(Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Candidatos.Add(candidato);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidato.Id }, candidato);
        }

        /// <summary>
        /// Elimina un candidato específico del sistema mediante su ID.
        /// </summary>
        /// <param name="id">ID único del candidato que se desea eliminar</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 200 OK con el objeto Candidato eliminado si la operación fue exitosa
        /// - 404 Not Found si no existe ningún candidato con el ID proporcionado
        /// </returns>
        /// <remarks>
        /// Impacto en relaciones:
        /// - Elimina automáticamente los registros relacionados en tablas dependientes
        /// - Registra el evento de eliminación en el historial de actividades
        /// </remarks>
        /// <response code="200">Retorna el candidato eliminado con todos sus datos</response>
        /// <response code="404">Si no existe ningún candidato con el ID proporcionado</response>
        // DELETE: api/Candidato/5
        [ResponseType(typeof(Candidato))]
        public async Task<IHttpActionResult> DeleteCandidato(int id)
        {
            Candidato candidato = await db.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            db.Candidatos.Remove(candidato);
            await db.SaveChangesAsync();

            return Ok(candidato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoExists(int id)
        {
            return db.Candidatos.Count(e => e.Id == id) > 0;
        }
    }
}