using System;
using System.IO;
using System.Web.Script.Serialization;
using SKYNET.Models;

namespace SKYNET
{
    public class SettingsManager
    {
        public string DBPath { get; set; }
        public uint CurrentCource { get; set; }
        public string CurrentDepartament { get; set; }

        private bool Empty;
        private string dataPath;
        private string settingsPath;

        public SettingsManager()
        {
            dataPath = Path.Combine(Common.GetPath(), "Data");
            settingsPath = Path.Combine(dataPath, "Settings.json");

            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
                Empty = true;
            }
            if (!File.Exists(settingsPath))
            {
                Empty = true;
            }
        }

        public void Load()
        {
            if (Empty)
            {
                ResetDefaults();
                return;
            }
            try
            {
                string json = File.ReadAllText(settingsPath);
                var Instance = new JavaScriptSerializer().Deserialize<SettingsManager>(json);

                DBPath =             Instance.DBPath;
                CurrentCource =      Instance.CurrentCource;
                CurrentDepartament = Instance.CurrentDepartament;
            }
            catch
            {
                ResetDefaults();
            }
        }

        public void Save()
        {
            string json = new JavaScriptSerializer().Serialize(this);
            if (!Directory.Exists(dataPath)) { Directory.CreateDirectory(dataPath); }
            File.WriteAllText(settingsPath, json);
        }

        private void ResetDefaults()
        {
            DBPath = Path.Combine(dataPath, "DB.db");
            CurrentDepartament = "CUM SAN LUIS";
        }
    }
}