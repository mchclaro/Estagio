using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Domain.DTO.User
{
    public class ListUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }
    }

    public class TimetablesDTO 
    { 
        public int Id { get; set; }
        public ulong Start { get; set; }
        public ulong End { get; set; }
        public ulong Break { get; set; }
        public Weekday DayOfWeek { get; set; }
        public int UserId { get; set; }
    }
}