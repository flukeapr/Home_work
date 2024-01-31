using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLIte_
{
    public class Registration
    {
        [PrimaryKey]
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
