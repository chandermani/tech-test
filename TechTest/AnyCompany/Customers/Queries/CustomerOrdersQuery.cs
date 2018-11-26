using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Queries
{
    public class CustomerOrdersQuery
    {
        private readonly Store.IAnyCompanyDBContext anyCompanyDBContext;

        public CustomerOrdersQuery(Store.IAnyCompanyDBContext anyCompanyDBContext)
        {
            this.anyCompanyDBContext = anyCompanyDBContext;
        }

        public List<Customer> Query()
        {
            // While this is a requirement there are potential performance issues with the query.
            // In reality this should return paged results to avoid potentially querying a huge data set.
            // The same problem is with customer orders too.
            return this.anyCompanyDBContext
                .Customers
                .Include(co => co.Orders)
                .AsNoTracking()             // Query most probably does not require change tracking, disabling it.
                .ToList();
        }
    }
}
