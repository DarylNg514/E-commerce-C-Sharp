using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetFrancois.Models;

namespace ProjetFrancois.Controllers
{
    public class produitsController : Controller
    {
        private DbEcommerce db = new DbEcommerce();

        // GET: produits
        public ActionResult Index()
        {
            var produit = db.produit.Include(p => p.Categorie);
            return View(produit.ToList());
        }
        // GET: produits client
        public ActionResult Index_client()
        {
            var produit = db.produit.Include(p => p.Categorie);
            return View(produit.ToList());
        }

        // GET: produits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produit produit = db.produit.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: produits/Create
        public ActionResult Create()
        {
            ViewBag.IdCategorie = new SelectList(db.category, "IdCategorie", "Name");
            return View();
        }

        // POST: produits/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idproduit,image,prix,IdCategorie")] produit produit)
        {
            if (ModelState.IsValid)
            {
                db.produit.Add(produit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategorie = new SelectList(db.category, "IdCategorie", "Name", produit.IdCategorie);
            return View(produit);
        }

        // GET: produits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produit produit = db.produit.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategorie = new SelectList(db.category, "IdCategorie", "Name", produit.IdCategorie);
            return View(produit);
        }

        // POST: produits/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idproduit,image,prix,IdCategorie")] produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategorie = new SelectList(db.category, "IdCategorie", "Name", produit.IdCategorie);
            return View(produit);
        }

        // GET: produits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produit produit = db.produit.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produit produit = db.produit.Find(id);
            db.produit.Remove(produit);
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
        public ActionResult Ajouterpanier()
         {
             return RedirectToAction("Index","paniers");
         }

         [HttpPost]
        public ActionResult Ajouterpanier(int id)
        {
            DbEcommerce db = new DbEcommerce();

                // Si le produit n'est pas déjà dans le panier, l'ajouter
                var produit = db.produit.FirstOrDefault(pd => pd.idproduit == id);

                if (produit != null)
                {
                    var panier = new panier
                    {
                        image = produit.image,
                        prix = produit.prix,
                    };
                    db.panier.Add(panier);
                    db.SaveChanges();
            }

            return RedirectToAction("Index", "paniers");
        }

        public ActionResult payer()
         {
             return View("Payer");
         }

    }
}
