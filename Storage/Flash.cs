using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Flash : Storage
    {
        public Flash(string name, string model, float totalKb, float busyKb, float speedReadKb, float speedWriteKb) : base(name, model, StorageType.Flash)
        {
            TotalKb = totalKb;
            BusyKb = busyKb;
            SpeedReadKb = speedReadKb;
            SpeedWriteKb = speedWriteKb;
        }
    }
}
