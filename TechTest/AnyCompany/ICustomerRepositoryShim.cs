namespace AnyCompany
{
    public interface ICustomerRepositoryShim
    {
        Customer Load(int customerId);
    }
}