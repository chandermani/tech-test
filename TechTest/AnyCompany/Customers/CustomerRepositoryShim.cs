using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
    public class CustomerRepositoryShim : ICustomerRepositoryShim
    {
        public Customer Load(int customerId)
        {   
            return CustomerRepository.Load(customerId);
        }
    }
}
