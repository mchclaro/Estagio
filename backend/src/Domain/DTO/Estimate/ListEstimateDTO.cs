using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO.Estimate
{
    public class ListEstimateDTO
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidateDate { get; set; }
        public int ClientId { get; set; }
        public virtual Domain.Entities.Appointment Appointment { get; set; }
        public ClientDto Client { get; set; }
    }

    public class ClientDto
    {
        public string Name { get; set; }
    }
}