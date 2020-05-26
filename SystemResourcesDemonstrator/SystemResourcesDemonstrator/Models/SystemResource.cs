using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemResourcesDemonstrator.Models;

namespace SystemResourcesDemonstrator.Models
{
    public class SystemResource
    {
        public SystemResource()
        {
            ResourceManager resourceManager = new ResourceManager();
            Ram = resourceManager.GetRamDetails();
            Cpu = resourceManager.GetCpuDetails();
            Disks = resourceManager.GetDiskDetails();
        }
        public Ram Ram { get; set; }
        public Cpu Cpu { get; set; }
        public List<Disk> Disks { get; set; }
        
    }
}
