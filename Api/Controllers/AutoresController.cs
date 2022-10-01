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
using Datos.Datos;

namespace Api.Controllers
{
    public class AutoresController : ApiController
    {
        private ProyectoMusicaDbContext db = new ProyectoMusicaDbContext();

        //// GET: api/Autores
        //public IQueryable<Autor> GetAutor()
        //{
        //    return db.Autor;
        //}

        //// GET: api/Autores/5
        //[ResponseType(typeof(Autor))]
        //public IHttpActionResult GetAutor(int id)
        //{
        //    Autor autor = db.Autor.Find(id);
        //    if (autor == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(autor);
        //}

        // GET: api/Empleados
        public IList<Autor> GetAutor()
        {
            IList<Autor> autoresTabla = db.Autor.ToList();
            IList<Autor> autores = new List<Autor>();
            foreach (var autorTabla in autoresTabla)
            {
                Autor autor = new Autor();
                autor.id = autorTabla.id;
                autor.nombre = autorTabla.nombre;
                autor.decripcion = autorTabla.decripcion;
                autor.imagen = autorTabla.imagen;
                autor.spotify = autorTabla.spotify;
                autor.twitter = autorTabla.twitter;

                autores.Add(autor);
            }
            return autores;
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Autor))]
        public IHttpActionResult GetAutor(int id)
        {
            Autor autorTabla = db.Autor.Find(id);
            if (autorTabla == null)
            {
                return NotFound();
            }

            Autor autor = new Autor();
            autor.id = autorTabla.id;
            autor.nombre = autorTabla.nombre;
            autor.decripcion = autorTabla.decripcion;
            autor.imagen = autorTabla.imagen;
            autor.spotify = autorTabla.spotify;
            autor.twitter = autorTabla.twitter;


            return Ok(autor);
        }




        // PUT: api/Autores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAutor(int id, Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autor.id)
            {
                return BadRequest();
            }

            db.Entry(autor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        // POST: api/Autores
        [ResponseType(typeof(Autor))]
        public IHttpActionResult PostAutor(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Autor.Add(autor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = autor.id }, autor);
        }

        // DELETE: api/Autores/5
        [ResponseType(typeof(Autor))]
        public IHttpActionResult DeleteAutor(int id)
        {
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return NotFound();
            }

            db.Autor.Remove(autor);
            db.SaveChanges();

            return Ok(autor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutorExists(int id)
        {
            return db.Autor.Count(e => e.id == id) > 0;
        }
    }
}