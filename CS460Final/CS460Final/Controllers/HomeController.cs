using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS460Final.DAL;
using CS460Final.Models;

namespace CS460Final.Controllers
{
    public class HomeController : Controller
    {
        int CurrentID = 1003;
        DBContext db = new DBContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ItemDetails(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            return View(db.Items.Find(id));
        }

        [HttpGet]
        public ActionResult ViewItem()
        {
            return View(db.Items.ToList());
        }

        [HttpGet]
        public ActionResult EditItem(int? id, int? sellerID)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Item it = db.Items.Find(id);
            if (it == null)
            {
                return HttpNotFound();
            }
            return View(it);
        }

        [HttpGet]
        public ActionResult DeleteItem(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Item it = db.Items.Find(id);
            if (it == null)
            {
                return HttpNotFound();
            }
            return View(it);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item it = db.Items.Find(id);
            db.Items.Remove(it);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem([Bind(Include = "ItemID, SellerID, ItemName, Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.ItemID = NewID();
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateBid()
        {
            return View();
        }

        /// <summary>
        /// ID Generator Method for Items
        /// </summary>
        /// <returns></returns>
        public int NewID()
        {
            CurrentID = CurrentID++;
            return CurrentID;
        }
    }
}