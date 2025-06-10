namespace ECommerce.Catalog.Dtos.BrandDtos
{
    public class CreateBrandDto
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }

    public class UpdateBrandDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }

    public class ResultBrandDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }
}