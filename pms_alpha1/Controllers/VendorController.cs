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

            VendorRegistration vendorRegister = new VendorRegistration();
            var ven = from v in unitOfWork.VendorRepository.Get() select v;
            
            //logic for drop down list Domains
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
            
            //Func<cDomain, string> text = (d) => string.Format() "Domain";
            vendorRegister.DomainItems = ExtensionClass.ToSelectListItems<cDomain>(domainL, x => x.Domain,x =>x.DomainID.ToString());





           
            //logic for drop down list Country
            //improve this code ....to directly get the data in the list Format
            var countryList = from country in unitOfWork.CountryRepository.Get() select country;
            var countryL = new List<cCountry>();
            if (countryList.Any())
            {
                foreach (var d in countryList)
                {
                    countryL.Add(new cCountry() { CountryID = d.CountryID, Country = d.Country });
                }
            }

            IEnumerable<cCountry> _Country_IE = countryL as IEnumerable<cCountry>;
            vendorRegister.CountryItems = ExtensionClass.ToSelectListItems<cCountry>(countryL, x => x.Country, x => x.CountryID.ToString());



            //logic for drop down list State
            //improve this code ....to directly get the data in the list Format
            var stateList = from state in unitOfWork.StateRepository.Get() select state;
            var stateL = new List<cState>();
            if (stateList.Any())
            {
                foreach (var d in stateList)
                {
                    stateL.Add(new cState() { StateID = d.StateID, State = d.State });
                }
            }

            IEnumerable<cState> _State_IE = stateL as IEnumerable<cState>;
            vendorRegister.StateItems = ExtensionClass.ToSelectListItems<cState>(stateL, x => x.State, x => x.StateID.ToString());


            //logic for drop down list City
            //improve this code ....to directly get the data in the list Format
            var cityList = from city in unitOfWork.CityRepository.Get() select city;
            var cityL = new List<cCity>();
            if (cityList.Any())
            {
                foreach (var d in cityList)
                {
                    cityL.Add(new cCity() { CityID = d.CityID, City = d.City });
                }
            }

            IEnumerable<cCity> _City_IE = cityL as IEnumerable<cCity>;
            vendorRegister.CityItems = ExtensionClass.ToSelectListItems<cCity>(cityL, x => x.City, x => x.CityID.ToString());

            //vendorRegister.VendorLanguagePair = new[] {
            //    new VendorLanguagePair{ VendorLanguagePairID = 0,TargetLanguageID = 0}
            //};
            
            //creating the list of blank language pair..to be displayed as default
            List<VendorLanguagePair> LanguagePair = new List<VendorLanguagePair> { 
                                                        new VendorLanguagePair {SourceLanguageID = 0,TargetLanguageID=0}                   
                                                    };

            vendorRegister.VendorLanguagePair = LanguagePair;
            //vendorRegister.VendorLanguagePair = new HashSet<VendorLanguagePair>();

            //ViewBag.DomainID = new SelectList(_Domain_IE, "DomainID", "Domain");
            //ViewBag.StateID = new SelectList(db.TBL_M_State, "StateID", "State");
            //ViewBag.CityID = new SelectList(db.TBL_M_City, "CityID", "City");
            //ViewBag.CityID = new SelectList(db.TBL_M_Country, "CountryID", "Country");

            return View(vendorRegister);
        }

        //Add langugae pair dynamically 
        public ActionResult AddLanguagePair()
        {
            return PartialView("AddLanguagePair", new VendorLanguagePair());
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
                if (ModelState.IsValid)
                {
                    
                }
                else
                {
                    bool hasErrors = ViewData.ModelState.Values.Any(x => x.Errors.Count > 1);
                    var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                }
                //create mapping
                Mapper.CreateMap<VendorRegistration, TBL_Vendor>();

                TBL_Vendor tbl_Vendor = Mapper.Map<VendorRegistration, TBL_Vendor>(vendorRegister);
                unitOfWork.VendorRepository.Insert(tbl_Vendor);
                
                unitOfWork.Save();

                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {

                return View();
            }

        }
    }

    public static class ExtensionClass
    {
        
        //public static IEnumerable<T> ToEnum(var list)
        //{
        //     IEnumerable<cCountry> _IE;
        //     return _IE;
        //}






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