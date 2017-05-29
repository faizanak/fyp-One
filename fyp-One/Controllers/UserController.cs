using fyp_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fyp_One.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private db_fypEntities db = new db_fypEntities();
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "User");
        }
        public ActionResult LogIn()
        {
            if (Session["User"] == null)
            {
                return View();

            }
            string type = ((fyp_One.Models.User)Session["User"]).type;
            if (type.Equals("admin")) {
                return RedirectToAction("Profile", "Dashboard");
            }
            return RedirectToAction("Index", "Home");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserLogInVM model)
        {
            if (ModelState.IsValid)
            {

                var user = db.Users.Where(u => u.email.Equals(model.LogInEmail) && u.password.Equals(model.LogInPassword)).SingleOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("", "Login Failed with given Information");
                }
                else
                {
                    Session["User"] = user;
                    if (user.type.Equals("admin"))
                    {
                        return RedirectToAction("Profile", "Dashboard");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            UserIndex userIndexModel = new UserIndex();
            userIndexModel.logIn = model;
            ViewBag.activeTab = "login";

            return View("Index", userIndexModel);


        }
        public ActionResult SignUp()
        {
            if (Session["User"] == null)
            {
                return View();

            }
            else { return RedirectToAction("Index", "Home"); }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserSignUpVM model)
        {
            if (Session["User"] == null)
            {
                if (ModelState.IsValid)
                {

                    var email = db.Users.Where(e => e.email.ToLower().Equals(model.SignUpEmail.ToLower())).SingleOrDefault();
                    if (email != null)
                    {
                        ModelState.AddModelError("SignUpEmail", "Email already exists. Please enter a different Email.");
                    }
                    if (ModelState.IsValid)
                    {
                        User user = new User
                        {   
                            first_name=model.FirstName,
                            last_name=model.LastName,
                            email = model.SignUpEmail.ToLower(),
                            password = model.SignUpPassword,
                            status = true
                        };
                        db.Users.Add(user);
                        db.SaveChanges();
                        Session["User"] = user;

                        return RedirectToAction("Index", "Home");

                    }

                }

            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
            UserIndex userIndexModel = new UserIndex();
            userIndexModel.signUp = model;
            ViewBag.activeTab = "signup";
            return View("Index", userIndexModel);
        }

        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                UserIndex model = new UserIndex();
                return View(model);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}