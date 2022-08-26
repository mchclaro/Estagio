using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.User;
using Domain.Entities;
using Newtonsoft.Json.Linq;

namespace Domain.Utils
{
    public class TimeTableHelper
    {
        public static IEnumerable<Timetable> ParseManyTimeTables(string jsonList)
        {
            JArray timtableJson = JArray.Parse(jsonList);

            var dtoList = timtableJson.ToObject<TimetableDTO[]>();

            return dtoList
                .Select(dto => new Timetable
                {
                    UserId = dto.UserId,
                    Start = dto.Start,
                    End = dto.End,
                    Break = dto.Break,
                    DayOfWeek = dto.DayOfWeek
                })
                .ToList();
        }
    }
}