using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TandemAssesment.Model
{
    public class UserSaveModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
    }
}
