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
            var client = _context.Clients
                                .Include(c => c.Address)
                                .FirstOrDefault(x => x.Id == id);

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
            var res = await _context.Clients
                .Include(x => x.Address)
                .Select(x => new Client
                {
                    Id = x.Id,
                    Name = x.Name,
                    Phone = x.Phone,
                    PhotoUrl = x.PhotoUrl,
                    Address = new Address
                    {
                        Street = x.Address.Street,
                        StreetNumber = x.Address.StreetNumber,
                        ZipCode = x.Address.ZipCode,
                        District = x.Address.District,
                        City = x.Address.City,
                        State = x.Address.State
                    },
                }).FirstOrDefaultAsync(x => x.Id == id);

            return res;
        }

        public async Task<IList<Client>> ReadAll()
        {
            return await _context.Clients
                .Include(a => a.Address)
                .ToListAsync();
        }

        public async Task Update(Client client)
        {
            var cli = await _context.Clients.FindAsync(client.Id);
            if (cli != null)
            {
                cli.Name = client.Name;
                cli.Phone = client.Phone;
                cli.PhotoUrl = client.PhotoUrl;
            }

            var address = await _context.Address.FindAsync(cli.AddressId);
            if (address != null)
            {
                address.Street = client.Address.Street;
                address.StreetNumber = client.Address.StreetNumber;
                address.ZipCode = client.Address.ZipCode;
                address.District = client.Address.District;
                address.City = client.Address.City;
                address.State = client.Address.State;
            }
           
            await _context.SaveChangesAsync();
        }
    }
}