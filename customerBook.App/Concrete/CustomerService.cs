using customerBook.App.Common;
using customerBook.Domain.Entity;

namespace customerBook.App.Concrete
{
    public class CustomerService : BaseService<Customer>
    {
        public CustomerService()
        {
        }

        public int ViewSelectedById(int id)
        {
            Customer resoult = SelectFirstElementById(id);
            if (resoult.Id == 0)
            {
                return -1;
            }
            resoult.View();
            return 1;
        }

        public int ViewAll()
        {
            foreach (Customer customer in Items)
            {
                customer.View();
            }
            return 1;
        }

        public int DeleteCustomerById(int id)
        {
            Customer resoult = SelectFirstElementById(id);
            RemoveItem(resoult);
            return 1;
        }


        public Customer SelectFirstElementById(int id)
        {
            foreach (Customer customer in Items)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return new Company();
        }
    }
}
