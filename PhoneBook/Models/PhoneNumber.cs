namespace PhoneBook.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public Contact Contacts { get; set; }

        public Category Categories { get; set; }
    }
}