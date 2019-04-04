using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudOperations2.Models;
using System.Data.Entity;
using System.Data;
using System.IO;

namespace CrudOperations2.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult DetailsPartial(int idstudent)
        {
            using (testEntities ts = new testEntities())
            {


                //return View(ts.students.Where(x => x.idstudent == idstudent).FirstOrDefault());

                return PartialView("_TestEditPartialView", ts.students.Where(x => x.idstudent == idstudent).FirstOrDefault());
            }
           
        }
        // GET: Student
        public ActionResult Index()
        {
            using (testEntities ts = new testEntities())
            {


                ViewBag.Students = ts.students.ToList();
                ViewBag.hobby = ts.hobbies.ToList();
                // return View(ts.students.ToList());
                return View();
            }
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using (testEntities ts = new testEntities())
            {
                return View(ts.students.Where(x => x.idstudent == id).FirstOrDefault());
            }
        }
        // GET: Student/Create
        public ActionResult Create()
        {
            //List<student> hobbylist = new List<student>();
            //hobbylist.Add(new student { hobby = "play" });
            //hobbylist.Add(new student { hobby = "sing" });
            //hobbylist.Add(new student { hobby = "runnign" });
            //ViewBag.itemlist = hobbylist;
            //return View();

            testEntities ts = new Models.testEntities();
            ViewBag.hobby = ts.hobbies.ToList();
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(student stud,FormCollection collection,HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                using (testEntities ts = new testEntities())
                {
                    //forfileupload
                    if(file!=null && file.ContentLength > 0)
                    {
                        string filename = Path.GetFileName(file.FileName);
                        string imagepath = Path.Combine(Server.MapPath("~/User-Images/"),filename);
                        file.SaveAs(imagepath);
                        stud.userImage = "~/User-Images/" + filename;
                    }
                    
                    string hobby = collection["hobbies"];
                    stud.hobby = hobby;
                    ts.students.Add(stud);
                    ts.SaveChanges();
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id,student stud, HttpPostedFileBase file)
        {
            using (testEntities sm = new testEntities())
            {
                
               
                // testEntities ts = new Models.testEntities();
                ViewBag.userImage = sm.students.Where(x => x.idstudent == id).Select(x => x.userImage).SingleOrDefault();
                ViewBag.hobby = sm.hobbies.ToList();
               // string studhobby = sm.students.Where(x => x.idstudent == id).Select(x => x.hobby).SingleOrDefault();
                ViewBag.studhobby = sm.students.Where(x => x.idstudent == id).Select(x => x.hobby).SingleOrDefault();
                return View(sm.students.Where(x => x.idstudent == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, student s,FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add update logic here
                using (testEntities sm = new testEntities())
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string filename = Path.GetFileName(file.FileName);
                        string imagepath = Path.Combine(Server.MapPath("~/User-Images/"), filename);
                        file.SaveAs(imagepath);
                        s.userImage = "~/User-Images/" + filename;
                    }
                    else
                    {
                        s.userImage = sm.students.Where(x => x.idstudent == id).Select(x => x.userImage).SingleOrDefault();
                    }

                    string hobby = collection["hobbies"];
                    s.hobby = hobby;
                    sm.Entry(s).State = EntityState.Modified;
                    sm.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (testEntities sm = new testEntities())
            {
                return View(sm.students.Where(x => x.idstudent == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public JsonResult Delete(int id, FormCollection collection)
        {
            bool result = false;
            try
            {
                using (testEntities sm = new testEntities  ())
                {
                    student s = sm.students.Where(x => x.idstudent == id).FirstOrDefault();
                    sm.students.Remove(s);
                    sm.SaveChanges();

                    result = true;
                    // TODO: Add delete logic here

                    //return RedirectToAction("Index");
                    return Json(result,JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
