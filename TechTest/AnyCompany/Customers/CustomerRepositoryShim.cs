using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
    public class CustomerRepositoryShim : ICustomerRepositoryShim
    {
        private readonly Store.IAnyCompanyDBContext anyCompanyDBContext;

        public CustomerRepositoryShim(Store.IAnyCompanyDBContext anyCompanyDBContext)
        {
            this.anyCompanyDBContext = anyCompanyDBContext;
        }

        public Customer Load(int customerId)
        {

            CustomerRepository.SetContext(anyCompanyDBContext);
            return CustomerRepository.Load(customerId);
        }
    }
}
