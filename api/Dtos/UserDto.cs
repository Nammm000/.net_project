namespace api.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Status { get; set; }

        public UserDto() { }

        public UserDto(string id, string name, string email, string phone, string status)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Status = status;
        }
    }
}