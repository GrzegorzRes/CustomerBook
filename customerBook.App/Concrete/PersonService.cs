using customerBook.Domain.Entity;

namespace customerBook.App.Concrete
{
    public class PersonService
    {
        public int ViewAll(List<Customer> customerList)
        {
            Console.WriteLine("All Person");
            foreach (Customer customer in customerList)
            {
                if (IsTypePerson(customer))
                {
                    customer.View();
                }
            }
            return 1;
        }

        private static bool IsTypePerson(Customer customer) { return customer.GetType() == typeof(Person); }
    }
}
