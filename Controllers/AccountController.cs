using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Enursery3ccf.Models;

namespace Enursery3ccf.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        
        public ActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegister(User user)
        {
            if (ModelState.IsValid)
            {
                using (ENDbContext db = new ENDbContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " successfully registered.";
            }
            return RedirectToAction("UserAuthenticate");
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult UserLogin(User user)
        {
            
                using (ENDbContext db = new ENDbContext())
                {
                    var usr = db.Users.Single(u => u.Username == user.Username && u.Password == user.Password);

                    if (usr != null)
                    {
                        Session["UserID"] = usr.UserId.ToString();
                        Session["Username"] = usr.Username.ToString();

                        return RedirectToAction("Index", "User");
                    }
                    else
                    {

                        ModelState.AddModelError("", "Username or Password is wrong.");
                        return View("UserLogin");
                    }
                }
           
        }
        public ActionResult UserAuthenticate()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }

        public ActionResult NurseryRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NurseryRegister(Nursery nursery)
        {
            if (ModelState.IsValid)
            {
                using (ENDbContext db = new ENDbContext())
                {
                    db.Nurseries.Add(nursery);
                    db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = nursery.NurseryName + " which is at location " + nursery.Location + " successfully registered.";
            }
            return RedirectToAction("NurseryAuthenticate");
        }

        public ActionResult NurseryLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NurseryLogin(Nursery nursery)
        {
            
                using (ENDbContext db = new ENDbContext())
                {
                    var nrsry = db.Nurseries.Single(n => n.NUserName == nursery.NUserName && n.Password == nursery.Password);

                    if (nrsry != null)
                    {
                        Session["NurseryId"] = nrsry.NurseryId.ToString();
                        Session["NUserName"] = nrsry.NUserName.ToString();
                        return RedirectToAction("Index", "Nursery");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nursery Username or Password is wrong.");
                        return View("NurseryLogin");
                    }
                }
            
                
        }
        public ActionResult NurseryAuthenticate()
        {
            if (Session["NurseryId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("NurseryLogin");
            }
        }




        /*public ActionResult AdminRegister()
        {
            return View();
        }*/

        /*[HttpPost]
        public ActionResult AdminRegister(Admin admin)
        {
            if (ModelState.IsValid)
            {
                using (ENDbContext db = new ENDbContext())
                {
                    db.Admins.Add(admin);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }

                ModelState.Clear();
                ViewBag.Message = "Admin having Id "+ admin.AdminId + " and Admin User name as " + admin.AUsername + " successfully registered.";
            }
            return View();
        }*/

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                using (ENDbContext db = new ENDbContext())
                {
                    var usr = db.Admins.Single(a => a.AUsername == admin.AUsername && a.Password == admin.Password);

                    if (usr != null)
                    {
                        Session["AdminID"] = usr.AdminId.ToString();
                        Session["AUsername"] = usr.AUsername.ToString();
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Admin Username or Password is wrong.");
                        return View("AdminLogin");
                    }
                }
            }
            return View();
        }
        /*public ActionResult AdminAuthenticate()
        {
            if (Session["AdminId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }*/

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}