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

        //create cusotm Models and change here with the Tbl_Vendor
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