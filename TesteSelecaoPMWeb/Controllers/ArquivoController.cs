using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestePMWeb.Controllers
{
    public class ArquivoController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public ArquivoController(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public class Imagem
        {
            public string Arquivo { get; set; }

            public string Nome { get; set; }

            public string Status { get; set; }
        }

        [HttpPost]
        public JsonResult Upload()
        {
            Imagem imagem = new Imagem();

            try
            {
                if (HttpContext.Request.Form.Files != null)
                {
                    string PathDB = "";

                    var files = HttpContext.Request.Form.Files;

                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            imagem.Nome = file.FileName;

                            string key = Convert.ToString(Guid.NewGuid()) + "_";

                            string extension = Path.GetExtension(file.FileName);

                            imagem.Arquivo = key + DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss_ff") + extension;

                            PathDB = "wwwroot/Uploads/" + imagem.Arquivo;

                            using (FileStream fs = System.IO.File.Create(PathDB))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }

                            imagem.Status = "OK";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                imagem.Status = "Erro";
            }

            return Json(imagem);
        }
    }
}
