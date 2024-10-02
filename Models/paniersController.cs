using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetFrancois.Models
{
    public class paniersController : Controller
    {
        private DbEcommerce db = new DbEcommerce();

        // GET: paniers
        public ActionResult Index()
        {
            return View(db.panier.ToList());
        }

        // GET: paniers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            panier panier = db.panier.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // GET: paniers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: paniers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPanier,image,prix")] panier panier)
        {
            if (ModelState.IsValid)
            {
                db.panier.Add(panier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(panier);
        }

        // GET: paniers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            panier panier = db.panier.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // POST: paniers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPanier,image,prix")] panier panier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(panier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(panier);
        }

        // GET: paniers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            panier panier = db.panier.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // POST: paniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            panier panier = db.panier.Find(id);
            db.panier.Remove(panier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
