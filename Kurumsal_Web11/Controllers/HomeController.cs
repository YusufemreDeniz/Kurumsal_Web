using Kurumsal_Web11.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Kurumsal_Web11.Controllers
{
    public class HomeController : Controller
    {

        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Home
        public ActionResult Index(int Sayfa=1)
        {
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetID);

            return View();
        }

        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x => x.SliderId));
        }
        public ActionResult HizmetPartial()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetID));
        }
        public ActionResult Hakkimizda()
        {
            return View(db.Hakkimizda.SingleOrDefault());
        }
        public ActionResult Hizmetlerimiz()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetID));
        }
        public ActionResult Iletisim()
        {
            return View(db.Iletisim.SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Iletisim(string adsoyad = null, string email = null, string konu = null, string mesaj = null)
        {
            if (adsoyad != null && email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.UserName = "kurumsal.web11@gmail.com";
                WebMail.Password = "aqou qgan mzvt vztp"; // Gmail şifreniz veya uygulama şifresi
                WebMail.EnableSsl = true; // Güvenli bağlantıyı etkinleştirin
                WebMail.SmtpPort = 587; // Standart TLS portunu kullanın
                WebMail.Send("kurumsal.web11@gmail.com ", konu, email + "-" + mesaj);
                ViewBag.Uyari = "Mesajınız başarı ile gönderilmiştir!!";
            }
            else
            {
                ViewBag.Uyari = "Hata Oluştu! Tekrar Deneyiniz!";
            }
            return View(db.Iletisim.SingleOrDefault());
        }
        public ActionResult Blog(int Sayfa=1)
        {
            return View(db.Blog.Include("Kategori").OrderByDescending(x => x.BlogId).ToPagedList(Sayfa,3));
        }
        public ActionResult BlogDetay(int id)
        {
            var blog = db.Blog.Include("Kategori").Where(x => x.BlogId == id).SingleOrDefault();
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        public ActionResult BlogKAtegoriPartial()
        {
            return PartialView(db.Kategori.Include("Blogs").ToList().OrderBy(x => x.KategoriAd));
        }
        public ActionResult BlogKayitPartial()
        {
            return PartialView(db.Blog.ToList().OrderByDescending(x=>x.BlogId));
        }
        public ActionResult FooterPartial()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetID);

            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();

            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);

            return PartialView();
        }

    }
}