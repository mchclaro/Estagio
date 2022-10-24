using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO.Client
{
    public class ListClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
        public virtual ICollection<Domain.Entities.Appointment> Appointments { get; set; }
        public AddressDto Address { get; set; }
        public virtual ICollection<Domain.Entities.Estimate> Estimates { get; set; }  
    }
    public class AddressDto
    {
        public string City { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
    } 
}