using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
namespace DoAnKhoaIT.Areas.Guest.Controllers
{
    public class LayoutController : Controller
    {
        SGU db = new SGU();
        // GET: Guest/Layout
        public ActionResult Gioithieu1()
        {
            ViewBag.List = db.NoidungGTs.Where(s => s.MaGT == "CCTC").Select(s => s.Tieude).ToList();
            return PartialView("Gioithieu1");
        }
    }
}