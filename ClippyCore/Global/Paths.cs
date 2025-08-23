using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClippyCore.Global
{
    /// <summary>
    /// Paths to ACS Files and data files.
    /// </summary>
    internal static class Paths
    {
        public static string LOGGER => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Data", "logs.txt");
        public static string BONZI => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Agents", "bonzi vine.acs");
        public static string CLIPPY => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Agents", "CLIPPIT.acs");
        public static string SHREK => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Agents", "Shrek.acs");
    }
}
