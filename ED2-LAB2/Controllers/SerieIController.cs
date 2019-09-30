using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace ED2_LAB2.Controllers
{
    public class SerieIController : Controller
    {
        const int bufferLength = 100;

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
            var ContadorAbecedario = 65; //Empieza en 'A' (65) y termina en 'z' (122) sin el rango [91-96]

            var NombreArchivo = Path.GetFileNameWithoutExtension(ArchivoImportado.FileName);

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
            using (var Lectura = new BinaryReader(ArchivoImportado.InputStream))
            {
                using (var writeStream = new FileStream(Server.MapPath(@"~/App_Data/" + NombreArchivo + ".cif"), FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(writeStream))
                    {
                        var byteBuffer = new byte[bufferLength];
                        while (Lectura.BaseStream.Position != Lectura.BaseStream.Length)
                        {
                            byteBuffer = Lectura.ReadBytes(bufferLength);
                            foreach (var item in byteBuffer)
                            {
                                if (DiccionarioCifrado.ContainsKey(Convert.ToChar(item)))
                                {
                                    var ByteEscrito = DiccionarioCifrado.ElementAt(Convert.ToChar(item));
                                    writer.Write(ByteEscrito);
                                }
                                else
                                {
                                    writer.Write(item);
                                }
                            }
                        }
                    }
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