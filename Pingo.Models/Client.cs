namespace Pingo.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [IgnoreForSqlAttribute]
        public List<Address> Addresses { get; set; }
        [IgnoreForSqlAttribute]
        public List<Contact> Contacts { get; set; }
    }
}
