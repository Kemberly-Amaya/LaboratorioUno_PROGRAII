using AppWebEstudiante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebEstudiante.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas
        public ActionResult Historial()
        {
            using (EstudianteEntities Db = new EstudianteEntities())
            {

                var listaEstudiantes = Db.TblNotasEstudiante.ToList();

                return View(listaEstudiantes);

            }

        }
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Resultado(String nombre, String notaLab1, String notaLab2,
            String notaLab3, String notaPar1, String notaPar2, String notaPar3)
        {


            using (EstudianteEntities Db = new EstudianteEntities())
            {

                TblNotasEstudiante tB = new TblNotasEstudiante();
                tB.Nombre = nombre;
                tB.Lab1 = notaLab1;
                tB.Lab2 = notaLab2;
                tB.Lab3 = notaLab3;
                tB.Par1 = notaPar1;
                tB.Par2 = notaPar2;
                tB.Par3 = notaPar3;

                Db.TblNotasEstudiante.Add(tB);
                Db.SaveChanges();

            }
            Double Lb1 = Convert.ToDouble(notaLab1);
            Double Pr1 = Convert.ToDouble(notaPar1);
            Double Lb2 = Convert.ToDouble(notaLab2);
            Double Pr2 = Convert.ToDouble(notaPar2);
            Double Lb3 = Convert.ToDouble(notaLab3);
            Double Pr3 = Convert.ToDouble(notaPar3);

            //Cálculos
            Double Lab1 = Lb1 * 0.40;
            Double Lab2 = Lb2 * 0.40;
            Double Lab3 = Lb3 * 0.40;
            Double Par1 = Pr1 * 0.60;
            Double Par2 = Pr2 * 0.60;
            Double Par3 = Pr3 * 0.60;

            //Promedios
            Double Prom1 = Math.Round(((Lab1 + Par1) / 3),2);
            Double Prom2 = Math.Round(((Lab2 + Par2) / 3), 2);
            Double Prom3 = Math.Round(((Lab3 + Par3) / 3), 2);

            //Promedio Final
            Double PFinal = Prom1 + Prom2 + Prom3;

            ViewBag.nombre = nombre;
            ViewBag.prom1 = Prom1;
            ViewBag.prom2 = Prom2;
            ViewBag.prom3 = Prom3;
            ViewBag.pFinal = PFinal;


            return View();
        }

    

    }

}