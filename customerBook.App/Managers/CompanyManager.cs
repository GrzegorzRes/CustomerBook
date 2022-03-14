using customerBook.Domain.Entity;

namespace customerBook.App.Managers
{
    public class CompanyManager
    {
        public Company Add()
        {
            Console.WriteLine("Pleas enter data-Name:");
            string? readName = Console.ReadLine();
            string name = readName.ToString();
            Console.WriteLine();

            Console.WriteLine("Pleas enter data-NIP:");
            string? readNIP = Console.ReadLine();
            string NIP = readNIP.ToString();
            Console.WriteLine();

            return new Company(name, NIP);
        }
    }
}
