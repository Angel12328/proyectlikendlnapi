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
    public class MiRedController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/MiRed%
        public IQueryable<Candidato> GetCandidatos()
        {
            return db.Candidatos;
        }

        // GET: api/MiRed/5
        [ResponseType(typeof(MiRedResponse))]
        public async Task<IHttpActionResult> GetMiRed(int id)
        {
            MiRedResponse miRedResponse = new MiRedResponse();
            var candidatoConexiones = await db.CandidatoCandidatoConexiones
                .Where(cc => cc.IdCandidato == id)
                .Include(cc => cc.CandidatoConexion)
                
                .Select(cc => new MiRedDataCCCResponse
                {
                    IdCandidato = cc.IdCandidatoConexion,
                    Nombre = cc.CandidatoConexion.Nombre,
                    Apellido = cc.CandidatoConexion.Apellido,
                    TituloProfesional = cc.CandidatoConexion.TituloProfesional,
                    FotoPefilCandidato = cc.CandidatoConexion.FotoPerfil
                }).ToListAsync();
            
            miRedResponse.CandidatosConexiones = candidatoConexiones;

            var empresaConexiones = await db.CandidatoEmpresaConexiones
                .Where(c => c.IdCandidato == id)
                .Include(c => c.Empresa)
                .Select(c => new MiRedDataCECResponse
                {
                    IdEmpresa = c.IdEmpresa,
                    NombreEmpresa = c.Empresa.NombreEmpresa,
                    FotoPefilEmpresa = c.Empresa.FotoPerfil

                }).ToListAsync();

            miRedResponse.EmpresasConexiones = empresaConexiones;



            return Ok(miRedResponse);
        }

        // PUT: api/MiRed/5
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
        /// aumenta los seguidores de un candidato
        /// </summary>
        /// <returns>Codigo de estado 201 si fue generado el follow</returns>
        // POST api/MiRed/SeguirCandidato
        [HttpPost]
        [Route("api/MiRed/SeguirCandidato")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> SeguirCandidatoMiRed([FromBody]SCMiRedRequest scMiRedRequest)
        {
            int idCandidatoSeguido = scMiRedRequest.IdCandidatoSeguido;
            int idCandidtoSeguidor = scMiRedRequest.IdCandidtoSeguidor;
            var candidato = await db.Candidatos.FindAsync(idCandidatoSeguido);
            if (candidato == null)
            {
                return NotFound();
            }
            CandidatoCandidatoConexiones _registro = await CandidatosSiguenExists(idCandidatoSeguido, idCandidtoSeguidor);
            if (_registro.ID>=0)
            {
                candidato.Seguidores++;
                db.Entry(candidato).State = EntityState.Modified;
                db.CandidatoSeguidoresCandidatos.Add(new CandidatoSeguidorCandidato
                {
                    IdCandidato = idCandidatoSeguido,
                    IdSeguidor = idCandidtoSeguidor
                });
                //Elimina con la conexion porque el cadidato es seguidor
                db.CandidatoCandidatoConexiones.Remove(_registro);
                try
                {

                    await db.SaveChangesAsync();


                }
                catch (Exception)
                {
                    if (!CandidatoExists(idCandidatoSeguido))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(true);

            }
            candidato.Seguidores++;
            db.Entry(candidato).State = EntityState.Modified;
            return Ok(false);

        }


        /// <summary>
        /// aumenta los seguidores de una empresa
        /// </summary>
        /// <returns>Codigo de estado 201 si fue generado el follow</returns>
        // POST api/MiRed/SeguirCandidato
        [HttpPost]
        [Route("api/MiRed/SeguirEmpresa")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> SeguirEmpresaMiRed(int idEmpresaSeguida, int idCandidatoSeguidor)
        {
            var empresa = await db.Empresas.FindAsync(idEmpresaSeguida);
            if (empresa == null)
            {
                return NotFound();
            }
            
            CandidatoEmpresaConexiones _registro = await EmpresaSiguenExists(idEmpresaSeguida, idCandidatoSeguidor);
            if (_registro.Id>=0)
            {
                empresa.Seguidores++;
                db.Entry(empresa).State = EntityState.Modified;
                db.CandidatosSeguidoresEmpresas.Add(new CandidatoSeguidorEmpresa
                {
                    IdEmpresa = idEmpresaSeguida,
                    IdCandidato = idCandidatoSeguidor
                });
                //Elimina la conexion ya que ahora es seguidor
                
                db.CandidatoEmpresaConexiones.Remove(_registro);
                try
                {
                    await db.SaveChangesAsync();


                }
                catch (Exception)
                {
                    if (!EmpresaExists(idEmpresaSeguida))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(true);
            }
            empresa.Seguidores++;
            db.Entry(empresa).State = EntityState.Modified;
            return Ok(false);

        }

        // POST: api/MiRed
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

        // DELETE: api/MiRed/5
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
        private async Task<CandidatoCandidatoConexiones> CandidatosSiguenExists(int idCandidatoSeguido,int idCandidatoSegudor )
        {
            //bool seguido = db.CandidatoSeguidoresCandidatos.Count(e => (e.IdCandidato == idCandidatoSeguido && e.IdSeguidor == idCandidatoSegudor)) > 0;
            return await db.CandidatoCandidatoConexiones
                .FirstOrDefaultAsync(e => (e.IdCandidato == idCandidatoSegudor && e.IdCandidatoConexion == idCandidatoSeguido));
   
            
        }
        private async Task<CandidatoEmpresaConexiones> EmpresaSiguenExists(int idEmpresaSeguida, int idCandidatoSeguidor)
        {
            //return db.CandidatosSeguidoresEmpresas.Count(e => (e.IdEmpresa == idEmpresaSeguida && e.IdCandidato==idCandidatoSeguidor)) > 0;

            return await db.CandidatoEmpresaConexiones
                .FirstOrDefaultAsync(e => (e.IdEmpresa == idEmpresaSeguida && e.IdCandidato == idCandidatoSeguidor));

        }
        private bool EmpresaExists(int id)
        {
            return db.Empresas.Count(e => e.ID == id) > 0;
        }

    }
}