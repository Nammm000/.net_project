namespace api.Dtos.Warehouse
{
    public class WarehouseDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsRefrigerated { get; set; }

        public bool Status { get; set; }

        public long LocationId { get; set; }

        public string LocationName { get; set; }

        public WarehouseDto() { }

        public WarehouseDto(long id, string name, bool isRefrigerated, bool status, long locationId, string locationName)
        {
            Id = id;
            Name = name;
            IsRefrigerated = isRefrigerated;
            Status = status;
            LocationId = locationId;
            LocationName = locationName;
        }

        public WarehouseDto(long id, string name, bool isRefrigerated)
        {
            Id = id;
            Name = name;
            IsRefrigerated = isRefrigerated;
        }
    }
}