using System;
using System.Collections.Generic;

namespace customerBook
{
    internal class CustomerService
    {
        List<Customer> _customerList;
        CompanyService companyService;
        PersonService personService;
        public CustomerService(CompanyService companyService, PersonService personService)
        {
            this._customerList = new List<Customer>();
            this.companyService = companyService;
            this.personService = personService;
        }

        public int AddNewCustomer()
        {
            Console.WriteLine("What you want add:");
            Console.WriteLine("1. Company");
            Console.WriteLine("2. Person");

            var operationId = Console.ReadKey();
            int operation;
            Int32.TryParse(operationId.KeyChar.ToString(), out operation);
            Console.WriteLine();
            try
            {
                Customer newCustomer = operation switch
                {
                    1 => companyService.Add(),
                    2 => personService.Add(),
                    _ => throw new ArgumentException(message: "Invalid select"),
                };
                newCustomer.Id = _customerList.Count + 1;
                newCustomer.Loc = createLocation();

                _customerList.Add(newCustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid select");
                return -1;
            }
            return 1;
        }

        private Location createLocation()
        {
            
            var location = new Location();

            Console.WriteLine("Please enter Township");
            var readTownship = Console.ReadLine();
            string Township = readTownship.ToString();
            location.Township = Township;
            Console.WriteLine();

            Console.WriteLine("Please enter Street:");
            var readStreet = Console.ReadLine();
            string Street = readStreet.ToString();
            location.Street = Street;
            Console.WriteLine();

            Console.WriteLine("Please enter Number Street:");
            var readNumber = Console.ReadLine();
            string Number = readStreet.ToString();
            location.Number = Number;
            Console.WriteLine();

            Console.WriteLine("Please enter ZipCode:");
            var readZipCode = Console.ReadLine();
            string ZipCode = readStreet.ToString();
            location.Street = ZipCode;
            Console.WriteLine();

            return location;
        }

        public int View()
        {
            Console.WriteLine("What you want view:");
            Console.WriteLine("1. Company");
            Console.WriteLine("2. Person");
            Console.WriteLine("3. All");
            var operationId = Console.ReadKey();
            int operation;
            Int32.TryParse(operationId.KeyChar.ToString(), out operation);
            Console.WriteLine();
            try
            {
                int resoult = operation switch
                {
                    1 => companyService.ViewAll(_customerList),
                    2 => personService.ViewAll(_customerList),
                    3 => ViewAll(),
                    _ => throw new ArgumentException(message: "Invalid select"),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid select");
                return -1;
            }
            return 1;
        }

        public int ViewSelectedById()
        {
            Customer resoult = SelectFirstElementById();
            if (resoult.Loc == null) { 
                return -1;
            }
            resoult.View();
            return 1;
        }

        private int ViewAll()
        {
            foreach (var customer in _customerList)
            {
                customer.View();
            }
            return 3;
        }

        public int DeleteCustomerById()
        {
            Customer resoult = SelectFirstElementById();
            _customerList.Remove(resoult);
            return 1;
        }


        public Customer SelectFirstElementById()
        {
            Console.WriteLine("Please select id");
            var customerId = Console.ReadKey();
            int id;
            Int32.TryParse(customerId.KeyChar.ToString(), out id);
            Console.WriteLine();

            foreach (var customer in _customerList)
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
