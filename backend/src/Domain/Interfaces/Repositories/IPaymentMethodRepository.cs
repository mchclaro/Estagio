using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<int> Create(PaymentMethod paymentMethod);
        Task Update(PaymentMethod paymentMethod);
        Task Delete(int id);
        Task<bool> Exists(int id);
        Task<PaymentMethod> Read(int id);
        Task<IList<PaymentMethod>> ReadAll();
    }
}