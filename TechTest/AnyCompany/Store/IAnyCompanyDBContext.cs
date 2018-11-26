using Microsoft.EntityFrameworkCore;

namespace AnyCompany.Store
{
    public interface IAnyCompanyDBContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
    }
}