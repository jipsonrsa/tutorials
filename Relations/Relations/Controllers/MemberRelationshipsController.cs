using System;
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
    public class MemberRelationshipsController : Controller
    {
        private FamilyTreeContext db = new FamilyTreeContext();

        // GET: MemberRelationships
        public ActionResult Index()
        {
            var membersRelationships = db.MembersRelationships.Include(m => m.Members).Include(m => m.Relationships).Include(m => m.Relatives);
            return View(membersRelationships.ToList());
        }

        // GET: MemberRelationships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberRelationships memberRelationships = db.MembersRelationships.Find(id);
            if (memberRelationships == null)
            {
                return HttpNotFound();
            }
            return View(memberRelationships);
        }

        // GET: MemberRelationships/Create
        public ActionResult Create()
        {
            ViewBag.MembersID = new SelectList(db.Members, "Id", "FullName");
            ViewBag.ReationshpsID = new SelectList(db.Relationships, "Id", "Kind");
            ViewBag.RelativesID = new SelectList(db.Members, "Id", "FullName");
            return View();
        }

        // POST: MemberRelationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MembersRelationshipsID,MembersID,RelativesID,ReationshpsID")] MemberRelationships memberRelationships)
        {
            if (ModelState.IsValid)
            {
                
                db.MembersRelationships.Add(memberRelationships);
                db.SaveChanges();
                // Section to create reverse relationship
                Relationships relationshipDetails = db.Relationships.Find(memberRelationships.ReationshpsID);
                MemberRelationships reverseRelationship = new MemberRelationships { MembersID = memberRelationships.RelativesID, ReationshpsID = (int)relationshipDetails.ReverseRelationshipId, RelativesID = memberRelationships.MembersID };
                db.MembersRelationships.Add(reverseRelationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MembersID = new SelectList(db.Members, "Id", "FullName", memberRelationships.MembersID);
            ViewBag.ReationshpsID = new SelectList(db.Relationships, "Id", "Kind", memberRelationships.ReationshpsID);
            ViewBag.RelativesID = new SelectList(db.Members, "Id", "FullName", memberRelationships.RelativesID);
            return View(memberRelationships);
        }

        // GET: MemberRelationships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberRelationships memberRelationships = db.MembersRelationships.Find(id);
            if (memberRelationships == null)
            {
                return HttpNotFound();
            }
            ViewBag.MembersID = new SelectList(db.Members, "Id", "FullName", memberRelationships.MembersID);
            ViewBag.ReationshpsID = new SelectList(db.Relationships, "Id", "Kind", memberRelationships.ReationshpsID);
            ViewBag.RelativesID = new SelectList(db.Members, "Id", "FullName", memberRelationships.RelativesID);
            return View(memberRelationships);
        }

        // POST: MemberRelationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MembersRelationshipsID,MembersID,RelativesID,ReationshpsID")] MemberRelationships memberRelationships)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberRelationships).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MembersID = new SelectList(db.Members, "Id", "FullName", memberRelationships.MembersID);
            ViewBag.ReationshpsID = new SelectList(db.Relationships, "Id", "Kind", memberRelationships.ReationshpsID);
            ViewBag.RelativesID = new SelectList(db.Members, "Id", "FullName", memberRelationships.RelativesID);
            return View(memberRelationships);
        }

        // GET: MemberRelationships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberRelationships memberRelationships = db.MembersRelationships.Find(id);
            if (memberRelationships == null)
            {
                return HttpNotFound();
            }
            return View(memberRelationships);
        }

        // POST: MemberRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberRelationships memberRelationships = db.MembersRelationships.Find(id);
            db.MembersRelationships.Remove(memberRelationships);
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
