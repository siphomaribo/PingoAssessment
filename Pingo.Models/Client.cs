namespace Pingo.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<Guid> AddressIds { get; set; } 
        public List<Guid> ContactIds { get; set; }
    }
}
