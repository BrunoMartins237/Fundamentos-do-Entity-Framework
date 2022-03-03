using System;
using System.Linq;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new PhoneBookDataContext();
           //testanto os relacionamentos.
            // var contact = new Contact
            // {
            //     Name = "Bruno",
            //     Email = "bruno@hotmail.on"
            // };
            // context.Contacts.Add(contact);
            // context.SaveChanges();

            var contact = context.Contacts.FirstOrDefault();
            var number = new PhoneNumber
            {
                Contacts = contact,
                Number = "8888",
                Categories = new Category
                {
                    Name = "Pessoal"
                }
                
            };

            context.PhoneNumbers.Add(number);
            context.SaveChanges();

        
        }
    }
}
