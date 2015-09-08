using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace pms_alpha1.ViewModels
{
    /// <summary>
    /// ViewModel for Registration of the Vendor
    /// </summary>
    public class VendorRegistration
    {
        
        public int VendorID { get; set; }
        [Display(Name = "Vendor Code")]
        public string VendorCode { get; set; }
        [Required]
        public string Vendor { get; set; }
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Text)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        [Display(Name = "Date Of Anniversary")]
        public Nullable<System.DateTime> DateOfAniversary { get; set; }
        [Display(Name = "Native Language")]
        public string NativeLanguage { get; set; }
        [Display(Name = "Academic Qualification")]
        public string AcademicQualification { get; set; }
        [Display(Name = "Professional Qualification")]
        public string ProfessionalQualification { get; set; }
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }
        [Display(Name = "Alternate Email ID")]
        public string AlternateEmailID { get; set; }
        public string SkypeID { get; set; }
        [Display(Name = "Contact Number")]
        [StringLength(10,ErrorMessage = "Number cannot have digits above 10 digits")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string ContactNumber { get; set; }
        [Display(Name = "Alternate Number")]
        [StringLength(10, ErrorMessage = "Number cannot have digits above 10 digits")]
       [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        public string AlternateNumber { get; set; }
        public string Address { get; set; }
        [Display(Name = "HouseNo/StreetNo")]
        public string HouseNo_StreetNo { get; set; }
        [Display(Name = "City")]
        public Nullable<int> CityID { get; set; }
        [Display(Name = "State")]
        public Nullable<int> StateID { get; set; }
        [Display(Name = "Country")]
        public Nullable<int> CountryID { get; set; }
        [Display(Name = "Pin Code")]
        public string PinCode { get; set; }
        [Display(Name = "Academic")]
        public Nullable<int> DomainID { get; set; }
        public string Capacity { get; set; }
        public Nullable<System.TimeSpan> WorkingTime { get; set; }
        public string RAM { get; set; }
        public string HDD { get; set; }
        public string OS { get; set; }
        [Display(Name = "MS Office")]
        public string MSOffice { get; set; }
        [Display(Name = "Any Other Experience")]
        public string AnyOtherExprience { get; set; }
        [Display(Name = "Type of Connection")]
        public string TypeofConnection { get; set; }
        [Display(Name = "Internet Availability PerDay")]
        public Nullable<decimal> InternetAvailabilityPerDay { get; set; }
        [Display(Name = "Internet Service Provider")]
        public string InternetServiceProvider { get; set; }
        [Display(Name = "Internet Down Time PerDay")]
        public string InternetDownTimePerDay { get; set; }
        [Display(Name = "Electricity Down Time PerDay")]
        public string ElectricityDownTimePerDay { get; set; }
        [Display(Name = "Account Holder Name")]
        public string AccountHolderName { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Bank Address")]
        public string BankAddress { get; set; }
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        [Display(Name = "IFSC Code")]
        public string IFSCCode { get; set; }
        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; }
        [Display(Name = "Pan Number")]
        public string PanNumber { get; set; }
        [Display(Name = "IBAN Code")]
        public string IBANCode { get; set; }
        [Display(Name = "SWIFT Code")]
        public string SWIFTCode { get; set; }
        [Display(Name = "Money Booker ID")]
        public string MoneyBookerID { get; set; }
        [Display(Name = "PayPal ID")]
        public string PayPalID { get; set; }
        [Display(Name = "Registration Date")]
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        [Display(Name = "Registered By")]
        public string RegisteredBy { get; set; }
        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }
        [Display(Name = "Upload Photo")]
        public string UploadPhoto { get; set; }
        [Display(Name = "Upload Personal ID")]
        public string UploadPersonalID { get; set; }
    
        public Nullable<bool> Status { get; set; }


        public virtual cCity City { get; set; }
        public virtual cCountry Country { get; set; }
        public virtual TBL_M_Domain Domain { get ; set; }
        public virtual cState State { get; set; }


        private readonly List<TBL_M_Domain> _cDomain = new List<TBL_M_Domain>();
        //public IEnumerable<TBL_M_Domain> DomainItems
        //{
        //    get { return _cDomain; }
        //}


        //To Display the DropDownList 
        public IEnumerable<SelectListItem> DomainItems {get;set;}
        public IEnumerable<SelectListItem> CountryItems { get; set; }
        public IEnumerable<SelectListItem> StateItems { get; set; }
        public IEnumerable<SelectListItem> CityItems { get; set; }




        public virtual ICollection<VendorSoftware> VendorSoftware { get; set; }
        //public virtual ICollection<VendorLanguagePair> VendorLanguagePair { get; set; }
        public virtual ICollection<VendorLanguagePair> VendorLanguagePair { get; set; }
        public virtual ICollection<VendorService> VendorService { get; set; }

       
        

    }

    public class cCity
    {
        [Display(Name = "City")]
        public int CityID { get; set; }
        public int StateID { get; set; }
        public string City { get; set; }
        public bool Status { get; set; }

        public virtual cState State { get; set; }
    }

    public class cState
    {
        [Display(Name = "State")]
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string State { get; set; }
        public bool Status { get; set; }
    }

    public class cCountry
    {
        [Display(Name = "Country")]
        public int CountryID { get; set; }
        public string Country { get; set; }
        public bool Status { get; set; }
    }

    public class cDomain
    {
        public int DomainID { get; set; }
        public string Domain { get; set; }
        public bool Staus { get; set; }
    }

    public class cLanguage
    {
        public int LanguageID { get; set; }
        public string Language { get; set; }
        public bool Staus { get; set; }
    }

    public class VendorSoftware
    {
        public long VendorSoftwareID { get; set; }
        public Nullable<int> VendorID { get; set; }
        public Nullable<int> SoftwareID { get; set; }
        public string Software { get; set; }
        public string Version { get; set; }
        public Nullable<int> ExpertiseID { get; set; }
        public Nullable<bool> Status { get; set; }
        public IEnumerable<SelectListItem> SoftwaresItems { get; set; }
        public IEnumerable<SelectListItem> ExpertiseItems { get; set; }

    }

    public class VendorLanguagePair
    {
        public long VendorLanguagePairID { get; set; }
        public Nullable<int> VendorID { get; set; }
        public Nullable<int> SourceLanguageID { get; set; }
        public string SourceLanguage { get; set; }
        public Nullable<int> TargetLanguageID { get; set; }
        public string TargetLanguage { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public IEnumerable<SelectListItem> LanguageSourceItems { get; set; }
        public IEnumerable<SelectListItem> LanguageTargetItems { get; set; }

    }

    public class VendorService
    {
        public long VendorServiceID { get; set; }
        public Nullable<int> VendorID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<int> QuotedCurrencyID { get; set; }
        public string QuotedCurrency { get; set; }
        public Nullable<decimal> QuotedRate { get; set; }
        public Nullable<int> FreezedCurrenyID { get; set; }
        public string FreezedCurreny { get; set; }
        public Nullable<decimal> FreezedRate { get; set; }
        public Nullable<bool> Status { get; set; }

        public IEnumerable<SelectListItem> ServicesItems { get; set; }
        public IEnumerable<SelectListItem> QuotedCurrencyItems { get; set; }
        public IEnumerable<SelectListItem> FreezedCurrencyItems { get; set; }

    }

}