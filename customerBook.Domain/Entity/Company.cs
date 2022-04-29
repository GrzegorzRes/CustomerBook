using customerBook.Domain.Abstract;
using System.Xml.Serialization;

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
        public Company(string name, string nip, Location loc, int id):base()
        {
            Id = id;
            Loc = loc;
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
