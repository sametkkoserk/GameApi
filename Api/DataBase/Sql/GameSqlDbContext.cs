using Api.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace Api.DataBase.Sql
{
    public class GameSqlDbContext : DbContext
    {
        public GameSqlDbContext(DbContextOptions<GameSqlDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
