using final5.Models;

namespace final5.Repositories.IRepos
{
    /// <summary>
    /// методы для работы со статьей
    /// </summary>
    public interface IArticleRepository
    {
        Task AddArticle(Article article); // добавление статьи
        Task<Article[]> GetArticles(); // все статьи
        Task<Article[]> GetArticleByIDUser(Guid id); // поиск статьи по ID пользователя
        Task DeleteArticle(Article article); // удаление статьи
    }
}
