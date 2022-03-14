using System;


namespace customerBook.Domain.Entity
{
    public class Location
    {
        public string Township { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }

        public Location()
        {

        }
        public void View()
        {
            Console.WriteLine($"ul.{Street} {Number},{ZipCode}-{Township}");
        }
    }
}
