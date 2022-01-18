using System;

namespace customerBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            CompanyService companyService = new CompanyService();
            PersonService personService = new PersonService();
            CustomerService customerService = new CustomerService(companyService,personService);
            MenuActionService menuActionService = new MenuActionService();
            menuActionService = Initialize(menuActionService);

            Console.WriteLine("Welcome in CustomerBook");
            Console.WriteLine("Pleas let me know what you want do");

            var mainMenu = menuActionService.GetMenuActionByName("Main");
            int resoult = 1;
            int operation;
            while (resoult > -1)
            {
                try
                {
                    foreach (var menuItem in mainMenu)
                    {
                        Console.WriteLine($"{menuItem.Id}. {menuItem.Text}");
                    }

                    var operationId = Console.ReadKey();
                    Int32.TryParse(operationId.KeyChar.ToString(), out operation);
                    Console.WriteLine();

                    resoult = operation switch
                    {
                        1 => customerService.View(),
                        2 => customerService.ViewSelectedById(),
                        3 => customerService.AddNewCustomer(),
                        4 => customerService.DeleteCustomerById(),
                        5 => -2,
                        _ => throw new ArgumentException(message: "Invalid select"),
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid select");
                }
            }

        }

        private static MenuActionService Initialize(MenuActionService menuActionService)
        {
            menuActionService.AddMenuAction(1, "Menu", "Welcome to CustomerBook");
            menuActionService.AddMenuAction(2, "Menu", "Pleas let me know what you want do");

            menuActionService.AddMenuAction(1, "Main", "View all customers/person/company");
            menuActionService.AddMenuAction(2, "Main", "View selected customer");
            menuActionService.AddMenuAction(3, "Main", "Add customer");
            menuActionService.AddMenuAction(4, "Main", "Delete customer");
            menuActionService.AddMenuAction(5, "Main", "Exit");

            return menuActionService;
        }
    }
}
