using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerBook.Domain.Entity
{
    public class SerializeCustomer
    {
        public Type type { get; set; }
        public Person person { get; set; }
        public Company company { get; set; }
    }
}
