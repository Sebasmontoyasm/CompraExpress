using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CompraExpressAPIService.Models;

namespace CompraExpressAPIService.Controllers
{
    public class UsuariosAPIController : ApiController
    {
        private integrador db = new integrador();

        // GET: api/UsuariosAPI
        public IQueryable<Usuarios> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/UsuariosAPI/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult GetUsuarios(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        // PUT: api/UsuariosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarios(int id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.Documento)
            {
                return BadRequest();
            }

            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/UsuariosAPI
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult PostUsuarios(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuarios);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsuariosExists(usuarios.Documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuarios.Documento }, usuarios);
        }

        // DELETE: api/UsuariosAPI/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult DeleteUsuarios(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarios);
            db.SaveChanges();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosExists(int id)
        {
            return db.Usuarios.Count(e => e.Documento == id) > 0;
        }
    }
}