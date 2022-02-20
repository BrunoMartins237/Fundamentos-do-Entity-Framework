using System.Collections.Generic;

namespace PhoneBook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<PhoneNumber> PhoneNumbers { get; set; }
    }
}