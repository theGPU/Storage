using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    class DVD : Storage
    {
        private float oneSideSize = 1468006;
        private float speedReadKb = 1352;
        private float speedWriteKb = 1352;
        public DVD(string name, string model, float busyKb, bool duplex = false, bool twoLayer = false) : base(name, model, StorageType.DVD)
        {
            TotalKb = duplex ? oneSideSize * 2 : oneSideSize;
            TotalKb = twoLayer ? TotalKb * 2 : TotalKb;

            BusyKb = busyKb;
            SpeedReadKb = speedReadKb;
            SpeedWriteKb = speedWriteKb;
        }
    }
}
