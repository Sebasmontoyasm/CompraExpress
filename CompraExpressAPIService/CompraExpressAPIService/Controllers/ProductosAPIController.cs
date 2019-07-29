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
    public class ProductosAPIController : ApiController
    {
        private integrador db = new integrador();

        // GET: api/ProductosAPI
        public IQueryable<Productos> GetProductos()
        {
            return db.Productos;
        }

        // GET: api/ProductosAPI/5
        [ResponseType(typeof(Productos))]
        public IHttpActionResult GetProductos(int id)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        // PUT: api/ProductosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductos(int id, Productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productos.Id)
            {
                return BadRequest();
            }

            db.Entry(productos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
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

        // POST: api/ProductosAPI
        [ResponseType(typeof(Productos))]
        public IHttpActionResult PostProductos(Productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Productos.Add(productos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productos.Id }, productos);
        }

        // DELETE: api/ProductosAPI/5
        [ResponseType(typeof(Productos))]
        public IHttpActionResult DeleteProductos(int id)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return NotFound();
            }

            db.Productos.Remove(productos);
            db.SaveChanges();

            return Ok(productos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductosExists(int id)
        {
            return db.Productos.Count(e => e.Id == id) > 0;
        }
    }
}