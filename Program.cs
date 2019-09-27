using System;
using System.Collections.Generic;

namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            try
            {
                Parser timeZoneParser = new Parser();
                using (Reader fileReader = new Reader())
                {
                    List<Tuple<string, string>> lTimes = fileReader.Read();
                    foreach (var time in lTimes)
                    {
                        timeZoneParser.DisplayTime(time.Item1, time.Item2);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Program failed to execute successfully." + 
                                  Environment.NewLine + 
                                  "Stacktrace:" + 
                                  Environment.NewLine + 
                                  e.StackTrace);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
