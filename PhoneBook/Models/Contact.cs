using System.Collections.Generic;

namespace PhoneBook.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        public IList<PhoneNumber> PhoneNumbers { get; set; }

        public IList<Category> Categories { get; set; }
    }
}