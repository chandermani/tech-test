using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnyCompany.Tests
{
    public class AnyCompanyDBFixture:IDisposable
    {
        public AnyCompanyDBFixture()
        {
            AnyCompanyDBContext = new AnyCompanyDBContext();

            AddCustomers();
        }

        private void AddCustomers()
        {
            AnyCompanyDBContext.Customers.Add(new Customer() { Name = "Jim", Country = "UK", DateOfBirth = new DateTime(1991, 1, 1) });
            AnyCompanyDBContext.Customers.Add(new Customer() { Name = "Jack", Country = "USA", DateOfBirth = new DateTime(1992, 1, 1) });
            AnyCompanyDBContext.Customers.Add(new Customer() { Name = "Tom", Country = "France", DateOfBirth = new DateTime(1993, 1, 1) });
            AnyCompanyDBContext.Customers.Add(new Customer() { Name = "Sam", Country = "UK", DateOfBirth = new DateTime(1994, 1, 1) });
            AnyCompanyDBContext.SaveChanges();
        }

        public AnyCompanyDBContext AnyCompanyDBContext { get; }

        public Customer UKCustomer => AnyCompanyDBContext.Customers.FirstOrDefault(c => c.Country == "UK");

        public Customer OtherCustomer => AnyCompanyDBContext.Customers.FirstOrDefault(c => c.Country != "UK");

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    AnyCompanyDBContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customer]");
                    AnyCompanyDBContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Orders]");
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AnyCompanyDBFixture() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    [CollectionDefinition("AnyCompany Database collection")]
    public class AnyCAnyCompanyDBFixtureompanyDAnyCompanyDBFixtureBCollection: ICollectionFixture<AnyCompanyDBFixture>
    {

    }
}
