﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Domain.Model
{
    public class EditPersonPhoneViewModel
    {
        public int PersonId { get; set; }
        public string Number { get; set; }
        public int PhoneNumberTypeId { get; set; }
    }
}
