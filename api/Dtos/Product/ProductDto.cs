namespace api.Dtos.Product
{
    public class ProductDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public long CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ProductDto() { }

        public ProductDto(long id, string name, string description, int price, long categoryId, string categoryName, string status)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            CategoryName = categoryName;
            Status = status;
        }

        public ProductDto(string categoryName, long categoryId)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public ProductDto(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProductDto(long id, string name, string description, int price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}