using System;
using System.Collections.Generic;
using System.IO;
using customerBook.App.Concrete;
using customerBook.App.Concrete.IO;
using customerBook.App.Managers;
using customerBook.Domain.Entity;

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
            string path2 = Directory.GetCurrentDirectory() + "\\date.txt";
            ServiceWriter serviceWriter = new ServiceWriter(customerService, path2);
            ServiceReader serviceReader = new ServiceReader(customerService, path2);

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
                        5 => serviceWriter.WriteFile(),
                        6 => serviceReader.ReadFile(),
                        7 => -2,
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
