using ESN.Dal;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
   public class CustomerBLL:ICustomerBLL, IDisposable
    {
       protected readonly ICustomerDAL customerDAL;
        public CustomerBLL()
        {
            this.customerDAL = new CustomerDAL();
        }

        public IEnumerable<Course> GetAll()
        {
            return customerDAL.GetAll();
        }
        public Course GetById(int Id)
        {
            return customerDAL.GetById(Id);
        }

        #region IDisposable Support

        /// <summary>
        /// The disposed value.
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (customerDAL != null)
                    {
                        customerDAL.Dispose();
                    }                   
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);

            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}
