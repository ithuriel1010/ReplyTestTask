using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplyTestTask.Objects
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public List<string> Categories { get; set; }
        public Contact(string firstName, string lastName, string role, List<string> category)
        {
           FirstName = firstName;
           LastName = lastName;    
           Role = role;
           Categories = category;
        }
    }
}
