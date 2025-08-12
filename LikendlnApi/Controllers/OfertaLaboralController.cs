using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LikendlnApi.Models;
using LikendlnApi.Models.DtoOfertaLbrl;

namespace LikendlnApi.Controllers
{
    public class OfertaLaboralController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/OfertaLaboral
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var ofertas = await db.OfertasLaborales
                .Include("Empresa")
                .ToListAsync();

            var dto = ofertas.Select(o => new DtoOfertaLaboral
            {
                ID = o.ID,
                NombreEmpresa = o.Empresa?.NombreEmpresa,
                Titulo = o.Titulo,
                Ubicacion = o.Ubicacion,
                TipoContrato = o.TipoContrato,
                SalarioMin = o.SalarioMin,
                SalarioMax = o.SalarioMax,
                Descripcion = o.Descripcion
            }).ToList();

            return Ok(dto);
        }

        // GET: api/OfertaLaboral/5
        [HttpGet]
        [ResponseType(typeof(DtoOfertaLaboral))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var o = await db.OfertasLaborales
                .Include("Empresa")
                .FirstOrDefaultAsync(x => x.ID == id);

            if (o == null)
                return NotFound();

            var dto = new DtoOfertaLaboral
            {
                ID = o.ID,
                NombreEmpresa = o.Empresa?.NombreEmpresa,
                Titulo = o.Titulo,
                Ubicacion = o.Ubicacion,
                TipoContrato = o.TipoContrato,
                SalarioMin = o.SalarioMin,
                SalarioMax = o.SalarioMax,
                Descripcion = o.Descripcion
            };

            return Ok(dto);
        }

        //// POST: api/OfertaLaboral
        //[HttpPost]
        //[ResponseType(typeof(OfertaLaboral))]
        //public async Task<IHttpActionResult> Post(CrearOfertaDto dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var nueva = new OfertaLaboral
        //    {
        //        Titulo = dto.Titulo,
        //        Ubicacion = dto.Ubicacion,
        //        TipoContrato = dto.TipoContrato,
        //        SalarioMin = dto.SalarioMin,
        //        SalarioMax = dto.SalarioMax,
        //        Descripcion = dto.Descripcion,
        //        FechaPublicacion = DateTime.Now,
        //        IdEmpresa = dto.IdEmpresa,
        //    };

        //    db.OfertasLaborales.Add(nueva);
        //    await db.SaveChangesAsync();

        //    return Ok(nueva);
        //}

        // PUT: api/OfertaLaboral/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id, CrearOfertaDto dto)
        {
            var oferta = await db.OfertasLaborales.FindAsync(id);
            if (oferta == null)
                return NotFound();

            oferta.Titulo = dto.Titulo;
            oferta.Ubicacion = dto.Ubicacion;
            oferta.TipoContrato = dto.TipoContrato;
            oferta.SalarioMin = dto.SalarioMin;
            oferta.SalarioMax = dto.SalarioMax;
            oferta.Descripcion = dto.Descripcion;
            oferta.IdEmpresa = dto.IdEmpresa;

            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/OfertaLaboral/5
        [HttpDelete]
        [ResponseType(typeof(OfertaLaboral))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var oferta = await db.OfertasLaborales.FindAsync(id);
            if (oferta == null)
                return NotFound();

            db.OfertasLaborales.Remove(oferta);
            await db.SaveChangesAsync();

            return Ok(oferta);
        }

        // POST: api/OfertaLaboral
        [HttpPost]
        [ResponseType(typeof(OfertaLaboral))]
        public async Task<IHttpActionResult> Post(CrearOfertaLaboralDto dto)
        {
            var minSql = new DateTime(1753, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Normalizar FechaPublicacion
            var pub = dto.FechaPublicacion;
            if (pub.Kind == DateTimeKind.Unspecified) pub = DateTime.SpecifyKind(pub, DateTimeKind.Utc);
            if (pub.Kind == DateTimeKind.Local) pub = pub.ToUniversalTime();
            if (pub < minSql) pub = minSql;

            // Normalizar FechaExpiracion (si no viene, asigna +30 días)
            var exp = dto.FechaExpiracion;
            if (exp == default(DateTime)) exp = pub.AddDays(30);
            if (exp.Kind == DateTimeKind.Unspecified) exp = DateTime.SpecifyKind(exp, DateTimeKind.Utc);
            if (exp.Kind == DateTimeKind.Local) exp = exp.ToUniversalTime();
            if (exp < minSql) exp = minSql;

            var oferta = new OfertaLaboral
            {
                IdEmpresa = dto.IdEmpresa,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Ubicacion = dto.Ubicacion,
                TipoContrato = dto.TipoContrato,
                SalarioMin = dto.SalarioMin,
                SalarioMax = dto.SalarioMax,
                FechaPublicacion = pub,
                FechaExpiracion = exp,
                Disponible = dto.Disponible
            };

            db.OfertasLaborales.Add(oferta);
            await db.SaveChangesAsync();

            return Ok(new { oferta.ID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
