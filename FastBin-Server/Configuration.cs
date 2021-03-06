﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FastBin_Server
{
    public class Configuration
    {
        public string DatabasePath { get; set; }
        public Configuration()
        {
            this.DatabasePath = "./files/data.litedb";
        }

        public Configuration Load(string configPath = "./files/config.json")
        {
            if (String.IsNullOrEmpty(configPath))
                configPath = "./files/config.json";
            if (!File.Exists(configPath))
            {
                Directory.CreateDirectory("./files");
                this.DatabasePath = "./files/data.litedb";
                File.WriteAllText(configPath, JsonConvert.SerializeObject(this, Formatting.Indented));
            }
            else
            {
                var tempConfig = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(configPath));
                this.DatabasePath = tempConfig.DatabasePath;
            }
            return this;
        }
    }
}
