using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.DataBase.Sql
{
    public class AuthSqlDbContext : IdentityDbContext
    {
        public AuthSqlDbContext(DbContextOptions<AuthSqlDbContext> options) : base(options)
        {

        }
    }
}
