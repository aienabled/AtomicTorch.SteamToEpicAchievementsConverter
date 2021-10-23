﻿namespace AtomicTorch.SteamToEpicAchievementsConverter
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class SettingsHelper
    {
        public static readonly string LockedIconFileNameFormat;

        public static readonly string UnlockedIconFileNameFormat;

        static SettingsHelper()
        {
            Console.WriteLine("Reading Settings.ini file...");

            var settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            using (var reader = File.OpenText("Settings.ini"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var split = line.Split('=');
                    var key = split[0].Trim();
                    var value = split[1].Trim();
                    settings.Add(key, value);
                }
            }

            LockedIconFileNameFormat = settings["LockedIconFileNameFormat"];
            UnlockedIconFileNameFormat = settings["UnlockedIconFileNameFormat"];

            Console.WriteLine("Finished reading Settings.ini file.");
        }
    }
}