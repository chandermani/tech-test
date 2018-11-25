using System;

namespace AnyCompany
{
    internal class VatCalculator
    {
        internal double CalculateVat(Customer customer)
        {
            return customer.Country == "UK" ? 0.2d : 0;
        }
    }
}