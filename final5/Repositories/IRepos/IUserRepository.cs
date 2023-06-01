using final5.Models;

namespace final5.Repositories.IRepos
{
    /// <summary>
    /// методы для работы с пользователем
    /// </summary>
    public interface IUserRepository
    {
        Task AddUser(User user); // добавление пользователя
        Task<User[]> GetUsers(); // все пользователи
        Task<User> GetUserByID(Guid id); // найти пользователя по ID
        Task DeleteUser(User user); // удаление пользователя

        User GetByLogin(string login); // поиск пользователя по логину

    }
}
