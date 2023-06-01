using Microsoft.EntityFrameworkCore;

namespace final5.Models
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public class BlogContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Article_Tags> Article_Tags { get; set; }



        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) 
        {

            if (Database.EnsureCreated())
            {
                Role role = new Role
                {
                    Id = 1,
                    Name = "Пользователь"
                };
                Roles.Add(role);
                role = new Role
                {
                    Id = 2,
                    Name = "Администратор"
                };
                Roles.Add(role);
                role = new Role
                {
                    Id = 3,
                    Name = "Модератор"
                };
                Roles.Add(role);
            }
        }
    }
}
