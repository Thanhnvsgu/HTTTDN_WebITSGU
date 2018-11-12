using DoAnKhoaIT.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnKhoaIT.Areas.Admin.Controllers
{
    public class BaidangController : BaseController
    {
        // GET: Admin/Baidang
        public ActionResult Index()
        {
            return View();
        }
    }
}