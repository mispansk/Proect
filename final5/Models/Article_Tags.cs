namespace final5.Models
{
    public class Article_Tags
    {
        public Guid Id { get; set; }
        public Article Article { get; set; }
        public Tag Tag { get; set; }
    }
}
