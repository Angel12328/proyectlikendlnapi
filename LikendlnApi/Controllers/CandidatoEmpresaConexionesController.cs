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
    public class CandidatoEmpresaConexionesController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// obtiene todas las conexiones entre candidatos y empresas disponibles.
        /// </summary>
        /// <returns></returns>
        // GET: api/CandidatoEmpresaConexiones
        public IQueryable<CandidatoEmpresaConexiones> GetCandidatoEmpresaConexiones()
        {
            return db.CandidatoEmpresaConexiones;
        }

        /// <summary>
        /// Obtiene una conexión específica entre candidato y empresa por su ID.
        /// </summary>
        /// <param name="id">ID único de la conexión Candidato-Empresa que se desea recuperar</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 200 OK con el objeto CandidatoEmpresaConexiones si existe
        /// - 404 Not Found si no se encuentra la conexión con el ID especificado
        /// </returns>
        /// <remarks>
        /// Ejemplo de solicitud:
        /// GET /api/CandidatoEmpresaConexiones/5
        /// </remarks>
        /// <response code="200">Retorna la conexión Candidato-Empresa solicitada</response>
        /// <response code="404">Si no existe ninguna conexión con el ID proporcionado</response>
        // GET: api/CandidatoEmpresaConexiones/5
        [ResponseType(typeof(CandidatoEmpresaConexiones))]
        public async Task<IHttpActionResult> GetCandidatoEmpresaConexiones(int id)
        {
            CandidatoEmpresaConexiones candidatoEmpresaConexiones = await db.CandidatoEmpresaConexiones.FindAsync(id);
            if (candidatoEmpresaConexiones == null)
            {
                return NotFound();
            }

            return Ok(candidatoEmpresaConexiones);
        }

        /// <summary>
        /// Actualiza una conexión existente entre candidato y empresa.
        /// </summary>
        /// <param name="id">ID de la conexión a actualizar (debe coincidir con el ID en el objeto)</param>
        /// <param name="candidatoEmpresaConexiones">Objeto con los datos actualizados de la conexión</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 204 No Content si la actualización fue exitosa
        /// - 400 Bad Request si el modelo es inválido o los IDs no coinciden
        /// - 404 Not Found si no existe la conexión con el ID especificado
        /// - 409 Conflict si ocurre un error de concurrencia (registro modificado por otro usuario)
        /// </returns>
        /// <remarks>
        /// Ejemplo de solicitud:
        /// PUT /api/CandidatoEmpresaConexiones/5 
        /// Requisitos:
        /// - El ID en la URL debe coincidir con el ID en el cuerpo de la solicitud
        /// - Todos los campos requeridos deben estar presentes
        /// </remarks>
        /// <response code="204">La conexión fue actualizada exitosamente</response>
        /// <response code="400">Si hay errores de validación o discrepancia en los IDs</response>
        /// <response code="404">Si no se encuentra la conexión a actualizar</response>
        /// <response code="409">Si ocurre un conflicto de concurrencia</response>
        // PUT: api/CandidatoEmpresaConexiones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoEmpresaConexiones(int id, CandidatoEmpresaConexiones candidatoEmpresaConexiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoEmpresaConexiones.Id)
            {
                return BadRequest();
            }

            db.Entry(candidatoEmpresaConexiones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoEmpresaConexionesExists(id))
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
        /// Crea una nueva conexión entre un candidato y una empresa.
        /// </summary>
        /// <param name="candidatoEmpresaConexiones">Objeto CandidatoEmpresaConexiones con los datos de la nueva conexión</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 201 Created con la nueva conexión creada y URL de ubicación
        /// - 400 Bad Request si el modelo es inválido o faltan datos requeridos
        /// </returns>
        /// <remarks>
        /// Ejemplo de solicitud:
        /// POST /api/CandidatoEmpresaConexiones
        /// </remarks>
        /// <response code="201">Retorna el objeto creado con la URL para acceder al recurso</response>
        /// <response code="400">Si los datos proporcionados son inválidos o incompletos</response>
        // POST: api/CandidatoEmpresaConexiones
        [ResponseType(typeof(CandidatoEmpresaConexiones))]
        public async Task<IHttpActionResult> PostCandidatoEmpresaConexiones(CandidatoEmpresaConexiones candidatoEmpresaConexiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatoEmpresaConexiones.Add(candidatoEmpresaConexiones);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoEmpresaConexiones.Id }, candidatoEmpresaConexiones);
        }

        /// <summary>
        /// Elimina una conexión específica entre candidato y empresa según su ID.
        /// </summary>
        /// <param name="id">ID de la conexión Candidato-Empresa que se desea eliminar</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 200 OK con la conexión eliminada si la operación fue exitosa
        /// - 404 Not Found si no se encuentra la conexión con el ID especificado
        /// </returns>
        /// <remarks>
        /// Ejemplo de solicitud:
        /// DELETE /api/CandidatoEmpresaConexiones/8
        /// 
        /// Ejemplo de respuesta exitosa:
        /// HTTP/1.1 200 OK
        /// 
        /// Consideraciones importantes:
        /// - La eliminación es permanente y no se puede deshacer
        /// - Se recomienda verificar dependencias antes de eliminar
        /// </remarks>
        /// <response code="200">Retorna el objeto CandidatoEmpresaConexiones eliminado</response>
        /// <response code="404">Si no existe ninguna conexión con el ID proporcionado</response>
        // DELETE: api/CandidatoEmpresaConexiones/5
        [ResponseType(typeof(CandidatoEmpresaConexiones))]
        public async Task<IHttpActionResult> DeleteCandidatoEmpresaConexiones(int id)
        {
            CandidatoEmpresaConexiones candidatoEmpresaConexiones = await db.CandidatoEmpresaConexiones.FindAsync(id);
            if (candidatoEmpresaConexiones == null)
            {
                return NotFound();
            }

            db.CandidatoEmpresaConexiones.Remove(candidatoEmpresaConexiones);
            await db.SaveChangesAsync();

            return Ok(candidatoEmpresaConexiones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoEmpresaConexionesExists(int id)
        {
            return db.CandidatoEmpresaConexiones.Count(e => e.Id == id) > 0;
        }
    }
}