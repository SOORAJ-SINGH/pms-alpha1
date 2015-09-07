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
        private somyatrans_pmsDBContext dbContext = new somyatrans_pmsDBContext();
        private GenericRepository<TBL_Vendor> vendorRepository;
        private GenericRepository<TBL_M_Domain> domainRepository;
        private GenericRepository<TBL_M_Country> countryRepository;
        private GenericRepository<TBL_M_State> stateRepository;
        private GenericRepository<TBL_M_City> cityRepository;

        private GenericRepository<TBL_M_Language> languageRepository;



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

        public GenericRepository<TBL_M_Domain> DomainRepository
        {
            get
            {
                if (this.domainRepository == null)
                {
                    this.domainRepository = new GenericRepository<TBL_M_Domain>(dbContext);
                    
                }
                return domainRepository;
            }
        }
        public GenericRepository<TBL_M_Country> CountryRepository
        {
            get
            {
                if (this.countryRepository == null)
                {
                    this.countryRepository = new GenericRepository<TBL_M_Country>(dbContext);

                }
                return countryRepository;
            }
        }


        public GenericRepository<TBL_M_State> StateRepository
        {
            get
            {
                if (this.stateRepository == null)
                {
                    this.stateRepository = new GenericRepository<TBL_M_State>(dbContext);

                }
                return stateRepository;
            }
        }


        public GenericRepository<TBL_M_City> CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                {
                    this.cityRepository = new GenericRepository<TBL_M_City>(dbContext);

                }
                return cityRepository;
            }
        }

        public GenericRepository<TBL_M_Language> LanguageRepository
        {
            get
            {
                if (this.languageRepository == null)
                {
                    this.languageRepository = new GenericRepository<TBL_M_Language>(dbContext);

                }
                return languageRepository;
            }
        }
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