using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub.Services
{
    public static class StaticInfos
    {
        public const string connecitonString = @"Server=DESKTOP-SV50LUK\SQLEXPRESS;User ID=sa;Password=123;Database=BusTicket;";

        public enum ScheduleStatus { reserved, empty}

        public static string[] Role = { "Sale Executive", "Manager"};
    }
}
