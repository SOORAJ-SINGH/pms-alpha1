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

            vendorRegister.DomainItems = ExtensionClass.GetDomains();
            vendorRegister.CountryItems = ExtensionClass.GetCountries();
            vendorRegister.StateItems = ExtensionClass.GetStates();
            vendorRegister.CityItems = ExtensionClass.GetCities();

            List<VendorLanguagePair> LanguagePairList = new List<VendorLanguagePair>{ ExtensionClass.GetLanguagePair() };
            vendorRegister.VendorLanguagePair = LanguagePairList;
            List<VenderSoftware> SoftwareList = new List<VenderSoftware>{ ExtensionClass.GetSoftware() };
            vendorRegister.VenderSoftware = SoftwareList;
            List<VendorService> ServicesList = new List<VendorService>{ ExtensionClass.GetServices() };
            vendorRegister.VendorService = ServicesList;

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

        //returns the Partial View to Add language pair dynamically 
        public ActionResult AddLanguagePair()
        {

            return PartialView("AddLanguagePair", ExtensionClass.GetLanguagePair());
        }
        //returns the Partial View to AddVenderSoftwares dynamically 
        public ActionResult AddVenderSoftwares()
        {

            return PartialView("AddVenderSoftwares",ExtensionClass.GetSoftware());
        }
        //returns the Partial View to AddVendorServices dynamically 
        public ActionResult AddVendorServices()
        {

            return PartialView("AddVendorServices", ExtensionClass.GetServices());
        }

    }

    public static class ExtensionClass
    {

        #region Variables
        private static UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();

        #endregion

        #region Get Data to be binded for the dropDownList
        public static VenderSoftware GetSoftware()
        {
            //logic for drop down list Softwares Names and Expertise
            //improve this code ....to directly get the data in the list Format
            var softwareList = from software in unitOfWork.VendorSoftwareRepository.Get() select software;

            var softwareL = new List<VenderSoftware>();

            if (softwareList.Any())
            {
                foreach (var d in softwareList)
                {
                    softwareL.Add(new VenderSoftware() { SoftwareID = d.SoftwareID, Software = d.Software });
                }
            }

            var expertiseList = from expertise in unitOfWork.VendorExpertiseRepository.Get() select expertise;

            var expertiseL = new List<TBL_M_Expertise>();

            if (expertiseList.Any())
            {
                foreach (var d in expertiseList)
                {
                    expertiseL.Add(new TBL_M_Expertise() { ExpertiseID = d.ExpertiseID, Expertise = d.Expertise });
                }
            }
            //creating the list of blank software pair..to be displayed as default
            VenderSoftware venderSoftware = new VenderSoftware
            {
                Version = "0",
                SoftwaresItems = ExtensionClass.ToSelectListItems<VenderSoftware>(softwareL, x => x.Software, x => x.SoftwareID.ToString()),
                ExpertiseItems = ExtensionClass.ToSelectListItems<TBL_M_Expertise>(expertiseL, x => x.Expertise, x => x.ExpertiseID.ToString()),


            };
            return venderSoftware;

        }

        public static VendorLanguagePair GetLanguagePair()
        {
            //logic for drop down list Language
            //improve this code ....to directly get the data in the list Format

            var languageList = from language in unitOfWork.LanguageRepository.Get() select language;

            var languageSourceL = new List<VendorLanguagePair>();
            var languageTargetL = new List<VendorLanguagePair>();

            if (languageList.Any())
            {
                foreach (var d in languageList)
                {
                    languageSourceL.Add(new VendorLanguagePair() { SourceLanguageID = d.LanguageID, SourceLanguage = d.Language });
                    languageTargetL.Add(new VendorLanguagePair() { TargetLanguageID = d.LanguageID, TargetLanguage = d.Language });
                }
            }


            VendorLanguagePair LanguagePair = new VendorLanguagePair
            {
                SourceLanguageID = 0,
                TargetLanguageID = 0,
                LanguageSourceItems = ExtensionClass.ToSelectListItems<VendorLanguagePair>(languageSourceL, x => x.SourceLanguage, x => x.SourceLanguageID.ToString()),
                LanguageTargetItems = ExtensionClass.ToSelectListItems<VendorLanguagePair>(languageTargetL, x => x.TargetLanguage, x => x.TargetLanguageID.ToString()),


            };
            return LanguagePair;

        }

        public static VendorService GetServices()
        {
            //logic for drop down list Language
            //improve this code ....to directly get the data in the list Format

            var serviceList = from service in unitOfWork.ServicesRepository.Get() select service;

            var serviceL = new List<TBL_M_Services>();
            

            if (serviceList.Any())
            {
                foreach (var d in serviceList)
                {
                    serviceL.Add(new TBL_M_Services() { ServicesID = d.ServicesID, Services= d.Services});
                   
                }
            }

            var currencyList = from currency in unitOfWork.CurrencyRepository.Get() select currency;

            var currencyQuotedL = new List<VendorService>();
            var currencyFreezedL = new List<VendorService>();

            if (currencyList.Any())
            {
                foreach (var d in currencyList)
                {
                    currencyQuotedL.Add(new VendorService() { QuotedCurrencyID = d.CurrencyID, QuotedCurrency = d.Currency });
                    currencyFreezedL.Add(new VendorService() { FreezedCurrenyID = d.CurrencyID, FreezedCurreny = d.Currency });
                }
            }
            VendorService vendorService = new VendorService
            {
                QuotedRate = 0,
                FreezedRate = 0,
                ServicesItems = ExtensionClass.ToSelectListItems<TBL_M_Services>(serviceL, x => x.Services, x => x.ServicesID.ToString()),
                QuotedCurrencyItems = ExtensionClass.ToSelectListItems<VendorService>(currencyQuotedL, x => x.QuotedCurrency, x => x.QuotedCurrencyID.ToString()),
                FreezedCurrencyItems = ExtensionClass.ToSelectListItems<VendorService>(currencyFreezedL, x => x.FreezedCurreny, x => x.FreezedCurrenyID.ToString()),


            };
            return vendorService;

        }

        public static IEnumerable<SelectListItem> GetCities()
        {
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
            return ExtensionClass.ToSelectListItems<cCity>(cityL, x => x.City, x => x.CityID.ToString());
        }

        public static IEnumerable<SelectListItem> GetStates()
        {
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
            return ExtensionClass.ToSelectListItems<cState>(stateL, x => x.State, x => x.StateID.ToString());
        }

        public static IEnumerable<SelectListItem> GetCountries()
        {
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
            return ExtensionClass.ToSelectListItems<cCountry>(countryL, x => x.Country, x => x.CountryID.ToString());
        }

        public static IEnumerable<SelectListItem> GetDomains() 
        {
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
            return ExtensionClass.ToSelectListItems<cDomain>(domainL, x => x.Domain, x => x.DomainID.ToString());
        }



        #endregion


        //public static IEnumerable<T> ToEnum(var list)
        //{
        //     IEnumerable<cCountry> _IE;
        //     return _IE;
        //}



        #region To convert any the List<T> or IEnumerable<T> to the IEnumerable<selectlistItem>
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
        #endregion

        #region To convert any the List<cDomain> or IEnumerable<cDomain> to the IEnumerable<selectlistItem>.
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
        #endregion

        //public static List<T> LanguageList(List languageList)
        //{
        //    var languageL = new List<cLanguage>();
        //    if (languageList.Any())
        //    {
        //        foreach (var d in languageList)
        //        {
        //            languageL.Add(new cLanguage() { LanguageID = d.LanguageID, Language = d.Language });
        //        }
        //    }
        //    return languageL;
        //}

    }
}