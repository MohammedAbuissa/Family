using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Family.Models;

namespace Family.Controllers
{
    public class UsersController : Controller
    {
        private FamilyModel db = new FamilyModel();

        // GET: Users
        public ActionResult Index()
        {
            
            if (Session["ID"]!=null)
            {
                int ID = (int)Session["ID"];
                return View(db.Users.Where(U => U.User_Id != ID).ToList());
            }
                
            return Redirect("~/Login");
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            User user;
            if (id == null && Session["ID"] != null)
            {
                user = db.Users.Find((int)Session["ID"]);
                return View(user);
            }
            user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            if(Session["ID"]== null)
            {
                return View();
            }
            return Redirect("~/Users");
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_Id,First_Name,Last_Name,E_Mail,Password,Profile_Picture,Phone_Number,Gender,Birthday,Marital_Status,About_me,HomeTown")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                Session["ID"] = user.User_Id;
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit()
        {
            
            if (Session["ID"] != null)
            {
                int id = (int) Session["ID"];
                User user = db.Users.Find(id);
                return View(user);
            }
            return Redirect("~/Home");
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_Id,First_Name,Last_Name,E_Mail,Password,Profile_Picture,Phone_Number,Gender,Birthday,Marital_Status,About_me,HomeTown")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete()
        {
            
            if (Session["ID"] != null)
            {
                int id = (int)Session["ID"];
                User user = db.Users.Find(id);
                return View(user);
            }
            return Redirect("~/Home");
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            int id = (int)Session["ID"];
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddFriend(int? id)
        {
            if (Session["ID"] == null)
                return HttpNotFound("you are not logged in");
            else
            {
                if(id !=null && id != (int)Session["ID"])
                {
                    int myID = (int)Session["ID"];
                    User user = db.Users.Find(id);
                    User me = db.Users.Find(myID);
                    me.Friends.Add(user);
                    db.FriendNotifications.Add(new FriendNotification { User_ID = user.User_Id, Friend_ID = me.User_Id, Time = DateTime.Now, Read =false });
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound("ID not found");
                }
            }
            
        }

        public ActionResult FriendRequest()
        {
            if(Session["ID"] == null)
            {
                return HttpNotFound("Login first");
            }
            else
            {
                if(Session["ID"] != null)
                {
                    int id = (int)Session["ID"];
                    var Requests = from N in db.FriendNotifications
                                   join U in db.Users on N.Friend_ID equals U.User_Id
                                   where N.User_ID == id && N.Read == false
                                   select U;
                    var Users = Requests.ToList();
                    var Notifications = from N in db.FriendNotifications
                                        join U in db.Users on N.Friend_ID equals U.User_Id
                                        where N.User_ID == id && N.Read == false
                                        select N;
                    foreach (var Noti in Notifications)
                    {
                        Noti.Read = true;
                    }
                    db.SaveChanges();
                    
                    return View(Users.ToList());
                }
                return HttpNotFound("Login first");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
