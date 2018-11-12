﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModel;
using Model.DAO.Guest;
namespace DoAnKhoaIT.Areas.Guest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Guest/Home
        public ActionResult Index()
        {
            View3baidang model = new View3baidang();
            HomeDAO dao = new HomeDAO();
            model.v1 = dao.Load3baidang("TT");
            model.v2 = dao.Load3baidang("SK");
            model.v3 = dao.Load3baidang("TS");
            model.v4 = dao.ListALL();
            return View(model);
        }
    }
}