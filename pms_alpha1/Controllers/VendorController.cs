using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using pms_alpha1.ViewModels;

namespace pms_alpha1.Controllers
{
    public class VendorController : Controller
    {

        #region Private member variables...
        private UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();


        #endregion
        
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get Action for Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {

            //improve this code ....to directly get the data in the list Format
            var domainList = from domain in unitOfWork.DomainRepository.Get() select domain;
            var domainL = new List<cDomain>();
            if (domainList.Any())
            {
                foreach (var d in domainList)
                {
                    domainL.Add(new cDomain() { DomainID = d.DomainID, Domain = d.Domain });
                }
            }


            IEnumerable<cDomain> _Domain_IE = domainL as IEnumerable<cDomain>;
            
            
            VendorRegistration vendorRegister = new VendorRegistration();
            var ven = from v in unitOfWork.VendorRepository.Get() select v;
            //Func<cDomain, string> text = (d) => string.Format() "Domain";
            vendorRegister.DomainItems = ExtensionClass.ToSelectListItems<cDomain>(domainL, x => x.Domain,x =>x.DomainID.ToString());

           
            //ViewBag.DomainID = new SelectList(_Domain_IE, "DomainID", "Domain");
            //ViewBag.StateID = new SelectList(db.TBL_M_State, "StateID", "State");
            //ViewBag.CityID = new SelectList(db.TBL_M_City, "CityID", "City");
            //ViewBag.CityID = new SelectList(db.TBL_M_Country, "CountryID", "Country");

            return View(vendorRegister);
        }

        

        
        /// <summary>
        /// Post Action for Create
        /// </summary>
        /// <param name="userDetails"> </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(VendorRegistration vendorRegister)
        {
            try
            {

                //create mapping
                Mapper.CreateMap<VendorRegistration, TBL_Vendor>();

                TBL_Vendor tbl_Vendor = Mapper.Map<VendorRegistration, TBL_Vendor>(vendorRegister);

                return View();


            }
            catch (Exception ex)
            {

                return View();
            }

        }
    }

    public static class ExtensionClass
    {
        

        /// <summary>
        /// To convert any the List<T> or IEnumerable<T> to the IEnumerable<selectlistItem>
        /// </summary>
        /// <typeparam name="T">Genric</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="textPropertySelector">The text property selector.</param>
        /// <param name="valuePropertySelector">The value property selector.</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ToSelectListItems<T>(
            this IEnumerable<T> source,
            Func<T, string> textPropertySelector, 
            Func<T, string> valuePropertySelector
            )
        {
            return source
                .Select(obj => new SelectListItem
                {
                    Text = textPropertySelector(obj),
                    Value = valuePropertySelector(obj),
                    //Selected = isSelectedSelector(obj)
                });
                
        }


        /// <summary>
        /// To convert any the List<cDomain> or IEnumerable<cDomain> to the IEnumerable<selectlistItem>.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="selectedId">The selected identifier.</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ToSelectListItems(
                     this IEnumerable<cDomain> source, int selectedId)
        {
            return
                source.OrderBy(s => s.Domain)
                      .Select(s =>
                          new SelectListItem
                          {
                              Selected = (s.DomainID == selectedId),
                              Text = s.Domain,
                              Value = s.DomainID.ToString()
                          });
        }

    }
}