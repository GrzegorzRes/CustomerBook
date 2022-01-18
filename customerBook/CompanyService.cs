using System;
using System.Collections.Generic;

namespace customerBook
{
    internal class CompanyService
    {
        
        public Customer Add()
        {
            Company newCompany = new Company();
            Console.WriteLine("Pleas enter data-Name:");
            var readName = Console.ReadLine();
            string name = readName.ToString();
            newCompany.Name = name;
            Console.WriteLine();

            Console.WriteLine("Pleas enter data-NIP:");
            var readNIP = Console.ReadLine();
            string NIP = readNIP.ToString();
            newCompany.NIP = NIP;
            Console.WriteLine();

            return newCompany;
        }

        public int ViewAll(List<Customer> customerList)
        {
            Console.WriteLine("All Company");
            foreach (var customer in customerList)
            {
                if (isTypeCompany(customer))
                {
                    customer.View();
                }
            }
            return 2;
        }
        private bool isTypeCompany(Customer customer) { return customer.GetType() == typeof(Company); }
    }
}
