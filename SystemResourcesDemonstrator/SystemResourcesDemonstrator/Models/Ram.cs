using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NickStrupat;

namespace SystemResourcesDemonstrator.Models
{
    public class Ram
    {
        [JsonPropertyName("total")]
        public double TotalRam { get; set; }

        [JsonPropertyName("inUse")]
        public double RamUsage { get; set; }
        
    }
}
