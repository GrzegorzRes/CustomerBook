using System;
using System.Collections.Generic;


namespace customerBook
{
    internal class PersonService
    {
        public Person Add()
        {
            Person newPreson = new Person();
            Console.WriteLine("Pleas enter data-Firstname:");
            var readName = Console.ReadLine();
            string name = readName.ToString();
            newPreson.FirstName = name;

            Console.WriteLine("Pleas enter data-Lastname:");
            var readNIP = Console.ReadLine();
            string NIP = readNIP.ToString();
            newPreson.LastName = NIP;

            return newPreson;
        }

        public int ViewAll(List<Customer> customerList)
        {
            Console.WriteLine("All Person");
            foreach (var customer in customerList)
            {
                if (isTypePerson(customer))
                {
                    customer.View();
                }
            }
            return 1;
        }

        private bool isTypePerson(Customer customer) { return customer.GetType() == typeof(Person); }
    }
}
