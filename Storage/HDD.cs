using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    class HDD : Storage
    {
        public HDD(string name, string model, float busyKb, int sectors, float sectorKb, float usbReadSpeed, float usbWriteSpeed) : base(name, model, StorageType.HDD)
        {
            BusyKb = busyKb;
            TotalKb = sectors * sectorKb;
            SpeedReadKb = usbReadSpeed;
            SpeedWriteKb = usbWriteSpeed;
        }
    }
}
