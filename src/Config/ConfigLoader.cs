﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TyniBannerlordFixes
{
    class ConfigLoader
    {
        private static ConfigLoader _instance = null;
        public Config Config { get; private set; }

        public static ConfigLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigLoader();
                }

                return _instance;
            }
        }

        private ConfigLoader()
        {
            string path = Path.Combine(BasePath.Name, "Modules", "TyniBannerlordFixes","ModuleData", "config.xml");
            Config = getConfig(path);
        }

        private Config getConfig(String filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Config));
                using (var reader = new StreamReader(filePath))
                {
                    return (Config)serializer.Deserialize(reader);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Failed to load config, using default native values due to: " + Utils.FlattenException(e));
                Config config = new Config();
                config.RaiseTheMeekXpAmount = 30;
                config.CombatTipsXpAmount = 10;
                return config;
            }
        }
    }
}
