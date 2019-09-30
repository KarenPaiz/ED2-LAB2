using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ED2_LAB2.Controllers
{
    public class SerieIController : Controller
    {
        // GET: SerieI
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CifradoZigZag()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CifradoZigZag(HttpPostedFileBase ArchivoImportado)
        {
            return View();
        }
        public ActionResult CifradoEspiaral()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CifradoEspiral(HttpPostedFileBase ArchivoImportado)
        {
            return View();
        }
        public ActionResult CifradoCesar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CifradoCesar(HttpPostedFileBase ArchivoImportado)
        {
            return View();
        }

    }
}