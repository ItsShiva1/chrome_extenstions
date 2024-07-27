namespace chrome_extenstions.Models
{
    public class Product
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public List<string> MappedUrls{ get; set; } = new List<string>();
        public string? Url { get; set; }
        public int Price { get; set; }
        public string? SellerId { get; set; }
        public bool InStock { get; set; }
    }
}
