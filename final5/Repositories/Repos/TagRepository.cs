using final5.Models;
using final5.Repositories.IRepos;
using Microsoft.EntityFrameworkCore;

namespace final5.Repositories.Repos
{
    public class TagRepository : ITagRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public TagRepository(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// добавление тега
        /// </summary>
        public async Task AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// удаление тега
        /// </summary>
        public async Task DeleteTag(Tag tag)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// поиск тега по ИД
        /// </summary>
        public async Task<Tag> GetTagByID(Guid id)
        {
            return await _context.Tags.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// все теги
        /// </summary>
        public async Task<Tag[]> GetTags()
        {
            return await _context.Tags.ToArrayAsync();
        }
    }
}
