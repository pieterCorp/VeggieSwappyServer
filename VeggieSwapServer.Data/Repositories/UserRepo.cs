using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Data.Repositories
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(VeggieSwappyServerContext context)
             : base(context)
        {
        }
        public async Task<bool> UserExistsAsync(string eMail)
        {
            return await _context.Users.AnyAsync(x => x.Email == eMail.ToLower());
        }

        public virtual async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Set<User>()
                       .Include(x => x.Address)
                       .Include(x => x.UserTradeItems)
                       .ThenInclude(x => x.Resource)
                       .Include(x => x.Trades)
                       .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(x => x.Address)
                .Include(x => x.UserTradeItems)
                .ThenInclude(x => x.Resource)
                .Include(x => x.Trades)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserTradeItem>> GetAllUserTradeItemsAsync()
        {
            return await _context.Set<UserTradeItem>()
                .Include(x => x.Resource)
                .Include(x => x.User)
                .ThenInclude(x => x.Address)
                .ToListAsync();
        }

        public override Task<bool> AddEntityAsync(User entity)
        {
            return base.AddEntityAsync(entity);
        }

        //public override async Task<bool> UpdateEntityAsync(User entity)
        //{
        //    entity.ModifiedAt = DateTime.Now;
        //    _context.Update(entity);
        //    _context.Entry(entity).Property(p => p.PasswordHash).IsModified = false;
        //    _context.Entry(entity).Property(p => p.PasswordSalt).IsModified = false;
        //    await _context.SaveChangesAsync();

        //    return true;
        //}
    }
}
