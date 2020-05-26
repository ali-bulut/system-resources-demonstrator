using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading;

namespace SystemResourcesDemonstrator.Models
{
    public class Disk
    {
        [JsonPropertyName("diskName")]
        public string DiskName { get; set; }

        [JsonPropertyName("total")]
        public double TotalDisk { get; set; }

        [JsonPropertyName("inUse")]
        public double DiskUsage { get; set; }
    }
}
