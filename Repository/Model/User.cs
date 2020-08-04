using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Model
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
    }
}
