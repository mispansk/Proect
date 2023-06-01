using final5.Models;

namespace final5.Repositories.IRepos
{
    /// <summary>
    /// методы для работы с тегами
    /// </summary>
    public interface ITagRepository
    {
        Task AddTag(Tag tag); // добавление тега
        Task<Tag[]> GetTags(); // все теги
        Task<Tag> GetTagByID(Guid id); // поиск тега по ID
        Task DeleteTag(Tag tag); // удаление тега
    }
}
