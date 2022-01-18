using System;


namespace customerBook
{
    public class Person : Customer, IPeople
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        public override void View()
        {
            Console.Write($"{Id}.{FirstName} {LastName} - ");
            base.View();
        }
    }
}
