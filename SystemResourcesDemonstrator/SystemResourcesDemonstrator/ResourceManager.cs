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
                    //in order to format the value like "12.34"
                    double diskUsage = Math.Truncate((drive.TotalSize - drive.TotalFreeSpace) * (9.31 / 10000000000) * 100) / 100;
                    disk.DiskUsage = diskUsage;

                    double totalDisk = Math.Truncate(drive.TotalSize * (9.31 / 10000000000) * 100) / 100;
                    disk.TotalDisk = totalDisk;
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

            double usagePercent = Math.Truncate(cpuCounter.NextValue() * 100) / 100;
            cpu.CpuUsagePercent = usagePercent;

            foreach (var item in new ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                cpu.Cores += int.Parse(item["NumberOfCores"].ToString());
            }

            cpu.CpuCurrentSpeed = (uint)(mo["CurrentClockSpeed"]);
            cpu.CpuBasedSpeed = (uint) (mo["MaxClockSpeed"]);

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                cpu.LogicalProcessors = int.Parse(item["NumberOfLogicalProcessors"].ToString());
            }

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                cpu.PhysicalProcessors = int.Parse(item["NumberOfProcessors"].ToString());
            }

            return cpu;
        }

        public Ram GetRamDetails()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            ComputerInfo computerInfo = new ComputerInfo();
            Ram ram = new Ram();

            double ramUsage = Math.Truncate((computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) *
                                            (9.31 / 10000000000) * 100) / 100;
            ram.RamUsage = ramUsage;

            double totalRam = Math.Truncate(computerInfo.TotalPhysicalMemory * (9.31 / 10000000000) * 100) / 100;
            ram.TotalRam = totalRam;

            return ram;
        }
    }
}
