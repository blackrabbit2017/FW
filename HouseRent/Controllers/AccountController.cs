using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Houses.Model;
using Houses.BLL;

namespace HouseRent.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }

        //登录
        [HttpPost]
        public ActionResult Login([Bind(Include = "LoginName,Password")]User user)
        {
            ModelState.Remove("UserName");
            ModelState.Remove("Telephone");
            ModelState.Remove("RePassword");
            if(ModelState.IsValid )
            {
                if (new UserManager().Login(user, out user))
                {
                    Session["admin"] = user;
                    return Redirect("~/Admin");
                }
                else
                {
                    return Content("<script>alert('用户名或密码错误！');history.back();</script>");
                }
            }
            return View(user);
        }


        public ActionResult Register()
        {
            return View();
        }

        //注册
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (new UserManager().Register(user))
                {
                    return Content("<script>alert('注册成功！');location.href='Login';</script>"); 
                }
                else
                {
                    return Content("<script>alert('信息填写有误！');history.back();</script>");
                }
            }
            return View(user);
        }

        //退出
        public ActionResult Out()
        {
            Session["admin"] = null;
            return RedirectToAction("Login");
        }

    }
}
