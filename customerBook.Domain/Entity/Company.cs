using customerBook.Domain.Abstract;

namespace customerBook.Domain.Entity
{
    public class Company : Customer, ICompany
    {
        public string Name { get; set; }
        public string NIP { get; set; }

        public Company()
        {
            Name = "Empty";
            NIP = "Empty";
        }
        public Company(string name, string nip)
        {
            Name = name;
            NIP = nip;
        }
        public override void View()
        {
            Console.Write($"{Id}.{Name} {NIP}");
            base.View();
        }
    }
}
