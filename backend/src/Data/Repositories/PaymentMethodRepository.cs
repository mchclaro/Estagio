using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        readonly DataContext _context;
        public PaymentMethodRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(PaymentMethod paymentMethod)
        {
            await _context.PaymentMethods.AddAsync(paymentMethod);
            await _context.SaveChangesAsync();

            return paymentMethod.Id;
        }

        public async Task Delete(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(c => c.Id == id);

            if (paymentMethod == null)
                return;

            _context.PaymentMethods.Remove(paymentMethod);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.PaymentMethods.AnyAsync(c => c.Id == id);
            return res;
        }

        public async Task<PaymentMethod> Read(int id)
        {
            return await _context.PaymentMethods.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<PaymentMethod>> ReadAll()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task Update(PaymentMethod paymentMethod)
        {
            var res = await _context.PaymentMethods.FirstOrDefaultAsync(c => c.Id == paymentMethod.Id);

            if (res == null)
                return;

            //atributos do PaymentMethod
            res.Name = paymentMethod.Name;
            res.Description = paymentMethod.Description;

            await _context.SaveChangesAsync();
        }
    }
}