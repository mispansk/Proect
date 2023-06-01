using final5.Models;
using final5.Repositories.IRepos;
using Microsoft.EntityFrameworkCore;

namespace final5.Repositories.Repos
{
    // реалезация интерфейса
    public class UserRepository : IUserRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public UserRepository(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// добавление пользователя
        /// </summary>
        public async Task AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            user.Role = _context.Roles.FirstOrDefault(r => r.Id == 1); // присваеваем роль "пользователь

            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// все пользователи
        /// </summary>
        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }

        /// <summary>
        /// поиск пользователя по ID
        /// </summary>
        public async Task<User> GetUserByID(Guid id)
        {
            return await _context.Users.Where(v => v.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// удаление пользователя
        /// </summary>
        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// поиск пользователя по логину
        /// </summary>
        public User GetByLogin(string login)
        {
            return _context.Users.FirstOrDefault(v => v.Login == login);
        }

        


    }
}
