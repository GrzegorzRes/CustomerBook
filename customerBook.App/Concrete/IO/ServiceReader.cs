using customerBook.App.Abstract;
using customerBook.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerBook.App.Concrete.IO
{
    public class ServiceReader : IServiceReader
    {
        private string _path;
        private CustomerService _customerService;
        public ServiceReader(CustomerService customerService, string path)
        {
            _customerService = customerService;
            _path = path;
        }

        public int ReadFile()
        {
            using StreamReader streamRead = new StreamReader(_path);
            string output = streamRead.ReadToEnd();
            output = output.Substring(1,output.Length-2);
            string output2 = output.Replace("\\", "");
            var customerFromFile = JsonConvert.DeserializeObject<List<SerializeCustomer>>(output2);
            List<Customer> customers = customerFromFile.Select(p => p.type == typeof(Person) ? (Person)p.person : (Customer)p.company).ToList();

            _customerService.AddAllItem(customers);

            return 1;
        }
    }
}
