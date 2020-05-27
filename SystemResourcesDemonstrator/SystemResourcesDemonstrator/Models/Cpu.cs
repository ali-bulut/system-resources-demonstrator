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
        [JsonPropertyName("cores")]
        public float Cores { get; set; }

        [JsonPropertyName("utilization")]
        public double CpuUsagePercent { get; set; }

        [JsonPropertyName("currentSpeed")]
        public double CpuCurrentSpeed { get; set; }

        [JsonPropertyName("baseSpeed")]
        public double CpuBasedSpeed { get; set; }

        [JsonPropertyName("logicalProcessors")]
        public float LogicalProcessors { get; set; }

        [JsonPropertyName("physicalProcessors")]
        public float PhysicalProcessors { get; set; }

    }
}
