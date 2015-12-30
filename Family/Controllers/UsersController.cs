using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Family.Models;
using System.Web.Helpers;
using System.IO;
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
                var Me = db.Users.Find(ID);
                var Friends = Me.Friends.ToList();
                var People = db.Users.ToList();
                var Find = People.Except(Friends);
                return View(Find);
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
                return Redirect("~/login");
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
                user.Password = Crypto.HashPassword(user.Password);
                user.Friends.Add(user);
                db.Users.Add(user);
                db.SaveChanges();
                Session["ID"] = user.User_Id;
                user.Posts.Add(new Post() { User_Id = user.User_Id, Caption = user.First_Name + " has created a profile", Private_Public = true, Time = DateTime.Now });
                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                            //raise a new exception inserting the current one as the InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
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
            return Redirect("~/login");
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
            return Redirect("~/login");
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
            return RedirectToAction("~/login");
        }


        public ActionResult AddFriend(int? id)
        {
            if (Session["ID"] == null)
                return Redirect("~/login");
            else
            {
                if(id !=null && id != (int)Session["ID"])
                {
                    int myID = (int)Session["ID"];
                    User user = db.Users.Find(id);
                    User me = db.Users.Find(myID);
                    me.Friends.Add(user);
                    var Notificaiton = (from U in db.FriendNotifications
                                       where U.User_ID == me.User_Id && U.Friend_ID == user.User_Id
                                       select U).ToList();
                    if(Notificaiton.Count == 0)
                        db.FriendNotifications.Add(new FriendNotification { User_ID = user.User_Id, Friend_ID = me.User_Id, Time = DateTime.Now, Read =false });
                    else
                    {
                        Notificaiton[0].Read = true;
                    }
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
                return Redirect("~/login");
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
                    db.SaveChanges();
                    return View(Users.ToList());
                }
                return HttpNotFound("Login first");
            }
        }


        public ActionResult Friend()
        {
            if(Session["ID"] != null)
            {
                int id = (int) Session["ID"];
                return View(db.Users.Find(id).Friends.Where(x => x.User_Id != id).ToList());
            }
            else
            return Redirect("~/Home");
        }

        public ActionResult NewPost()
        {
            if (Session["ID"] != null)
            {
                return View();   
            }
            return Redirect("~/login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPost([Bind(Include = "Caption,Private_Public")]Post p)
        {
            if(Session["ID"] != null)
            {
                int id= (int)Session["ID"];
                p.User_Id = id;
                p.Time = DateTime.Now;
                db.Posts.Add(p);
                db.SaveChanges();
                return Redirect("~/home");
            }
            return Redirect("~/login");
        }

        public ActionResult UserProfile(int? id)
        {
            if (Session["ID"] == null)
            {
                return Redirect("~/login");
            }
            int MyID = (int)Session["ID"];
            User me = db.Users.Find(MyID);
            if (Session["ID"] != null && id == null)//me
            {
                return View(me.Posts.ToList());
            }
            //I'm accessing someone else profile
            MyID = (int)Session["ID"];
            var user = db.Users.Find(id);
            bool IsFollow = me.Friends.Contains(user);
            bool IsFollowing = user.Friends.Contains(me);
            if(IsFollow && IsFollowing)
            {
                return View(user.Posts.OrderByDescending(x => x.Time).ToList());
            }
            else
            {
                return View(user.Posts.Where(p => p.Private_Public == true).OrderByDescending(x => x.Time).ToList());
            }
        }

        public ActionResult NewsFeed()
        {
            if (Session["ID"] != null)
            {
                var id = (int)Session["ID"];
                var Me = db.Users.Find(id);
                var posts = new List<Post>();
                var Followers = Me.Friends;
                foreach (var Friend in Followers)
                {
                    if (Friend.Friends.Contains(Me))
                        posts.AddRange(Friend.Posts);
                    else
                        posts.AddRange(Friend.Posts.Where(x => x.Private_Public == true));
                }
                return View(posts.OrderByDescending(x=> x.Time));
            }
            else
            {
                return Redirect("~/login");
            }
        }

        public ActionResult Discover()
        {
            List<User> users = db.Users.ToList();
            if (Session["ID"] != null)
            {
                int id = (int)Session["ID"];
                users = users.Except(db.Users.Find(id).Friends.ToList()).ToList();
            }
            var Posts = (from U in users
                         join P in db.Posts on U.User_Id equals P.User_Id
                         where P.Private_Public == true
                         select P);
            return View(Posts.ToList());
        }
        public ActionResult submitPhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhoto(HttpPostedFileBase file)
        {
            if(file != null)
            {
                int id = (int)Session["ID"];
                string name = DateTime.Now.ToString();
                name = name.Replace(':', '_');
                string path = Path.Combine(Server.MapPath("~/images"), id.ToString());
                //Directory.CreateDirectory(path);
                path = Path.Combine(path, name);
                file.SaveAs(path);
            }
            return Redirect("~/home");
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
