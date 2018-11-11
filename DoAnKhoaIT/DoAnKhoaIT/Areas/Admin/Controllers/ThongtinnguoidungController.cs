using DoAnKhoaIT.Controllers;
using Model.DAO.Admin;
using Model.EF;
using Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnKhoaIT.Areas.Admin.Controllers
{
    public class ThongtinnguoidungController : BaseController
    {
        // GET: Admin/Thongtinnguoidung
        public ActionResult Index()
        {
            var dao = new ThongtinnguoidungDao();
            ThongtinnguoidungModel res = new ThongtinnguoidungModel();
            res.listtaikhoan = dao.Listtaikhoan();
            res.listchucvu = dao.Listchucvu();
            res.listquyen = dao.Listquyen();
            ViewBag.Ichucvu = dao.Ichucvu();
            ViewBag.Itrangthai = dao.ITrangthai;
            ViewBag.bang = "bang";
            ViewBag.show = "false";
            ViewBag.check = "false";
            return View(res);
        }
        public JsonResult Themtaikhoan(string taikhoan, string thongtinnguoidung)
        {
            // convert
            Taikhoan taikhoanres = JsonConvert.DeserializeObject<Taikhoan>(taikhoan);
            Thongtinnguoidung thongtinnguoidungres = JsonConvert.DeserializeObject<Thongtinnguoidung>(thongtinnguoidung);

            var dao = new ThongtinnguoidungDao();

            var check = dao.timtaikhoan(taikhoanres.Tentaikhoan);

            if (check != null)
            {
                return Json(new
                {
                    status = false
                });
            }

            dao.Themtaikhoan(taikhoanres);
            dao.Themthongtin(thongtinnguoidungres);

            // load lai gia tri
            var tk = dao.timtaikhoan(taikhoanres.Tentaikhoan);
            
            var res = new
            {
                tentaikhoan = tk.Tentaikhoan,
                matkhau = tk.Matkhau,
                trangthai = tk.Trangthaihd,
                TGdangky = tk.TGdangki.ToString(),
                flag = tk.Flag
            };

            return Json(new
            {
                status = true,
                result = res
            });
        }
        [HttpPost]
        public JsonResult ChangeStatusTaikhoan(string id)
        {
            var res = new ThongtinnguoidungDao().changeStatusTaikhoan(id);
            return Json(new
            {
                status = res
            });
        }
        [HttpPost]
        public JsonResult ChangeStatusChucvu(string id)
        {
            var res = new ThongtinnguoidungDao().changeStatusChucvu(id);
            return Json(new
            {
                status = res
            });
        }
        [HttpPost]
        public JsonResult LoadSuataikhoan(string id)
        {
            var res = new ThongtinnguoidungDao().timtaikhoan(id);
            var res2 = new ThongtinnguoidungDao().timthongtin(id);
            string tt = res2.Namsinh.Value.ToShortDateString().ToString();
            var result = new
            {
                tentaikhoan = res.Tentaikhoan,
                matkhau = res.Matkhau,
                hoten = res2.Hoten,
                mail = res2.Gmail,
                machucvu = res2.Machucvu,
                ngaysinh = tt,
                sdt = res2.Sodienthoai,
                quequan = res2.Quequan
            };
            return Json(new
            {
                Jtaikhoan = result
            });
        }
    }
}