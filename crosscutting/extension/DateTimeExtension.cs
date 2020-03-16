using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace crosscutting.extension
{
    public static class DateTimeExtension
    {
        public static DateTime GetBrazilianDateTime(this DateTime date)
        {
            TimeZoneInfo targetTimeZone; //= TimeZoneInfo.FindSystemTimeZoneById(timeZoneId); 

            if (IsWindowsOsPlatform())
            {
                targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }
            else
            {
                targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            }

            return TimeZoneInfo.ConvertTime(date, targetTimeZone);
        }

        public static bool IsWindowsOsPlatform() =>
            System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
}