/*
A classe Category é feita para informar que tipo de contato é cada contact.
Um contato pode ter mais de uma categoria e uma categoria pode conter mais de um contato. Many to many.
*/

using System.Collections.Generic;

namespace PhoneBook.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public IList<Contact> Contacts { get; set; }

        public IList<PhoneNumber> PhoneNumbers { get; set; }
    }
}