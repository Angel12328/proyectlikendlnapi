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
    public class EmpresaController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// Obtiene todas las empresas.
        /// </summary>
        /// <returns>Una lista de empresas.</returns>
        // GET: api/Empresa
        public IQueryable<Empresa> GetEmpresas()
        {
            return db.Empresas;
        }
        /// <summary>
        /// Obtiene una empresa por su  id.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/Empresa/5
        ///
        /// </remarks>
        /// <param name="id">El id para buscar la empresa.</param>
        /// <returns>Informacion de la empresa</returns>
        /// <response code="200">Devuelve la empresa encontrada</response>
        /// <response code="404">Si la empresa no es encontrada</response>
        // GET: api/Empresa/5
        [ResponseType(typeof(Empresa))]
        public async Task<IHttpActionResult> GetEmpresa(int id)
        {
            Empresa empresa = await db.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }
        /// <summary>
        /// Actualiza completamente una empresa .
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/Empresa/5
        ///
        /// </remarks>
        /// <param name="id">El id de la empresa a actualizar.</param>
        /// <param name="empresa">La informacion de la empresa a reemplazar</param>
        /// <returns>Vacio si el proceso es hecho con exito</returns>
        /// <response code="400">Los datos ingresados no estan completos</response>
        /// <response code="400">Si el id a actualizar no coincide con el id de informacion a modificar</response>
        /// <response code="404">Si la empresa a modificar no fue encontrada</response>
        /// <response code="204">Si la empresa fue modificada</response>
        
        // PUT: api/Empresa/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpresa(int id, Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresa.ID)
            {
                return BadRequest();
            }

            db.Entry(empresa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
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
        /// Crea una empresa.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // POST: api/Empresa
        ///
        /// </remarks>
        /// <param name="empresa">La informacion de la empresa a crear</param>
        /// <returns>La</returns>
        /// <response code="400">Los datos ingresados no estan completos</response>
        /// <response code="200">La empresa fue creada</response>
        // POST: api/Empresa
        [ResponseType(typeof(Empresa))]
        public async Task<IHttpActionResult> PostEmpresa(Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            empresa.FechaCreacion = DateTime.Now; // Asignar la fecha de creación actual
            db.Empresas.Add(empresa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empresa.ID }, empresa);
        }

        /// <summary>
        /// Elimina una empresa por su  id.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // DELETE: api/Empresa/5
        ///
        /// </remarks>
        /// <param name="id">El id de empresa a eliminar.</param>
        /// <returns>La informacion de la empresa eliminada</returns>
        /// <response code="200">Devuelve la empresa eliminada</response>
        /// <response code="404">La empresa no fue encontrada</response>
        // DELETE: api/Empresa/5
        [ResponseType(typeof(Empresa))]
        public async Task<IHttpActionResult> DeleteEmpresa(int id)
        {
            Empresa empresa = await db.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            db.Empresas.Remove(empresa);
            await db.SaveChangesAsync();

            return Ok(empresa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpresaExists(int id)
        {
            return db.Empresas.Count(e => e.ID == id) > 0;
        }
    }
}