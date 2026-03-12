namespace api.Dtos.Provider
{
    public class ProviderDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Status { get; set; }

        public ProviderDto() { }

        public ProviderDto(long id, string name, string contact, string status)
        {
            Id = id;
            Name = name;
            Contact = contact;
            Status = status;
        }
    }
}