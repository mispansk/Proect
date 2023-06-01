namespace final5.Models
{
    /// <summary>
    /// класс "Статья"
    /// </summary>
    public class Article
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public User? Author { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Article_Tags> Tags { get; set; }

    }
}
