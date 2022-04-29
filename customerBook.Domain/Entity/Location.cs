using System;
using System.Xml.Serialization;

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
            Township = "-";
            Street = "-";
            Number = "-";
            ZipCode = "-";
        }
        public Location(string township,string street,string number, string zipcode)
        {
            Township = township;
            Street = street;
            Number = number;
            ZipCode = zipcode;
        }
        public void View()
        {
            Console.WriteLine($"ul.{Street} {Number},{ZipCode}-{Township}");
        }
    }
}
