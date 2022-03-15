using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjektSemestralny.Logika
{
    public class Configuration
    {
        public string ConnectionString { get; set; }

        public static Configuration GetConfiguration(string filename)
        {
            if(!File.Exists(filename))
            {
                return null;
            }

            string data = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<Configuration>(data);
        }
    }
}
