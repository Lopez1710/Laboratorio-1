using Laboratorio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio1.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resultado() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Resultado(string Nombre,float lab1,float lab2, float lab3, float par1, float par2, float par3)
        {
            TblNotasEstudiante notas = new TblNotasEstudiante();
            double nota1 = (lab1 * 0.40) + (par1 * 0.60);
            double nota2 = (lab2 * 0.40) + (par2 * 0.60);
            double nota3 = (lab3 * 0.40) + (par3 * 0.60);

            ViewBag.Resultado = Convert.ToDecimal((nota1 + nota2 + nota3)/3);
            using (EstudianteEntities db = new EstudianteEntities())
            {
                notas.Nombre = Nombre;
                notas.lab1 = Convert.ToDecimal(lab1);
                notas.lab2 = Convert.ToDecimal(lab2);
                notas.lab3 = Convert.ToDecimal(lab3);
                notas.par1 = Convert.ToDecimal(par1);
                notas.par2 = Convert.ToDecimal(par2);
                notas.par3 = Convert.ToDecimal(par3);

                db.TblNotasEstudiante.Add(notas);
                db.SaveChanges();
                    
            }
                return View();
        }

        public ActionResult Historial() 
        {
            using (EstudianteEntities db = new EstudianteEntities()) 
            {
                var listado = db.TblNotasEstudiante.ToList();

                return View(listado);
            }

                
        }
    }
}