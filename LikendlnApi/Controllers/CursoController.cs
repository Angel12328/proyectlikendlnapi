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
    public class CursoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        ///     Obtiene todos los cursos disponibles.
        /// </summary>
        /// <returns>Informacion de los cursos disponbles</returns>
        // GET: api/Curso
        public IQueryable<Curso> GetCursos()
        {
            return db.Cursos;
        }

        /// <summary>
        ///     obtiene un curso por su identificador.
        /// </summary>
        /// <param name="id">El id para buscar el curso</param>
        /// <returns>Un valor encontrado</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Curso/5
        [ResponseType(typeof(Curso))]
        public async Task<IHttpActionResult> GetCurso(int id)
        {
            Curso curso = await db.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        /// <summary>
        /// Actualiza un curso existente en la base de datos.
        /// </summary>
        /// <remarks>
        /// Realiza la actualización de un curso identificado por su ID. 
        /// Si la operación es exitosa, retorna un código 204 (No Content).
        /// </remarks>
        /// <param name="id">ID del curso a actualizar, debe coincidir con el ID en el objeto Curso proporcionado.</param>
        /// <param name="curso">Objeto Curso con los nuevos datos para la actualización.</param>
        /// <returns>
        /// Retorna BadRequest (400) si:
        /// - El modelo no es válido
        /// - El ID del parámetro no coincide con el ID del objeto Curso
        /// Retorna NotFound (404) si el curso no existe
        /// Retorna NoContent (204) si la actualización fue exitosa
        /// Puede lanzar DbUpdateConcurrencyException en caso de conflictos de concurrencia
        /// </returns>
        /// <response code="204">Actualización realizada correctamente</response>
        /// <response code="400">Solicitud incorrecta (modelo inválido o IDs no coinciden)</response>
        /// <response code="404">Curso no encontrado</response>
        // PUT: api/Curso/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCurso(int id, Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curso.Id)
            {
                return BadRequest();
            }

            db.Entry(curso).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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
        /// Crea un nuevo curso en la base de datos.
        /// </summary>
        /// <remarks>
        /// Añade un nuevo curso al sistema. Si la operación es exitosa, retorna un código 201 (Created)
        /// incluyendo la ubicación del nuevo recurso en los headers y el objeto creado en el cuerpo de la respuesta.
        /// </remarks>
        /// <param name="curso">Objeto Curso con los datos del nuevo curso a crear.</param>
        /// <returns>
        /// Retorna BadRequest (400) si el modelo recibido no es válido.
        /// Retorna Created (201) con el nuevo curso creado si la operación es exitosa.
        /// </returns>
        /// <response code="201">Devuelve el nuevo curso creado</response>
        /// <response code="400">Solicitud incorrecta (modelo inválido)</response>
        // POST: api/Curso
        [ResponseType(typeof(Curso))]
        public async Task<IHttpActionResult> PostCurso(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cursos.Add(curso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = curso.Id }, curso);
        }

        /// <summary>
        /// Elimina un curso específico de la base de datos.
        /// </summary>
        /// <remarks>
        /// Realiza una eliminación suave (soft delete) del curso identificado por el ID proporcionado.
        /// Si la operación es exitosa, retorna el objeto eliminado en el cuerpo de la respuesta.
        /// </remarks>
        /// <param name="id">ID del curso a eliminar.</param>
        /// <returns>
        /// Retorna NotFound (404) si no existe un curso con el ID especificado.
        /// Retorna Ok (200) con el curso eliminado si la operación fue exitosa.
        /// </returns>
        /// <response code="200">Operación exitosa, devuelve el curso eliminado</response>
        /// <response code="404">No se encontró el curso con el ID especificado</response>
        // DELETE: api/Curso/5
        [ResponseType(typeof(Curso))]
        public async Task<IHttpActionResult> DeleteCurso(int id)
        {
            Curso curso = await db.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            db.Cursos.Remove(curso);
            await db.SaveChangesAsync();

            return Ok(curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursoExists(int id)
        {
            return db.Cursos.Count(e => e.Id == id) > 0;
        }
    }
}