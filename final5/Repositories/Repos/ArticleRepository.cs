using final5.Models;
using final5.Repositories.IRepos;
using Microsoft.EntityFrameworkCore;

namespace final5.Repositories.Repos
{
    public class ArticleRepository : IArticleRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public ArticleRepository(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// добавление статьи
        /// </summary>
        public async Task AddArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// удаление статьи
        /// </summary>
        public async Task DeleteArticle(Article article)
        {
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }

    /// <summary>
    /// поиск статей по ИД пользователя
    /// </summary>
        public async Task<Article[]> GetArticleByIDUser(Guid id)
        {
            return await _context.Articles.Include(a => a.Author)
                .Where(a => a.Id == id).ToArrayAsync();
        }

        /// <summary>
        /// все статьи
        /// </summary>
        public async Task<Article[]> GetArticles()
        {
            return await _context.Articles.Include(a => a.Author)
                .ToArrayAsync();
            //return await _context.Articles.ToArrayAsync();
        }
    }
}
