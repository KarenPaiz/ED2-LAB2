using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using ED2_LAB2.Models;


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
        public ActionResult CifradoCesar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CifradoCesar(HttpPostedFileBase ArchivoImportado, string clave, string Opcion)
        {
            var OpcionDeCifrado = true;
            if (Opcion == "Descifrar"){
                OpcionDeCifrado = false;
            }
            var ExtensionNuevoArchivo = string.Empty;
            var NombreArchivo = Path.GetFileNameWithoutExtension(ArchivoImportado.FileName);
            var ExtensionArchivo = Path.GetExtension(ArchivoImportado.FileName);
            if (ArchivoImportado != null)
            {
                
                var DiccionarioCifrado = new Dictionary<char, char>();
                var Cesar = new SerieIModel();
                DiccionarioCifrado = Cesar.DiccionarioCesar(clave,OpcionDeCifrado);
               
                if (!OpcionDeCifrado && ExtensionArchivo == ".cif")
                {
                    ExtensionNuevoArchivo = ".txt";
                }
                if (OpcionDeCifrado && ExtensionArchivo == ".txt")
                {
                    ExtensionNuevoArchivo = ".cif";
                }
                if(ExtensionNuevoArchivo!=null)
                {
                    using (var Lectura = new BinaryReader(ArchivoImportado.InputStream))
                    {
                        using (var writeStream = new FileStream(Server.MapPath(@"~/App_Data/" + NombreArchivo + ExtensionNuevoArchivo), FileMode.OpenOrCreate))
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
                                            var ByteEscrito = DiccionarioCifrado[Convert.ToChar(item)];
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
                }
                else
                {
                    //Danger("El archivo tiene un formato erroneo.", true);
                }

            }
            else
            {
                //Danger("El archivo es nulo.", true);
            }
            var FileVirtualPath = @"~/App_Data/" + NombreArchivo + ExtensionNuevoArchivo;
            return File(FileVirtualPath, "application / force - download", Path.GetFileName(FileVirtualPath));
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