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
        public Store.AnyCompanyDBContext AnyCompanyDBContext { get; }

        public AnyCompanyDBFixture()
        {
            AnyCompanyDBContext = new Store.AnyCompanyDBContext();
            CleanDB();
            AddCustomers();
        }

        private void AddCustomers()
        {
            AnyCompanyDBContext.Customers.Add(new Customer() { Name = "Jim", Country = "UK", DateOfBirth = new DateTime(1991, 1, 1) });
            AnyCompanyDBContext.Customers.Add(new Customer() { Name = "Jack", Country = "USA", DateOfBirth = new DateTime(1992, 1, 1) });
            AnyCompanyDBContext.Customers.Add(new Customer() { Name = "Tom", Country = "France", DateOfBirth = new DateTime(1993, 1, 1) });
            AnyCompanyDBContext.Customers.Add(new Customer() { Name = "Sam", Country = "UK", DateOfBirth = new DateTime(1994, 1, 1) });
            AnyCompanyDBContext.SaveChanges();

            AnyCompanyDBContext.Orders.Add(new Order() {OrderId=12323, Amount = 123d, CustomerId = CustomerWithAttachedOrders.CustomerId, VAT = 0 });
            AnyCompanyDBContext.Orders.Add(new Order() {OrderId=52212, Amount = 13123d, CustomerId = CustomerWithAttachedOrders.CustomerId, VAT = 0 });
            AnyCompanyDBContext.Orders.Add(new Order() {OrderId=53431, Amount = 16323d, CustomerId = CustomerWithAttachedOrders.CustomerId, VAT = 0 });
            AnyCompanyDBContext.SaveChanges();
        }

        public string ConnectionString => AnyCompanyDBContext.Database.GetDbConnection().ConnectionString;

        public Customer UKCustomer => AnyCompanyDBContext.Customers.FirstOrDefault(c => c.Country == "UK");

        public Customer OtherCustomer => AnyCompanyDBContext.Customers.FirstOrDefault(c => c.Country != "UK");

        public Customer CustomerWithAttachedOrders=> AnyCompanyDBContext.Customers.First(c => c.Name == "Tom");

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    CleanDB();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        private void CleanDB()
        {
            AnyCompanyDBContext.Database.ExecuteSqlCommand("DELETE FROM [Orders]");
            AnyCompanyDBContext.Database.ExecuteSqlCommand("DELETE FROM [Customer]");
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
