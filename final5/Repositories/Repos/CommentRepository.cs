using final5.Models;
using final5.Repositories.IRepos;
using Microsoft.EntityFrameworkCore;

namespace final5.Repositories.Repos
{
    public class CommentRepository : ICommentRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public CommentRepository(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// добавление коммента
        /// </summary>
        public async Task AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// удаление коммента
        /// </summary>
        public async Task DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// поиск коммента по ИД пользователя
        /// </summary>
        public async Task<Comment[]> GetCommentByIDUser(Guid id)
        {
            return await _context.Comments.Include(c => c.AuthorCom)
                .Where(c => c.Id == id).ToArrayAsync();
        }

        /// <summary>
        /// все комменты
        /// </summary>
        public async Task<Comment[]> GetComments()
        {
            return await _context.Comments.ToArrayAsync();
        }
    }
}
