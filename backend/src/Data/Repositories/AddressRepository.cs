using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        readonly DataContext _context;
        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Address address)
        {
            await _context.Address.AddAsync(address);
            await _context.SaveChangesAsync();

            return address.Id;
        }
    }
}