using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A4A.Models
{
    public class AccountModel
    {
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public int Solved { get; set; }
        public int Binding { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Type { get; set; }
    }

    public class UsersModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Rating { get; set; }
    }
}