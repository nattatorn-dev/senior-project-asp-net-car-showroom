using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarShowroom.DAL;
using CarShowroom.Models;
using PagedList;

namespace CarShowroom.Controllers
{
	public class WorkerController : Controller
    {
        private CarShowroomContext db = new CarShowroomContext();

        // GET: Worker
		public ViewResult Index(string sort, string filter, string search, int? page)
		{
			ViewBag.CurrentSort = sort;

			if (search != null)
			{
				page = 1;
			}
			else
			{
				search = filter;
			}

			ViewBag.CurrentFilter = search;

			var workers = from w in db.Workers
							select w;

			if (!string.IsNullOrEmpty(search))
			{
				workers = workers.Where(s => s.LastName.Contains(search)
									   || s.FirstName.Contains(search));
			}

			switch (sort)
			{
				case "firstname":
					workers = workers.OrderBy(c => c.FirstName);
					break;
				case "lastname":
					workers = workers.OrderBy(c => c.LastName);
					break;
				case "cnum":
					workers = workers.OrderBy(c => c.Pesel);
					break;
				case "city":
					workers = workers.OrderBy(c => c.City);
					break;
				default:
					workers = workers.OrderBy(c => c.WorkerId);
					break;
			}

			int pageSize = 3;
			int pageNumber = (page ?? 1);
			return View(workers.ToPagedList(pageNumber, pageSize));
		}

		// GET: Worker/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Worker/Create
        public ActionResult Create()
        {
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Title");
            return View();
        }

        // POST: Worker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerId,LastName,FirstName,Pesel,City,Street,StreetNumber,PositionId")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Title", worker.PositionId);
            return View(worker);
        }

        // GET: Worker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Title", worker.PositionId);
            return View(worker);
        }

        // POST: Worker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerId,LastName,FirstName,Pesel,City,Street,StreetNumber,PositionId")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Title", worker.PositionId);
            return View(worker);
        }

        // GET: Worker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Worker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = db.Workers.Find(id);
            db.Workers.Remove(worker);
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
