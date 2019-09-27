using System;

namespace Timezone
{
    class Parser : IParser
    {
        private DateTime UTCTime = DateTime.UtcNow;

        public void DisplayTime(string time, string timezone)
        {
            try
            {
                Console.WriteLine($"The time in the UK is {UTCTime.ToString("HH:mm")} and the time in {timezone} is {GetTime(timezone)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to parse time for {timezone}. {Environment.NewLine} Error: {e.Message}");
            }
        }

        private string GetTime(string timezone)
        {
            foreach (var zone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (zone.DisplayName.ToLower().Contains(timezone.ToLower()))
                    return TimeZoneInfo.ConvertTimeFromUtc(UTCTime, zone).ToString("HH:mm");
            }
            throw new Exception($"Failed to find system time zone for {timezone}.");
        }
    }
}