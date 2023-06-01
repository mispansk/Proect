using final5.Models;

namespace final5.Repositories.IRepos
{
    /// <summary>
    /// методы для работы с комментариями 
    /// </summary>
    public interface ICommentRepository
    {
        Task AddComment(Comment comment); // добавление коммента
        Task<Comment[]> GetComments(); // все комменты
        Task<Comment[]> GetCommentByIDUser(Guid id); // поиск коммента по ID пользователя
        Task DeleteComment(Comment comment); // удаление коммента
    }
}
