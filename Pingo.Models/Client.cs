namespace Pingo.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<Address> Addresses { get; set; } 
        public List<Contact> Contacts { get; set; }
    }
}
