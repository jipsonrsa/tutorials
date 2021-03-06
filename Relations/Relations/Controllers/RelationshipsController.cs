﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Relations.DAL;
using Relations.Models;

namespace Relations.Controllers
{
    public class RelationshipsController : Controller
    {
        private FamilyTreeContext db = new FamilyTreeContext();

        // GET: Relationships
        public ActionResult Index()
        {
            var relationships = db.Relationships.Include(r => r.ReverseRelationship);
            return View(relationships.ToList());
        }

        // GET: Relationships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationships relationships = db.Relationships.Find(id);
            if (relationships == null)
            {
                return HttpNotFound();
            }
            return View(relationships);
        }

        // GET: Relationships/Create
        public ActionResult Create()
        {
            ViewBag.ReverseRelationshipId = new SelectList(db.Relationships, "Id", "Kind");
            return View();
        }

        // POST: Relationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kind,InCrown,ReverseRelationshipId")] Relationships relationships)
        {
            if (ModelState.IsValid)
            {
                db.Relationships.Add(relationships);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReverseRelationshipId = new SelectList(db.Relationships, "Id", "Kind", relationships.ReverseRelationshipId);
            return View(relationships);
        }

        // GET: Relationships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationships relationships = db.Relationships.Find(id);
            if (relationships == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReverseRelationshipId = new SelectList(db.Relationships, "Id", "Kind", relationships.ReverseRelationshipId);
            return View(relationships);
        }

        // POST: Relationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kind,InCrown,ReverseRelationshipId")] Relationships relationships)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationships).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReverseRelationshipId = new SelectList(db.Relationships, "Id", "Kind", relationships.ReverseRelationshipId);
            return View(relationships);
        }

        // GET: Relationships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationships relationships = db.Relationships.Find(id);
            if (relationships == null)
            {
                return HttpNotFound();
            }
            return View(relationships);
        }

        // POST: Relationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Relationships relationships = db.Relationships.Find(id);
            db.Relationships.Remove(relationships);
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
