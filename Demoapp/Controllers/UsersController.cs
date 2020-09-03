using Demoapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demoapp.Controllers
{
    public class UsersController : Controller
    {
        TestDBEntities contextobj = new TestDBEntities();
        public ActionResult AddUser()
        {
            UsersModel obj = new UsersModel();
            return View("AddUser",obj);
            
        }

        [HttpPost]
        public ActionResult AddUser(UsersModel obj)
        {
            contextobj.Users.Add(new User() {Name=obj.UserName , Age= obj.Age});
            contextobj.SaveChanges();

            return View("AddUser", obj);
        }
        public ActionResult DisplayUser()
        {
            var UserRecord = contextobj.Users.ToList();
            return View("DisplayUser",UserRecord);
        }
        [HttpPost]
       public ActionResult EditUser(int personid)
        {
            var edituser= (from item in contextobj.Users 
                            where item.UserId==personid
                            select item).First();
            return View("EditUser",edituser);
        }
        public ActionResult EditUser(User obj)
        {
            var edituser = (from item in contextobj.Users
                            where item.UserId == obj.UserId
                            select item).First();
            edituser.Name = obj.Name;
            edituser.Age = obj.Age;
            edituser.Vehicle = obj.Vehicle;

            contextobj.SaveChanges();
            var UserRecord = contextobj.Users.ToList();
            return View("EditUser", UserRecord);
        } 
        public ActionResult DeleteUser(int personid)
        {
            var edituser=(from item in contextobj.Users
                          where item.UserId == personid
                          select item).First();
            contextobj.Users.Remove(edituser);
            contextobj.SaveChanges();
            var UserRecord = contextobj.Users.ToList();
            return View("DisplayUser",UserRecord);
        }
          
        }
        // GET: Users
       
    }
