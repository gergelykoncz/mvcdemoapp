using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMvcApp.Models;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private static Dictionary<int, UserModel> cache = new Dictionary<int, UserModel>()
        {
            { 1, new UserModel(){ Id=1, Age=23, Email="a@a.aa", UserName="User1"} },
            { 2, new UserModel(){ Id=2, Age=43, Email="b@a.aa", UserName="User2"} },
            { 3, new UserModel(){ Id=3, Age=29, Email="c@a.aa", UserName="User3"} },
            { 4, new UserModel(){ Id=4, Age=65, Email="d@a.aa", UserName="User4"} },
            { 5, new UserModel(){ Id=5, Age=23, Email="e@a.aa", UserName="User5"} },
            { 6, new UserModel(){ Id=6, Age=43, Email="f@a.aa", UserName="User6"} },
            { 7, new UserModel(){ Id=7, Age=19, Email="g@a.aa", UserName="User7"} },
            { 8, new UserModel(){ Id=8, Age=33, Email="h@a.aa", UserName="User8"} }
        };

        public ActionResult AddUser()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public ActionResult AddUser(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                userModel.Id = new Random().Next(int.MaxValue);
                cache.Add(userModel.Id, userModel);
                return RedirectToAction("List");
            }
            else
            {
                return View(userModel);
            }
        }

        [HttpGet]
        public ViewResult GetUser(int userId)
        {
            UserModel userModel = cache[userId];
            return View(userModel);
        }

        [HttpGet]
        public ViewResult List()
        {
            List<UserModel> allUsers = cache.Values.ToList();
            return View(allUsers);
        }

        public ActionResult DeleteUser(int userId)
        {
            cache.Remove(userId);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult EditUser(int userId)
        {
            UserModel userModel = cache[userId];
            return View("AddUser", userModel);
        }

        [HttpPost]
        public ActionResult EditUser(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                cache[userModel.Id] = userModel;
                return RedirectToAction("List");
            }
            else
            {
                return View("AddUser", userModel);
            }
        }
    }
}