using Kurumsal_Web11.Models.DataContext;
using Kurumsal_Web11.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kurumsal_Web11.Controllers
{
    public class KimlikController : Controller
    {
        KurumsalDBContext db=new KurumsalDBContext();
        // GET: Kimlik
        public ActionResult Index()
        {
            return View(db.Kimlik.ToList());
        }


        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik=db.Kimlik.Where(x=>x.KimlikId==id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]//edit sayfasından gönderilen güvenlik önlemini karşılayan 
        public ActionResult Edit(int id, Kimlik kimlik,HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
                var k=db.Kimlik.Where(x=>x.KimlikId == id).SingleOrDefault();
            }

            return View();
        }
    }
}
