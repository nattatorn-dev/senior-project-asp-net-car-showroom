using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarShowroom.DAL;
using CarShowroom.Models;
using PagedList;

namespace CarShowroom.Controllers
{
	public class PositionController : Controller
    {
        private CarShowroomContext db = new CarShowroomContext();

        // GET: Position
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

			var positions = from c in db.Positions
						  select c;

			if (!string.IsNullOrEmpty(search))
			{
				positions = positions.Where(s => s.Title.Contains(search));
			}

			switch (sort)
			{
				case "title":
					positions = positions.OrderBy(p => p.Title);
					break;
				case "salary":
					positions = positions.OrderBy(p => p.Salary);
					break;
				default:
					positions = positions.OrderBy(p => p.PositionId);
					break;
			}

			int pageSize = 3;
			int pageNumber = (page ?? 1);
			return View(positions.ToPagedList(pageNumber, pageSize));
		}

		// GET: Position/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Position/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Position/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionId,Title,Salary,IsFullTime,IsContract")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(position);
        }

        // GET: Position/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Position/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionId,Title,Salary,IsFullTime,IsContract")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Position/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
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
