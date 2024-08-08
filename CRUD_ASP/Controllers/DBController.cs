using CRUD_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_ASP.Controllers
{
    public class DBController : Controller
    {
        // GET: DB
        public ActionResult Index()
        {
            using (DBColegio context = new DBColegio())
            {
                return View(context.alumno.ToList());
            }
            
        }

        // GET: DB/Details/5
        public ActionResult Details(int id)
        {
            using(DBColegio context = new DBColegio())
            {
                return View(context.alumno.Where(x => x.id == id).FirstOrDefault());
            }
            
        }

        // GET: DB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DB/Create
        [HttpPost]
        public ActionResult Create(alumno alumnos)
        {
            try
            {
                using (DBColegio context = new DBColegio())
                {
                    context.alumno.Add(alumnos);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DB/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBColegio context = new DBColegio())
            {
                return View(context.alumno.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: DB/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, alumno alumnos)
        {
            try
            {
                using (DBColegio context = new DBColegio())
                {
                    context.Entry(alumnos).State = System.Data.EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DB/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBColegio context = new DBColegio())
            {
                return View(context.alumno.Where(x => x.id == id));
            }
        }

        // POST: DB/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DBColegio context = new DBColegio())
                {
                    alumno alumnito = context.alumno.Where(x=>x.id == id).FirstOrDefault();
                    context.alumno.Remove(alumnito);
                    context.SaveChanges();  
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
