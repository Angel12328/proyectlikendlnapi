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
    public class CandidatoSeguidorEmpresaController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        ///     obtiene todos los seguidores de empresas de candidatos disponibles.
        /// </summary>
        /// <returns></returns>
        // GET: api/CandidatoSeguidorEmpresa
        public IQueryable<CandidatoSeguidorEmpresa> GetCandidatosSeguidoresEmpresas()
        {
            return db.CandidatosSeguidoresEmpresas;
        }

        /// <summary>
        /// Obtiene la relación de seguimiento entre un candidato y una empresa.
        /// </summary>
        /// <remarks>
        /// Recupera los detalles de una relación específica donde un candidato sigue a una empresa,
        /// identificada por su ID único.
        /// </remarks>
        /// <param name="id">ID único de la relación de seguimiento</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con los detalles de la relación si existe
        /// - 404 (Not Found) si no se encuentra la relación
        /// - 400 (Bad Request) si el ID es inválido
        /// </returns>
        /// <response code="200">Relación de seguimiento encontrada</response>
        /// <response code="404">Relación de seguimiento no encontrada</response>
        /// <response code="400">ID de relación inválido</response>
        // GET: api/CandidatoSeguidorEmpresa/5
        [ResponseType(typeof(CandidatoSeguidorEmpresa))]
        public async Task<IHttpActionResult> GetCandidatoSeguidorEmpresa(int id)
        {
            CandidatoSeguidorEmpresa candidatoSeguidorEmpresa = await db.CandidatosSeguidoresEmpresas.FindAsync(id);
            if (candidatoSeguidorEmpresa == null)
            {
                return NotFound();
            }

            return Ok(candidatoSeguidorEmpresa);
        }

        /// <summary>
        /// Actualiza la relación de seguimiento entre un candidato y una empresa.
        /// </summary>
        /// <remarks>
        /// Actualiza completamente (PUT) una relación de seguimiento existente.
        /// Requiere que el ID en la URL coincida con el ID en el objeto proporcionado.
        /// </remarks>
        /// <param name="id">ID de la relación a actualizar</param>
        /// <param name="candidatoSeguidorEmpresa">Objeto con los datos actualizados</param>
        /// <returns>
        /// Retorna:
        /// - 204 (No Content) si la actualización fue exitosa
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - Los IDs no coinciden
        /// - 404 (Not Found) si la relación no existe
        /// </returns>
        /// <response code="204">Actualización exitosa</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="404">Relación no encontrada</response>
        // PUT: api/CandidatoSeguidorEmpresa/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoSeguidorEmpresa(int id, CandidatoSeguidorEmpresa candidatoSeguidorEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoSeguidorEmpresa.Id)
            {
                return BadRequest();
            }

            db.Entry(candidatoSeguidorEmpresa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoSeguidorEmpresaExists(id))
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
        /// Crea una nueva relación de seguimiento entre candidato y empresa.
        /// </summary>
        /// <remarks>
        /// Establece una nueva relación donde un candidato sigue a una empresa.
        /// Devuelve la relación creada con su ID generado.
        /// </remarks>
        /// <param name="candidatoSeguidorEmpresa">Datos de la nueva relación</param>
        /// <returns>
        /// Retorna:
        /// - 201 (Created) con la relación creada si es exitoso
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - Validación de negocio falla
        /// </returns>
        /// <response code="201">Relación creada exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        // POST: api/CandidatoSeguidorEmpresa
        [ResponseType(typeof(CandidatoSeguidorEmpresa))]
        public async Task<IHttpActionResult> PostCandidatoSeguidorEmpresa(CandidatoSeguidorEmpresa candidatoSeguidorEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatosSeguidoresEmpresas.Add(candidatoSeguidorEmpresa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoSeguidorEmpresa.Id }, candidatoSeguidorEmpresa);
        }

        /// <summary>
        /// Elimina una relación de seguimiento entre candidato y empresa.
        /// </summary>
        /// <remarks>
        /// Elimina permanentemente una relación de seguimiento identificada por su ID.
        /// Devuelve los datos de la relación eliminada para confirmación.
        /// </remarks>
        /// <param name="id">ID de la relación a eliminar</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con la relación eliminada si es exitoso
        /// - 404 (Not Found) si la relación no existe
        /// </returns>
        /// <response code="200">Relación eliminada exitosamente</response>
        /// <response code="404">Relación no encontrada</response>
        // DELETE: api/CandidatoSeguidorEmpresa/5
        [ResponseType(typeof(CandidatoSeguidorEmpresa))]
        public async Task<IHttpActionResult> DeleteCandidatoSeguidorEmpresa(int id)
        {
            CandidatoSeguidorEmpresa candidatoSeguidorEmpresa = await db.CandidatosSeguidoresEmpresas.FindAsync(id);
            if (candidatoSeguidorEmpresa == null)
            {
                return NotFound();
            }

            db.CandidatosSeguidoresEmpresas.Remove(candidatoSeguidorEmpresa);
            await db.SaveChangesAsync();

            return Ok(candidatoSeguidorEmpresa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoSeguidorEmpresaExists(int id)
        {
            return db.CandidatosSeguidoresEmpresas.Count(e => e.Id == id) > 0;
        }
    }
}