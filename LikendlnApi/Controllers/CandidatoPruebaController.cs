using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using LikendlnApi.Models;
using LikendlnApi.Models.Dto_Candidato;

namespace LikendlnApi.Controllers
{
    [RoutePrefix("api/Candidatos")]
    public class CandidatoPruebaController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // ===================== GET: PERFIL COMPLETO =====================
        [HttpGet]
        [Route("{id:int}/perfil")]
        public async Task<IHttpActionResult> GetPerfil(int id)
        {
            var query = db.Candidatos
                .Include(c => c.ExperienciasLaborales)
                .Include(c => c.Cursos)
                .Include(c => c.CandidatosHabilidades.Select(ch => ch.Habilidad)) // puente -> habilidad
                .Include(c => c.Publicaciones)
                .Where(c => c.Id == id)
                .Select(c => new CandidatoProfileDetailDto
                {
                    Header = new CandidatoProfileHeaderDto
                    {
                        Id = c.Id,
                        Nombre = c.Nombre,
                        Apellido = c.Apellido,
                        CoreoElectronico = c.CoreoElectronico,
                        Telefono = c.Telefono,
                        TituloProfesional = c.TituloProfesional,
                        FotoPerfil = c.FotoPerfil,
                        CurriculumVitae = c.CurriculumVitae,
                        Seguidores = c.Seguidores,
                        TotalPublicaciones = c.Publicaciones.Count(),
                        TotalCursos = c.Cursos.Count(),
                        TotalExperiencias = c.ExperienciasLaborales.Count(),
                        TotalHabilidades = c.CandidatosHabilidades.Count()
                    },
                    Experiencias = c.ExperienciasLaborales
                        .OrderByDescending(e => e.FechaFin)
                        .ThenByDescending(e => e.FechaInicio)
                        .Select(e => new ExperienciaLaboralDto
                        {
                            Id = e.ID,
                            Empresa = e.Empresa,
                            Cargo = e.Cargo,
                            FechaInicio = e.FechaInicio,
                            FechaFin = e.FechaFin,
                            Descripcion = e.Descripcion
                        }).ToList(),
                    Cursos = c.Cursos
                        .OrderByDescending(x => x.FechaFin)
                        .ThenByDescending(x => x.FechaInicio)
                        .Select(x => new CursoDto
                        {
                            Id = x.Id,
                            Nombre = x.Nombre,
                            Descripcion = x.Descripcion,
                            FechaInicio = x.FechaInicio,
                            FechaFin = x.FechaFin,
                            Institucion = x.Institucion,
                            UrlCertificado = x.UrlCertificado
                        }).ToList(),
                    Habilidades = c.CandidatosHabilidades
                        .Select(ch => new HabilidadDto
                        {
                            Id = ch.Habilidad.ID,
                            Nombre = ch.Habilidad.Nombre,
                            Descripcion = ch.Habilidad.Descripcion,
                            Categoria = ch.Habilidad.Categoria,
                            Nivel = ch.Habilidad.Nivel
                        }).ToList(),
                    PublicacionesRecientes = c.Publicaciones
                        .OrderByDescending(p => p.FechaPublicacion)
                        .Take(5)
                        .Select(p => new PublicacionResumenDto
                        {
                            Id = p.Id,
                            Fecha = p.FechaPublicacion,
                            ContenidoResumen = p.Contenido.Length > 160
                                ? p.Contenido.Substring(0, 160) + "..."
                                : p.Contenido,
                            Comentarios = p.Comentarios.Count()
                        }).ToList()
                });

            var dto = await query.FirstOrDefaultAsync();
            if (dto == null) return NotFound();

            // Duraciones en memoria
            foreach (var e in dto.Experiencias)
            {
                var fin = e.FechaFin;
                if (fin > DateTime.Now) fin = DateTime.Now;
                if (fin < e.FechaInicio) fin = e.FechaInicio;
                e.Duracion = FormatearDuracion(e.FechaInicio, fin);
            }
            foreach (var c in dto.Cursos)
            {
                var fin = c.FechaFin;
                if (fin > DateTime.Now) fin = DateTime.Now;
                if (fin < c.FechaInicio) fin = c.FechaInicio;
                c.Duracion = FormatearDuracion(c.FechaInicio, fin);
            }

            return Ok(dto);
        }

        // ===================== PUT: PERFIL BÁSICO =====================
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> PutPerfil(int id, [FromBody] CandidatoProfileUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var c = await db.Candidatos.FirstOrDefaultAsync(x => x.Id == id);
            if (c == null) return NotFound();

            c.TituloProfesional = dto.TituloProfesional;
            c.CoreoElectronico = dto.CoreoElectronico;
            c.Telefono = dto.Telefono;

            await db.SaveChangesAsync();
            return Ok();
        }

        // ===================== PUT: FOTO =====================
        [HttpPut]
        [Route("{id:int}/foto")]
        public async Task<IHttpActionResult> PutFoto(int id, [FromBody] CandidatoUpdateFotoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var c = await db.Candidatos.FirstOrDefaultAsync(x => x.Id == id);
            if (c == null) return NotFound();

            c.FotoPerfil = dto.FotoPerfil;
            await db.SaveChangesAsync();
            return Ok();
        }

        // ===================== PUT: CV =====================
        [HttpPut]
        [Route("{id:int}/cv")]
        public async Task<IHttpActionResult> PutCv(int id, [FromBody] CandidatoUpdateCvDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var c = await db.Candidatos.FirstOrDefaultAsync(x => x.Id == id);
            if (c == null) return NotFound();

            c.CurriculumVitae = dto.CurriculumVitae;
            await db.SaveChangesAsync();
            return Ok();
        }

        // ===================== POST: EXPERIENCIA =====================
        [HttpPost]
        [Route("{candidatoId:int}/experiencias")]
        public async Task<IHttpActionResult> PostExperiencia(int candidatoId, [FromBody] CrearExperienciaLaboralDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existe = await db.Candidatos.AnyAsync(c => c.Id == candidatoId);
            if (!existe) return NotFound();

            var exp = new ExperienciaLaboral
            {
                IdCandidato = candidatoId,
                Empresa = dto.Empresa,
                Cargo = dto.Cargo,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Descripcion = dto.Descripcion
            };
            db.ExperienciasLaborales.Add(exp);
            await db.SaveChangesAsync();

            return Created($"api/Candidatos/{candidatoId}/experiencias/{exp.ID}", new { exp.ID });
        }

        // ===================== POST: CURSO =====================
        [HttpPost]
        [Route("{candidatoId:int}/cursos")]
        public async Task<IHttpActionResult> PostCurso(int candidatoId, [FromBody] CrearCursoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existe = await db.Candidatos.AnyAsync(c => c.Id == candidatoId);
            if (!existe) return NotFound();

            var curso = new Curso
            {
                IdCandidato = candidatoId,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Institucion = dto.Institucion,
                UrlCertificado = dto.UrlCertificado
            };
            db.Cursos.Add(curso);
            await db.SaveChangesAsync();

            return Created($"api/Candidatos/{candidatoId}/cursos/{curso.Id}", new { curso.Id });
        }

        // ===================== POST: PUBLICACIÓN =====================
        [HttpPost]
        [Route("{candidatoId:int}/publicaciones")]
        public async Task<IHttpActionResult> PostPublicacion(int candidatoId, [FromBody] CrearPublicacionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var candidato = await db.Candidatos.FirstOrDefaultAsync(c => c.Id == candidatoId);
            if (candidato == null) return NotFound();

            var pub = new Publicacion
            {
                IdCandidato = candidatoId, // según tu modelo
                Contenido = dto.Contenido,
                FechaPublicacion = DateTime.UtcNow
            };
            db.Publicaciones.Add(pub);
            await db.SaveChangesAsync();

            return Created($"api/Candidatos/{candidatoId}/publicaciones/{pub.Id}", new { pub.Id });
        }

        // ===================== HABILIDADES (nuevo diseño) =====================

        // (A) Crear habilidad de catálogo y VINCULAR al candidato (1 solo paso)
        [HttpPost]
        [Route("{candidatoId:int}/habilidades")]
        public async Task<IHttpActionResult> PostCrearYVincularHabilidad(int candidatoId, [FromBody] CrearYAgregarHabilidadDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!await db.Candidatos.AnyAsync(c => c.Id == candidatoId)) return NotFound();

            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var h = new Habilidad
                    {
                        Nombre = dto.Nombre,
                        Descripcion = dto.Descripcion,
                        Categoria = dto.Categoria,
                        Nivel = dto.Nivel
                    };
                    db.Habilidades.Add(h);
                    await db.SaveChangesAsync();

                    var dup = await db.CandidatosHabilidades
                        .AnyAsync(ch => ch.IdCandidato == candidatoId && ch.IdHabilidad == h.ID);
                    if (!dup)
                    {
                        db.CandidatosHabilidades.Add(new CandidatoHabilidad
                        {
                            IdCandidato = candidatoId,
                            IdHabilidad = h.ID
                        });
                        await db.SaveChangesAsync();
                    }

                    tx.Commit();
                    return Created($"api/Candidatos/{candidatoId}/habilidades/{h.ID}", new { h.ID });
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        // (B) Vincular HABILIDAD EXISTENTE al candidato
        public class AddHabilidadExistenteDto { public int HabilidadId { get; set; } }

        [HttpPost]
        [Route("{candidatoId:int}/habilidades/add-existente")]
        public async Task<IHttpActionResult> PostHabilidadExistente(int candidatoId, [FromBody] AddHabilidadExistenteDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!await db.Candidatos.AnyAsync(c => c.Id == candidatoId)) return NotFound();

            var existeHab = await db.Habilidades.AnyAsync(h => h.ID == dto.HabilidadId);
            if (!existeHab) return BadRequest("Habilidad no encontrada.");

            var dup = await db.CandidatosHabilidades
                .AnyAsync(ch => ch.IdCandidato == candidatoId && ch.IdHabilidad == dto.HabilidadId);
            if (dup) return BadRequest("La habilidad ya está asociada al candidato.");

            db.CandidatosHabilidades.Add(new CandidatoHabilidad
            {
                IdCandidato = candidatoId,
                IdHabilidad = dto.HabilidadId
            });
            await db.SaveChangesAsync();

            return Created($"api/Candidatos/{candidatoId}/habilidades/{dto.HabilidadId}", new { dto.HabilidadId });
        }

        // (C) Desvincular habilidad del candidato (no borra catálogo)
        [HttpDelete]
        [Route("{candidatoId:int}/habilidades/{habilidadId:int}")]
        public async Task<IHttpActionResult> DeleteHabilidad(int candidatoId, int habilidadId)
        {
            var ch = await db.CandidatosHabilidades
                .FirstOrDefaultAsync(x => x.IdCandidato == candidatoId && x.IdHabilidad == habilidadId);
            if (ch == null) return NotFound();

            db.CandidatosHabilidades.Remove(ch);
            await db.SaveChangesAsync();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // ===================== DELETE otros =====================
        [HttpDelete]
        [Route("{candidatoId:int}/experiencias/{experienciaId:int}")]
        public async Task<IHttpActionResult> DeleteExperiencia(int candidatoId, int experienciaId)
        {
            var exp = await db.ExperienciasLaborales.FirstOrDefaultAsync(e => e.ID == experienciaId && e.IdCandidato == candidatoId);
            if (exp == null) return NotFound();
            db.ExperienciasLaborales.Remove(exp);
            await db.SaveChangesAsync();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{candidatoId:int}/cursos/{cursoId:int}")]
        public async Task<IHttpActionResult> DeleteCurso(int candidatoId, int cursoId)
        {
            var curso = await db.Cursos.FirstOrDefaultAsync(e => e.Id == cursoId && e.IdCandidato == candidatoId);
            if (curso == null) return NotFound();
            db.Cursos.Remove(curso);
            await db.SaveChangesAsync();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{candidatoId:int}/publicaciones/{publicacionId:int}")]
        public async Task<IHttpActionResult> DeletePublicacion(int candidatoId, int publicacionId)
        {
            var pub = await db.Publicaciones.FirstOrDefaultAsync(p => p.Id == publicacionId /* && p.IdCandidato == candidatoId */);
            if (pub == null) return NotFound();
            db.Publicaciones.Remove(pub);
            await db.SaveChangesAsync();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // ===================== Helpers =====================
        private static string FormatearDuracion(DateTime inicio, DateTime fin)
        {
            int totalMeses = Math.Max(0, ((fin.Year - inicio.Year) * 12) + fin.Month - inicio.Month);
            int años = totalMeses / 12;
            int meses = totalMeses % 12;
            if (años > 0 && meses > 0) return $"{años} año{(años > 1 ? "s" : "")} {meses} mes{(meses > 1 ? "es" : "")}";
            if (años > 0) return $"{años} año{(años > 1 ? "s" : "")}";
            return $"{meses} mes{(meses != 1 ? "es" : "")}";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}