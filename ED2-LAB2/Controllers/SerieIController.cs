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
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult MenuEspiral()
        {
            return View();
        }
        public ActionResult MenuCesar()
        {
            return View();
        }
        public ActionResult MenuZigZag()
        {
            return View();
        }
        public ActionResult CifradoCesar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CifradoCesar(HttpPostedFileBase ArchivoImportado, string clave)
        {
            var DiccionarioCifrado = new Dictionary<char, char>();
            var Clave = clave.ToCharArray();
            var ContadorAbecedario = 65; //Empieza en 'A' (65) y termina en 'z' (122)
            foreach (var item in Clave)
            {
                if ( !(ContadorAbecedario >= 91 && ContadorAbecedario <= 96)) {
                    if (!DiccionarioCifrado.ContainsValue(item)){
                        DiccionarioCifrado.Add(Convert.ToChar(ContadorAbecedario), item);
                        ContadorAbecedario++;
                    }
                }
            }
            for (int i = 65; i < 123; i++)
            {
                if (!(ContadorAbecedario >= 91 && ContadorAbecedario <= 96))
                {
                    if (!DiccionarioCifrado.ContainsValue(Convert.ToChar(i)) && !(i >= 91 && i <= 96))
                    {
                        DiccionarioCifrado.Add(Convert.ToChar(ContadorAbecedario), Convert.ToChar(i));
                        ContadorAbecedario++;
                    }
                }
                else {
                    i--;
                    ContadorAbecedario++;
                }
            }
            return View();
        }

        public ActionResult CifradoZigZag()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CifradoZigZag(HttpPostedFileBase ArchivoImportado, int nivel)
        {
            return View();
        }
        public ActionResult CifradoEspiral()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CifradoEspiral(HttpPostedFileBase ArchivoImportado, int Filas, int Columnas)
        {
            return View();
        }
        

    }
}