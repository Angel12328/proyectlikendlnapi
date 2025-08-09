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
    public class FeedController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();


        // GET: api/Feed/5
        [ResponseType(typeof(FeedResponse))]
        public async Task<IHttpActionResult> GetFeed(int id)
        {
            //trae la información del candidato
            FeedResponse feedResponse = new FeedResponse();
            var candidato = await (from item in db.Candidatos
                                   where item.Id == id 
                                   select new
                                   {
                                       _Id = item.Id,
                                       _Nombre =item.Nombre,
                                       _Apellido= item.Apellido,
                                       _FotoPerfil=item.FotoPerfil,
                                       _TituloProfesional = item.TituloProfesional


                                   }).FirstOrDefaultAsync();

            
            if (candidato == null)
            {
                return NotFound();
            }
            feedResponse.IdCandidato = candidato._Id;
            feedResponse.Nombre = candidato._Nombre;
            feedResponse.Apellido = candidato._Apellido;
            feedResponse.ImagenPerfil = candidato._FotoPerfil;
            feedResponse.TituloProfesional = candidato._TituloProfesional;

            DateTime Hoy = DateTime.Now;
            var publicaciones = await db.Publicaciones
                .Where(p => DbFunctions.DiffDays(p.FechaPublicacion, Hoy) <= 180 && p.IdCandidato!=id) // Filtrar publicaciones de los últimos 180 días
                .Include(p => p.Candidato)
                .Include(p => p.Empresa)
                .Include(p => p.Comentarios)
                .Include(p => p.Comentarios.Select(com => com.AutorCandidato))
                .Include(p => p.Comentarios.Select(com => com.AutorEmpresa))
                .Select(
                    p => new PublicacionResponse
                    {
                        IdPublicacion = p.Id,
                        FechaPublicacion = p.FechaPublicacion,
                        ImagenPublicacion = p.ImagenURL,
                        IdCandidato = (int)p.IdCandidato,
                        IdEmpresa = (int)p.IdEmpresa,
                        Contenido=p.Contenido,


                        NombreCandP = p.Candidato.Nombre,
                        ApellidoCandP = p.Candidato.Apellido,
                        ImagenPerfilCandP = p.Candidato.FotoPerfil,
                        TituloProfesionalCandP = p.Candidato.TituloProfesional,


                        NombreEmpP = p.Empresa.NombreEmpresa,
                        ImagenPerfilEmpP = p.Empresa.FotoPerfil,


                        Comentarios = p.Comentarios.Select(
                                c => new ComentarioResponse
                                {
                                    IdCandidato = (int)c.IdAutorCandidato,
                                    IdEmpresa = (int)c.IdAutorEmpresa,

                                    Contenido = c.Texto,
                                    FechaComentario = c.Fecha,



                                    NombreAutor = c.AutorCandidato.Nombre,
                                    ApellidoAutor = c.AutorCandidato.Apellido,
                                    ImagenPerfilAutorCand = c.AutorCandidato.FotoPerfil,

                                    NombreEmpresaAutor = c.AutorEmpresa.NombreEmpresa,
                                    ImagenPerfilAutorEmp = c.AutorEmpresa.FotoPerfil


                                }
                            ).ToList(),


                        CantidadMeGusta = (int)p.CantidadMeGusta,
                        CantidadComentarios = (int)p.CantidadComentarios


                    }

                ).ToListAsync();
            feedResponse.Publicaciones = publicaciones;
            //Hacer una consulta para enviar las recomendaciones al candidato en el feed


            return Ok(feedResponse);
        }

        // PUT: api/Feed/5
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

        // POST: api/Feed
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

        // DELETE: api/Feed/5
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