using customerBook.Domain.Entity;

namespace customerBook.App.Managers
{
    public class PersonManager
    {
        public Person Add()
        {
            Console.WriteLine("Pleas enter data-Firstname:");
            string? readFirstName = Console.ReadLine();
            string firstName = readFirstName.ToString();

            Console.WriteLine("Pleas enter data-Lastname:");
            string? readLastName = Console.ReadLine();
            string lastName = readLastName.ToString();

            return new Person(firstName, lastName);
        }
    }
}
