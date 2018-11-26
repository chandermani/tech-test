using System;

namespace AnyCompany
{
    public class VatCalculator : IVatCalculator
    {
        public double CalculateVat(Customer customer)
        {
            return customer.Country == "UK" ? 0.2d : 0;
        }
    }
}