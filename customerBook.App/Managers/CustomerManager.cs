using customerBook.App.Concrete;
using customerBook.Domain.Entity;

namespace customerBook.App.Managers
{
    public class CustomerManager
    {
        private readonly MenuActionService _menuActionService;
        private CustomerService _customerService;
        private CompanyService _companyService;
        private PersonService _personService;
        private PersonManager _personManager;
        private CompanyManager _companyManager;

        public CustomerManager(MenuActionService menuActionService, PersonManager personManager, CompanyManager companyManager, CustomerService customerService, CompanyService company, PersonService personService)
        {
            _menuActionService = menuActionService;
            _customerService = customerService;
            _personManager = personManager;
            _companyManager = companyManager;
            _companyService = company;
            _personService = personService;
        }

        public int AddNewCustomer()
        {
            Console.WriteLine("What you want add:");
            _menuActionService.ViewMenuByName("AddCustomer");

            ConsoleKeyInfo operationId = Console.ReadKey();
            int operation;
            Int32.TryParse(operationId.KeyChar.ToString(), out operation);
            Console.WriteLine();
            try
            {
                Customer newCustomer = operation switch
                {
                    1 => _companyManager.Add(),
                    2 => _personManager.Add(),
                    _ => throw new ArgumentException(message: "Invalid select"),
                };

                newCustomer.Id = _customerService.GetLastId() + 1;
                newCustomer.Loc = CreateLocation();

                _customerService.AddItem(newCustomer);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid select");
                return -1;
            }
            return 1;
        }
        public int View()
        {
            Console.WriteLine("What you want view:");
            _menuActionService.ViewMenuByName("ViewCustomer");

            ConsoleKeyInfo operationId = Console.ReadKey();
            int operation;
            Int32.TryParse(operationId.KeyChar.ToString(), out operation);
            Console.WriteLine();
            try
            {
                int resoult = operation switch
                {
                    1 => _companyService.ViewAll(_customerService.GetAllItems()),
                    2 => _personService.ViewAll(_customerService.GetAllItems()),
                    3 => _customerService.ViewAll(),
                    _ => throw new ArgumentException(message: "Invalid select"),
                };
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid select");
                return -1;
            }
            return 1;
        }
        private Location CreateLocation()
        {

            Location? location = new Location();

            Console.WriteLine("Please enter Township");
            string? readTownship = Console.ReadLine();
            string Township = readTownship.ToString();
            location.Township = Township;
            Console.WriteLine();

            Console.WriteLine("Please enter Street:");
            string? readStreet = Console.ReadLine();
            string Street = readStreet.ToString();
            location.Street = Street;
            Console.WriteLine();

            Console.WriteLine("Please enter Number Street:");
            string? readNumber = Console.ReadLine();
            string Number = readNumber.ToString();
            location.Number = Number;
            Console.WriteLine();

            Console.WriteLine("Please enter ZipCode:");
            string? readZipCode = Console.ReadLine();
            string ZipCode = readZipCode.ToString();
            location.Street = ZipCode;
            Console.WriteLine();

            return location;
        }

        public int SelectId()
        {
            Console.WriteLine("Please select id");
            ConsoleKeyInfo customerId = Console.ReadKey();
            int id;
            Int32.TryParse(customerId.KeyChar.ToString(), out id);
            Console.WriteLine();

            return id;
        }

        public int ViewSelectedById()
        {
            int id = SelectId();
            _customerService.ViewSelectedById(id);
            return id;
        }

        public int DeleteById()
        {
            int id = SelectId();
            _customerService.DeleteCustomerById(id);
            return id;
        }
    }
}
