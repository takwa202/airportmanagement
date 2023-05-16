using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Am.UI.WebApplicion.Controllers
{
    public class FlightController : Controller
    {

        IServiceFlight sf;
        IServicePlane sp;
        public FlightController(IServiceFlight sf,IServicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }
       // GET: FlightController/Create
                public ActionResult Create()
        {
            ViewBag.planeId =
            new SelectList(sp.GetAll(), "planeID", "Information");
            return View();
        }            
        // GET: FlightController
            public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null) { 
            return View(sf.GetAll());
            }
            else
                return View(sf.GetMany(f=>f.FlightDate==dateDepart));
        }


        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View(sf.GetById(id));
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight f,IFormFile Airline)
        {
            if (Airline != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),

                "wwwroot", "uploads", Airline.FileName);

                Stream stream = new FileStream(path, FileMode.Create);
                Airline.CopyTo(stream);
                f.Airline = Airline.FileName;
            }
            try
            {
                sf.Add(f);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.planeId =

            new SelectList(sp.GetAll(), "planeID", "Information");
            return View(sf.GetById(id));
}

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection)
        {
            try
            {
                sf.Update(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sf.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Flight collection)
        {
            try
            {
                sf.Delete(sf.GetById(id));
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
