using System;
using customerBook.App.Concrete;
using customerBook.App.Managers;

namespace customerBook
{
    public static class Program
    {
        static void Main(string[] args)
        {
            CompanyService companyService = new CompanyService();
            PersonService personService = new PersonService();
            CustomerService customerService = new CustomerService();
            MenuActionService menuActionService = new MenuActionService();
            PersonManager personManager = new PersonManager();
            CompanyManager companyManager = new CompanyManager();

            CustomerManager customerManager = new CustomerManager(menuActionService, personManager, companyManager, customerService, companyService, personService);

            Console.WriteLine("Welcome in CustomerBook");
            Console.WriteLine("Pleas let me know what you want do");

            int resoult = 1;
            int operation;
            while (resoult > -2)
            {
                try
                {
                    menuActionService.ViewMenuByName("Main");

                    ConsoleKeyInfo operationId = Console.ReadKey();
                    Int32.TryParse(operationId.KeyChar.ToString(), out operation);
                    Console.WriteLine();

                    resoult = operation switch
                    {
                        1 => customerManager.View(),
                        2 => customerManager.ViewSelectedById(),
                        3 => customerManager.AddNewCustomer(),
                        4 => customerManager.DeleteById(),
                        5 => -2,
                        _ => throw new ArgumentException(message: "Invalid select"),
                    };
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid select");
                }
            }

        }
    }
}
