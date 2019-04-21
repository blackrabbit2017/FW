using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Houses.BLL;
using Houses.Model;

namespace HouseRent.Areas.Admin.Controllers
{
    public class HouseController : Controller
    {
        //
        // GET: /Admin/House/
        const int pageSize = 5;
        public ActionResult Index(int pageIndex=1)
        {
            var houseData = new HouseManager().GetAll();
            var pageList = new PagedList<House>(houseData, pageIndex, pageSize);
            return View(pageList);
        }

       
        public ActionResult Edit(int id=-1)
        {
            if (id > 0)
            {
                var house = new HouseManager().GetHouse(id);
                var streets = new StreetManager().GetList(house.Street.District.Id);
                var list = new SelectList(streets, "Id", "Name");
                ViewBag.Streets = list;
                return View(house);
            }
            return View();
        }

        //删除
        public ActionResult Delete(int id)
        {
            string msg = new HouseManager().Delete(id) ? "删除成功！" : "删除失败！";
            return Content("<script>alert('" + msg + "');location.href='/Admin';</script>");
        }

        // Ajax获取级联菜单街道数据
        public JsonResult GetStreet(int id)
        {
            var data = new StreetManager().GetList(id);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        // 新增 or 修改
        [HttpPost]
        public ActionResult Edit( House house)
        {
            if (ModelState.IsValid)
            {
                int id = house.HouseId ?? -1;
                bool ret = false;
                var manager=new HouseManager();
                if (id > 0)
                {
                    ret = manager.Update(house);
                }
                else
                {
                    house.PublishUserId = (Session["admin"] as User).LoginId;
                    ret = manager.Add(house);
                }
                string msg = ret ? "编辑成功！" : "编辑失败！";
                return Content("<script>alert('" + msg + "');location.href='/Admin';</script>");
            }

            return View(house);
        }


    }
}
