using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoControl.Controllers
{
    public class GeolocalizacionController : Controller
    {
        // GET: Geolocalizacion
        public ActionResult Geo()
        {
            return View();
        }


        // GET: Geolocalizacion
        public ActionResult GeoAdmin()
        {
            return View();
        }



        // GET: Geolocalizacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Geolocalizacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Geolocalizacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Geo));
            }
            catch
            {
                return View();
            }
        }

        // GET: Geolocalizacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Geolocalizacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Geo));
            }
            catch
            {
                return View();
            }
        }

        // GET: Geolocalizacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Geolocalizacion/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Geo));
            }
            catch
            {
                return View();
            }
        }
    }
}