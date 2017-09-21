using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarShowroom.DAL;
using CarShowroom.Models;
using PagedList;

namespace CarShowroom.Controllers
{
	public class CarController : Controller
    {
        private CarShowroomContext db = new CarShowroomContext();

        // GET: Car
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

			var cars = from c in db.Cars
						   select c;

			if (!string.IsNullOrEmpty(search))
			{
				cars = cars.Where(s => s.Model.Contains(search)
									   || s.Brand.Contains(search));
			}

			switch (sort)
			{
				case "brand":
					cars = cars.OrderBy(c => c.Brand);
					break;
				case "model":
					cars = cars.OrderBy(c => c.Model);
					break;
				case "price":
					cars = cars.OrderBy(c => c.Price);
					break;
				default:
					cars = cars.OrderBy(c => c.CarId);
					break;
			}
			int pageSize = 3;
			int pageNumber = (page ?? 1);
			return View(cars.ToPagedList(pageNumber, pageSize));
		}

		// GET: Car/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,Brand,Model,Price,IsNew")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,Brand,Model,Price,IsNew")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
