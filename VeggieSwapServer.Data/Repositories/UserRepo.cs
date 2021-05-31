using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<User>> GetUsersWithDataAsync()
        {
            return await _context.Set<User>()

                       .Include(x => x.Trades)

                       .Include(x => x.UserTradeItems)
                       .ThenInclude(x => x.Resource)
                       .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users

                .Include(x => x.Trades)

                .Include(x => x.UserTradeItems)
                .ThenInclude(x => x.Resource)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override Task<bool> AddEntityAsync(User entity)
        {
            return base.AddEntityAsync(entity);
        }
    }
}
