using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task ChangePassword(int id, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                user.Password = Crypto.CryptoToBCrypt(password);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Create(User user)
        {
            user.Password = Crypto.CryptoToBCrypt(user.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.Users.AnyAsync(c => c.Id == id);
            return res;
        }

        public async Task<bool> IsEmailInUse(string email)
        {
            var res = await _context.Users.AnyAsync(c => c.Email == email);
            return res;
        }

        public async Task<bool> IsPhoneInUse(string phone)
        {
            var res = await _context.Users.AnyAsync(c => c.Phone == phone);
            return res;
        }

        public async Task<User> Read(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<User>> ReadAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(int id, User user)
        {
            var res = await _context.Users.FirstOrDefaultAsync(c => c.Id == user.Id);

            if (res == null)
                return;

            res.Name = user.Name;
            res.Phone = user.Phone;
            res.Email = user.Email;
            res.PhotoUrl = user.PhotoUrl;
            res.IsActive = user.IsActive;

            await _context.SaveChangesAsync();
        }
    }
}