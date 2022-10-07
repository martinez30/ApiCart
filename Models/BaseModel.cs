namespace ApiCart.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime DataCreate { get; set; }
        public DateTime? DataUpdate { get; set; }
        public DateTime? DataDelete { get; set; }
    }
}
