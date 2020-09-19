using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagerADO.NET
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string DateCreated { get; set; }

    }
}
