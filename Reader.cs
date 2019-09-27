using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Timezone
{
    class Reader : IReader, IDisposable
    {
        public List<Tuple<string, string>> Read()
        {
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();

            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Timezone.Timezone.txt"))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Tuple<string, string> timeZone = new Tuple<string, string>(line.Split(' ').First(), line.Split(' ').Last());
                            lReturn.Add(timeZone);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return lReturn;
        }
        public void Dispose()
        {
        }
    }
}
