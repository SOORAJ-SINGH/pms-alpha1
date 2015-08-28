using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pms_alpha1;

namespace pms_alpha1.Controllers
{
    public class TBL_VendorController : Controller
    {
        private somyatrans_pmsDBContext db = new somyatrans_pmsDBContext();

        // GET: TBL_Vendor
        public ActionResult Index()
        {
            var tBL_Vendor = db.TBL_Vendor.Include(t => t.TBL_M_City).Include(t => t.TBL_M_Country).Include(t => t.TBL_M_Domain).Include(t => t.TBL_M_State);
            return View(tBL_Vendor.ToList());
        }

        // GET: TBL_Vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Vendor tBL_Vendor = db.TBL_Vendor.Find(id);
            if (tBL_Vendor == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Vendor);
        }

        // GET: TBL_Vendor/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.TBL_M_City, "CityID", "City");
            ViewBag.CityID = new SelectList(db.TBL_M_Country, "CountryID", "Country");
            ViewBag.DomainID = new SelectList(db.TBL_M_Domain, "DomainID", "Domain");
            ViewBag.StateID = new SelectList(db.TBL_M_State, "StateID", "State");
            return View();
        }

        // POST: TBL_Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorID,VendorCode,Vendor,DateOfBirth,DateOfAniversary,NativeLanguage,AcademicQualification,ProfessionalQualification,EmailID,AlternateEmailID,SkypeID,ContactNumber,AlternateNumber,Address,HouseNo_StreetNo,CityID,StateID,CountryID,PinCode,DomainID,Capacity,WorkingTime,RAM,HDD,OS,MSOffice,AnyOtherExprience,TypeofConnection,InternetAvailabilityPerDay,InternetServiceProvider,InternetDownTimePerDay,ElectricityDownTimePerDay,AccountHolderName,BankName,BankAddress,AccountNumber,IFSCCode,BranchCode,PanNumber,IBANCode,SWIFTCode,MoneyBookerID,PayPalID,RegistrationDate,RegisteredBy,ApprovedBy,UploadPhoto,UploadPersonalID,Status")] TBL_Vendor tBL_Vendor)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Vendor.Add(tBL_Vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.TBL_M_City, "CityID", "City", tBL_Vendor.CityID);
            ViewBag.CityID = new SelectList(db.TBL_M_Country, "CountryID", "Country", tBL_Vendor.CityID);
            ViewBag.DomainID = new SelectList(db.TBL_M_Domain, "DomainID", "Domain", tBL_Vendor.DomainID);
            ViewBag.StateID = new SelectList(db.TBL_M_State, "StateID", "State", tBL_Vendor.StateID);
            return View(tBL_Vendor);
        }

        // GET: TBL_Vendor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Vendor tBL_Vendor = db.TBL_Vendor.Find(id);
            if (tBL_Vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.TBL_M_City, "CityID", "City", tBL_Vendor.CityID);
            ViewBag.CityID = new SelectList(db.TBL_M_Country, "CountryID", "Country", tBL_Vendor.CityID);
            ViewBag.DomainID = new SelectList(db.TBL_M_Domain, "DomainID", "Domain", tBL_Vendor.DomainID);
            ViewBag.StateID = new SelectList(db.TBL_M_State, "StateID", "State", tBL_Vendor.StateID);
            return View(tBL_Vendor);
        }

        // POST: TBL_Vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,VendorCode,Vendor,DateOfBirth,DateOfAniversary,NativeLanguage,AcademicQualification,ProfessionalQualification,EmailID,AlternateEmailID,SkypeID,ContactNumber,AlternateNumber,Address,HouseNo_StreetNo,CityID,StateID,CountryID,PinCode,DomainID,Capacity,WorkingTime,RAM,HDD,OS,MSOffice,AnyOtherExprience,TypeofConnection,InternetAvailabilityPerDay,InternetServiceProvider,InternetDownTimePerDay,ElectricityDownTimePerDay,AccountHolderName,BankName,BankAddress,AccountNumber,IFSCCode,BranchCode,PanNumber,IBANCode,SWIFTCode,MoneyBookerID,PayPalID,RegistrationDate,RegisteredBy,ApprovedBy,UploadPhoto,UploadPersonalID,Status")] TBL_Vendor tBL_Vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.TBL_M_City, "CityID", "City", tBL_Vendor.CityID);
            ViewBag.CityID = new SelectList(db.TBL_M_Country, "CountryID", "Country", tBL_Vendor.CityID);
            ViewBag.DomainID = new SelectList(db.TBL_M_Domain, "DomainID", "Domain", tBL_Vendor.DomainID);
            ViewBag.StateID = new SelectList(db.TBL_M_State, "StateID", "State", tBL_Vendor.StateID);
            return View(tBL_Vendor);
        }

        // GET: TBL_Vendor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Vendor tBL_Vendor = db.TBL_Vendor.Find(id);
            if (tBL_Vendor == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Vendor);
        }

        // POST: TBL_Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Vendor tBL_Vendor = db.TBL_Vendor.Find(id);
            db.TBL_Vendor.Remove(tBL_Vendor);
            db.SaveChanges();
            return RedirectToAction("Index");
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
