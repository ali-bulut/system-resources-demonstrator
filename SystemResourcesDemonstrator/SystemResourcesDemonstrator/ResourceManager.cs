using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SystemResourcesDemonstrator.Models;
using NickStrupat;
using System.Management;

namespace SystemResourcesDemonstrator
{
    public class ResourceManager
    {
        public List<Disk> GetDiskDetails()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            List<Disk> disks = new List<Disk>();

            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Disk disk = new Disk();
                    disk.DiskName = drive.Name;
                    disk.DiskUsage = (drive.TotalSize - drive.AvailableFreeSpace) / 1000000000;
                    disk.TotalDisk = drive.TotalSize / 1000000000;
                    disks.Add(disk);
                }
            }

            return disks;
        }

        public Cpu GetCpuDetails()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            ManagementObject mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'");
            Cpu cpu = new Cpu();

            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            var fakeCpuUsage = cpuCounter.NextValue();
            Thread.Sleep(1000);

            cpu.CpuUsagePercent = cpuCounter.NextValue();
            cpu.TotalCpu = (uint)(mo["MaxClockSpeed"]);

            return cpu;
        }

        public Ram GetRamDetails()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            ComputerInfo computerInfo = new ComputerInfo();
            Ram ram = new Ram();

            ram.RamUsage = ramCounter.NextValue();
            ram.TotalRam = computerInfo.TotalPhysicalMemory / 1000000;

            return ram;
        }
    }
}
