using Api.DataBase.Sql;
using Api.Models.Domains;
using Api.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Users
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly GameSqlDbContext sqlDbContext;
        public SqlUserRepository(GameSqlDbContext sqlDbContext) 
        {
            this.sqlDbContext=sqlDbContext;
        }


        public async Task<List<User>> GetAllAsync()
        {
            return await sqlDbContext.Users.ToListAsync();
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await sqlDbContext.Users.FindAsync(id);
        }
        public async Task<User?> CreateUserAsync(User user)
        {
            await sqlDbContext.Users.AddAsync(user);
            await sqlDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUserAsync(Guid id,UpdateUserDto userDto)
        {
            var user = await sqlDbContext.Users.FindAsync(id);
            if (user==null)
            {
                return null;
            }
            user.userName = userDto.userName;
            user.FullName = userDto.fullName;
            user.email = userDto.email;
            await sqlDbContext.SaveChangesAsync();
            return user;
            
        }

        public async Task<User?> DeleteUserAsync(Guid id)
        {
            var user=await sqlDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            sqlDbContext.Users.Remove(user);
            await sqlDbContext.SaveChangesAsync();
            return user;
        }
    }
}
