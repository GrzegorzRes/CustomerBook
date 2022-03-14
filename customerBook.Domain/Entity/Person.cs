using customerBook.Domain.Abstract;

namespace customerBook.Domain.Entity
{
    public class Person : Customer, IPeople
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
        {
            FirstName = "Empty";
            LastName = "Empty";
        }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override void View()
        {
            Console.Write($"{Id}.{FirstName} {LastName} - ");
            base.View();
        }
    }
}
