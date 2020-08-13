using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.Model
{
    public class PersonViewModel
    {
        public string Name { get; set; }

        IList<PersonPhoneViewModel> PhoneNumbers { get; set; }
    }

    public class PersonPhoneViewModel
    {
        public string Type { get; set; }
        public string Numeber { get; set; }
    }
}
