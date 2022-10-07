namespace ApiCart.Domain
{
    public class Base
    {
        public long Id { get; set; }
        public DateTime DataCreate { get; set; }
        public DateTime? DataUpdate { get; set; }
        public DateTime? DataDelete { get; set; }
    }
}
