using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return client.Id;
        }

        public async Task Delete(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
                return;

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.Clients.AnyAsync(c => c.Id == id);
            return res;
        }

        public async Task<bool> IsPhoneInUse(string phone)
        {
            var res = await _context.Clients.AnyAsync(c => c.Phone == phone);
            return res;
        }

        public async Task<Client> Read(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Client>> ReadAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task Update(Client client)
        {
            var cli = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);
            if (cli != null)
            {
                cli.Name = client.Name;
                cli.Phone = client.Phone;
                cli.PhotoUrl = client.PhotoUrl;
            }

            var address = await _context.Address.FirstOrDefaultAsync(c => c.Id == client.Id);
            if (address != null)
            {
                address.Street = client.Address.Street;
                address.StreetNumber = client.Address.StreetNumber;
                address.ZipCode = client.Address.ZipCode;
                address.District = client.Address.District;
                address.Complement = client.Address.Complement;
                address.City = client.Address.City;
                address.State = client.Address.State;
            }
           
            await _context.SaveChangesAsync();
        }
    }
}