using customerBook.Domain.Entity;

namespace customerBook.App.Concrete
{
    public class CompanyService
    {
        public int ViewAll(List<Customer> customerList)
        {
            Console.WriteLine("All Company");
            foreach (Customer customer in customerList)
            {
                if (IsTypeCompany(customer))
                {
                    customer.View();
                }
            }
            return 2;
        }
        private static bool IsTypeCompany(Customer customer) { return customer.GetType() == typeof(Company); }
    }
}
