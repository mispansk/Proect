namespace final5.Models
{/// <summary>
/// класс "Комментарий"
/// </summary>
    public class Comment
    {
        public Guid Id { get; set; }
        public User? AuthorCom { get; set; }
        public string? Com { get; set; }
        public Article? Article { get; set; }
    }
}
