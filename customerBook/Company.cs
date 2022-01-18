using System;

namespace customerBook
{
    public class Company : Customer,ICompany
    {
        public string Name { get; set; }
        public string NIP { get; set; }

        public override void View()
        {
            Console.Write($"{Id}.{Name} {NIP}");
            base.View();
        }
    }
}
