using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public enum StorageType
    {
        Flash = 0,
        DVD = 1,
        HDD = 2,
    }

    public abstract class Storage
    {
        public StorageType Type { get; private set; } = StorageType.HDD;
        public string Name { get; private set; } = string.Empty;
        public string Model { get; private set; } = string.Empty;
        public float TotalKb { get; set; } = 0;
        public float BusyKb { get; set; } = 0;
        public float SpeedReadKb { get; set; } = 0;
        public float SpeedWriteKb { get; set; } = 0;
        public Storage(string name, string model, StorageType type)
        {
            Name = name;
            Model = model;
            Type = type;
        }
        public string GetInfo()
        {
            return $"[{Type}]: {Name} - {Model}\n" +
                $"\tTotal, mb: {TotalKb / 1024}\n" +
                $"\tBusy, mb: {BusyKb / 1024}\n" +
                $"\tSpeed read, mb/s: {SpeedReadKb / 1024}\n" +
                $"\tSpeed write, mb/s: {SpeedWriteKb / 1024}\n";
        }
        public static bool Copy(Storage source, Storage destination)
        {
            float freeKb = destination.TotalKb - destination.BusyKb;
            if (freeKb < source.BusyKb)
            {
                return false;
            }

            destination.BusyKb += source.BusyKb;

            return true;
        }
    }

    public static class Utils
    {
        public static bool Copy(this Storage source, Storage destination) => Copy(source, destination);
    }
}
