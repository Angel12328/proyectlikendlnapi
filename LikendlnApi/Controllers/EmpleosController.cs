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

namespace LikendlnApi.Models
{
    [RoutePrefix("api/Empleos")]
    public class EmpleosController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/Empleos
        public IQueryable<OfertaLaboral> GetOfertasLaborales()
        {
            return db.OfertasLaborales;
        }




        /// <summary>
        /// Obtiene un conjunto de ofertas laborales.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/Empleos/5
        ///
        /// </remarks>
        /// <param name="idlog">El id del candidato al que se le recomendara empleos</param>
        /// <returns>Información de la oferta laboral</returns>
        /// <response code="404">Si el candidato no fue encontrada</response>
        /// <response code="200">Si la oferta laboral fue encontrada</response>
        // GET: api/Empleos/5


        [ResponseType(typeof(List<OfertaLaboral>))]
        public async Task<IHttpActionResult> GetEmpleos(int idlog)
        {
            var ofertas = await db.OfertasLaborales
                
                .Where(o => o.HabilidadesRequeridas.Any(h =>
                    db.CandidatosHabilidades.Any(ch =>
                        ch.IdCandidato == idlog &&
                        ch.IdHabilidad == h.IdHabilidad)))
                .ToListAsync();

            return Ok(ofertas);
        }
        /*
        [ResponseType(typeof(List<OfertasLaboralesResponse>))]
        public async Task<IHttpActionResult> GetEmpleos(int idlog)
        {
            var ofertas = await db.OfertasLaborales
                .AsNoTracking() // Mejora rendimiento
                .Include(o => o.Empresa)
                .Include(o => o.HabilidadesRequeridas.Select(h => h.Habilidad))
                .Include(o => o.CandidadtosOfertas)
                .Where(o => o.HabilidadesRequeridas.Any(h =>
                    db.CandidatosHabilidades.Any(ch =>
                        ch.IdCandidato == idlog &&
                        ch.IdHabilidad == h.IdHabilidad)))
                .Select(o => new OfertasLaboralesResponse
                {
                    IdEmpleo = o.ID,
                    Titulo = o.Titulo,
                    Empresa = o.Empresa != null ? o.Empresa.NombreEmpresa : null,
                    Ubicacion = o.Ubicacion,
                    SalarioMin = o.SalarioMin,
                    SalarioMax = o.SalarioMax,
                    Descripcion = o.Descripcion,
                    FechaPublicacion = o.FechaPublicacion,
                    FechaExpiracion = o.FechaExpiracion,
                    TipoContrato = o.TipoContrato,
                    HabilidadesRequeridas = o.HabilidadesRequeridas != null ?
                        o.HabilidadesRequeridas.Select(h => new HabilidadResponse
                        {
                            IdHabilidad = h.IdHabilidad,
                            NombreHabilidad = h.Habilidad.Nombre
                        }).ToList() : new List<HabilidadResponse>(),
                    CantidadPostulaciones = o.CandidadtosOfertas != null ?
                        o.CandidadtosOfertas.Count : 0
                })
                .ToListAsync();

            return Ok(ofertas);
        }
        */


        // PUT: api/Empleos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOfertaLaboral(int id, OfertaLaboral ofertaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ofertaLaboral.ID)
            {
                return BadRequest();
            }

            db.Entry(ofertaLaboral).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaLaboralExists(id))
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

        // POST: api/Empleos/Postular
        [ResponseType(typeof(bool))]
        [Route("Postular")]
        public async Task<IHttpActionResult> Postular(int idEmpleo, int idlog)
        {
            //var ofertaLaboral = await db.OfertasLaborales.FindAsync(idEmpleo);

            var postulacion = new CandidatoOfertaLaboral
            {
                IdCandidato = idlog,
                IdOfertaLaboral = idEmpleo

            };
            
            db.CandidatosOfertaLaborales.Add(postulacion);
            //db.Entry(postulacion).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
                
            }
            catch (Exception)
            {
                return Ok(false);
                throw;
                
                
            }
            return Ok(true);




        }

        // DELETE: api/Empleos/5
        [ResponseType(typeof(OfertaLaboral))]
        public async Task<IHttpActionResult> DeleteOfertaLaboral(int id)
        {
            OfertaLaboral ofertaLaboral = await db.OfertasLaborales.FindAsync(id);
            if (ofertaLaboral == null)
            {
                return NotFound();
            }

            db.OfertasLaborales.Remove(ofertaLaboral);
            await db.SaveChangesAsync();

            return Ok(ofertaLaboral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfertaLaboralExists(int id)
        {
            return db.OfertasLaborales.Count(e => e.ID == id) > 0;
        }

        private  bool PostulacionExist(int idEmpleo, int idlog)
        {
            return db.CandidatosOfertaLaborales.Any(e => e.IdCandidato == idlog && e.IdOfertaLaboral == idEmpleo);
        }   
    }
}