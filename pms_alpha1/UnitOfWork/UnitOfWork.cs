using pms_alpha1.GenericRepository;
using pms_alpha1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pms_alpha1.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Variable Declaration
        private somyatrans_pmsDBContext dbContext = new somyatrans_pmsDBContext();
        private GenericRepository<TBL_Vendor> vendorRepository;
        private GenericRepository<TBL_VendorDomain> vendorDomainRepository;
        private GenericRepository<TBL_VendorLanguagePair> vendorLanguagePairRepository;
        private GenericRepository<TBL_VendorService> vendorServiceRepository;
        private GenericRepository<TBL_VendorSoftware> vendorSoftwareRepository;

        
        #region Master Tables Repositories Variables
        private GenericRepository<TBL_M_Domain> m_domainRepository;
        private GenericRepository<TBL_M_Country> m_countryRepository;
        private GenericRepository<TBL_M_State> m_stateRepository;
        private GenericRepository<TBL_M_City> m_cityRepository;
        private GenericRepository<TBL_M_Academics> m_academicsRepository;

        private GenericRepository<TBL_M_Language> m_languageRepository;
        private GenericRepository<TBL_M_Software> m_SoftwareRepository;
        private GenericRepository<TBL_M_Expertise> m_ExpertiseRepository;
        private GenericRepository<TBL_M_Currency> m_currencyRepository;
        private GenericRepository<TBL_M_Services> m_servicesRepository; 
        #endregion
        
        #endregion

        //create custom Models and change here with the Tbl_Vendor
        public GenericRepository<TBL_Vendor> VendorRepository
        { 
            get
            {
                if (this.vendorRepository == null)
                {
                    this.vendorRepository = new GenericRepository<TBL_Vendor>(dbContext);
                }
                return vendorRepository;
            }
        }

        public GenericRepository<TBL_VendorDomain> VendorDomain
        {
            get
            {
                if (this.vendorDomainRepository == null)
                {
                    this.vendorDomainRepository = new GenericRepository<TBL_VendorDomain>(dbContext);
                }
                return vendorDomainRepository;
            }
        }

        public GenericRepository<TBL_VendorLanguagePair> VendorLanguagePair
        {
            get
            {
                if (this.vendorLanguagePairRepository == null)
                {
                    this.vendorLanguagePairRepository = new GenericRepository<TBL_VendorLanguagePair>(dbContext);
                }
                return vendorLanguagePairRepository;
            }
        }

        public GenericRepository<TBL_VendorService> VendorService
        {
            get
            {
                if (this.vendorServiceRepository == null)
                {
                    this.vendorServiceRepository = new GenericRepository<TBL_VendorService>(dbContext);
                }
                return vendorServiceRepository;
            }
        }

        public GenericRepository<TBL_VendorSoftware> VendorSoftware
        {
            get
            {
                if (this.vendorSoftwareRepository == null)
                {
                    this.vendorSoftwareRepository = new GenericRepository<TBL_VendorSoftware>(dbContext);
                }
                return vendorSoftwareRepository;
            }
        }
        //Master Tables Repositories
        #region Master Tables Repositories
        public GenericRepository<TBL_M_Domain> M_DomainRepository
        {
            get
            {
                if (this.m_domainRepository == null)
                {
                    this.m_domainRepository = new GenericRepository<TBL_M_Domain>(dbContext);

                }
                return m_domainRepository;
            }
        }
        public GenericRepository<TBL_M_Country> M_CountryRepository
        {
            get
            {
                if (this.m_countryRepository == null)
                {
                    this.m_countryRepository = new GenericRepository<TBL_M_Country>(dbContext);

                }
                return m_countryRepository;
            }
        }
        public GenericRepository<TBL_M_State> M_StateRepository
        {
            get
            {
                if (this.m_stateRepository == null)
                {
                    this.m_stateRepository = new GenericRepository<TBL_M_State>(dbContext);

                }
                return m_stateRepository;
            }
        }
        public GenericRepository<TBL_M_City> M_CityRepository
        {
            get
            {
                if (this.m_cityRepository == null)
                {
                    this.m_cityRepository = new GenericRepository<TBL_M_City>(dbContext);

                }
                return m_cityRepository;
            }
        }
        public GenericRepository<TBL_M_Academics> M_AcademicsRepository
        {
            get
            {
                if (this.m_academicsRepository == null)
                {
                    this.m_academicsRepository = new GenericRepository<TBL_M_Academics>(dbContext);

                }
                return m_academicsRepository;
            }
        }

        public GenericRepository<TBL_M_Language> M_LanguageRepository
        {
            get
            {
                if (this.m_languageRepository == null)
                {
                    this.m_languageRepository = new GenericRepository<TBL_M_Language>(dbContext);

                }
                return m_languageRepository;
            }
        }
        public GenericRepository<TBL_M_Software> M_SoftwareRepository
        {
            get
            {
                if (this.m_SoftwareRepository == null)
                {
                    this.m_SoftwareRepository = new GenericRepository<TBL_M_Software>(dbContext);

                }
                return m_SoftwareRepository;
            }
        }
        public GenericRepository<TBL_M_Expertise> M_ExpertiseRepository
        {
            get
            {
                if (this.m_ExpertiseRepository == null)
                {
                    this.m_ExpertiseRepository = new GenericRepository<TBL_M_Expertise>(dbContext);

                }
                return m_ExpertiseRepository;
            }
        }
        public GenericRepository<TBL_M_Currency> M_CurrencyRepository
        {
            get
            {
                if (this.m_currencyRepository == null)
                {
                    this.m_currencyRepository = new GenericRepository<TBL_M_Currency>(dbContext);

                }
                return m_currencyRepository;
            }
        }
        public GenericRepository<TBL_M_Services> M_ServicesRepository
        {
            get
            {
                if (this.m_servicesRepository == null)
                {
                    this.m_servicesRepository = new GenericRepository<TBL_M_Services>(dbContext);

                }
                return m_servicesRepository;
            }
        } 
        #endregion


        public void Save()
        {
            dbContext.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}