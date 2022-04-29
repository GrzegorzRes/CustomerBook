using customerBook.App.Abstract;
using customerBook.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace customerBook.App.Concrete.IO
{
    public class ServiceWriter : IServiceWriter
    {
        private string _path;
        private CustomerService _customerService;
        public ServiceWriter(CustomerService customerService, string path)
        {
            _customerService = customerService;
            _path = path;
        }

        public int WriteFile()
        {
            List<Customer> customers = _customerService.GetAllItems(); ;
            List<SerializeCustomer> customersSerialize = ChangeTypeToSerializeList(customers);
            string output = JsonConvert.SerializeObject(customersSerialize);
            using StreamWriter streamWriter = new StreamWriter(_path);
            using JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(streamWriter, output);

            return 1;
        }

        public List<SerializeCustomer> ChangeTypeToSerializeList(List<Customer> obj)
        {
            List<SerializeCustomer> customersSerialize = new List<SerializeCustomer>();

            customersSerialize = obj.Select(p => new SerializeCustomer()
            {
                type = p.GetType(),
                person = p.GetType() == typeof(Person) ? (Person)p : null,
                company = p.GetType() == typeof(Company) ? (Company)p : null
            }).ToList();

            return customersSerialize;
        }
    }
}
