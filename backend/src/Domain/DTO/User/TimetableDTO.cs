using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTO.User
{
    public class TimetableDTO
    {
        public int Id { get; set; }
        public ulong Start { get; set; }
        public ulong End { get; set; }
        public ulong Break { get; set; }
        public Weekday DayOfWeek { get; set; }
        public int UserId { get; set; }
    }
}