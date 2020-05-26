using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace SystemResourcesDemonstrator.Models
{
    public class Cpu
    {
        [JsonPropertyName("total")]
        public float TotalCpu { get; set; }

        [JsonPropertyName("inUse")]
        public float CpuUsagePercent { get; set; }
    }
}
