using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyMVC.Models;

namespace FamilyMVC.Controllers
{
    public class MembersRelationshipsController : Controller
    {
        private FamilyMVCContext db = new FamilyMVCContext();

        // GET: MembersRelationships
        public async Task<ActionResult> Index()
        {
            var membersRelationships = db.MembersRelationships.Include(m => m.Members).Include(m => m.Relationships).Include(m => m.Relatives);
            return View(await membersRelationships.ToListAsync());
        }

        // GET: MembersRelationships/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersRelationships membersRelationships = await db.MembersRelationships.FindAsync(id);
            if (membersRelationships == null)
            {
                return HttpNotFound();
            }
            return View(membersRelationships);
        }

        // GET: MembersRelationships/Create
        public ActionResult Create()
        {
            ViewBag.MembersID = new SelectList(db.Members, "Id", "LastName");
            ViewBag.ReationshpsID = new SelectList(db.Relationships, "Id", "Kind");
            ViewBag.RelativesID = new SelectList(db.Members, "Id", "LastName");
            return View();
        }

        // POST: MembersRelationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MembersRelationshipsID,MembersID,RelativesID,ReationshpsID")] MembersRelationships membersRelationships)
        {
            if (ModelState.IsValid)
            {
                db.MembersRelationships.Add(membersRelationships);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MembersID = new SelectList(db.Members, "Id", "LastName", membersRelationships.MembersID);
            ViewBag.ReationshpsID = new SelectList(db.Relationships, "Id", "Kind", membersRelationships.ReationshpsID);
            ViewBag.RelativesID = new SelectList(db.Members, "Id", "LastName", membersRelationships.RelativesID);
            return View(membersRelationships);
        }

        // GET: MembersRelationships/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersRelationships membersRelationships = await db.MembersRelationships.FindAsync(id);
            if (membersRelationships == null)
            {
                return HttpNotFound();
            }
            ViewBag.MembersID = new SelectList(db.Members, "Id", "LastName", membersRelationships.MembersID);
            ViewBag.ReationshpsID = new SelectList(db.Relationships, "Id", "Kind", membersRelationships.ReationshpsID);
            ViewBag.RelativesID = new SelectList(db.Members, "Id", "LastName", membersRelationships.RelativesID);
            return View(membersRelationships);
        }

        // POST: MembersRelationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MembersRelationshipsID,MembersID,RelativesID,ReationshpsID")] MembersRelationships membersRelationships)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membersRelationships).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MembersID = new SelectList(db.Members, "Id", "LastName", membersRelationships.MembersID);
            ViewBag.ReationshpsID = new SelectList(db.Relationships, "Id", "Kind", membersRelationships.ReationshpsID);
            ViewBag.RelativesID = new SelectList(db.Members, "Id", "LastName", membersRelationships.RelativesID);
            return View(membersRelationships);
        }

        // GET: MembersRelationships/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembersRelationships membersRelationships = await db.MembersRelationships.FindAsync(id);
            if (membersRelationships == null)
            {
                return HttpNotFound();
            }
            return View(membersRelationships);
        }

        // POST: MembersRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MembersRelationships membersRelationships = await db.MembersRelationships.FindAsync(id);
            db.MembersRelationships.Remove(membersRelationships);
            await db.SaveChangesAsync();
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
