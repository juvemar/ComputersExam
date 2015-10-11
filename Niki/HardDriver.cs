
using System;
using System.Collections.Generic;
using System.Linq;
using C = System.Console;

namespace Computers
{

    public class HardDriver
    {

        private bool isInRaid;
        private int hardDrivesInRaid;
        private SortedDictionary<int, string> info;
        private int capacity;
        private Dictionary<int, string> data;
        private List<HardDriver> hds;

        internal HardDriver() { }
        public bool IsMonochrome { get; set; }

        internal HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;

            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);

            this.hds = new List<HardDriver>();
        }

        internal HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid, List<HardDriver> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;

            this.data = (Dictionary<int, string>)new Dictionary<int, string>(capacity);this.hds = new List<HardDriver>();this.hds = hardDrives;
        }

        public int Capacity
        {
            get
            {
                if (isInRaid)
                {
                    if (!this.hds.Any())
                    {
                        return 0;
                    }
                    return this.hds.First().Capacity;
                }
                else
                {
                    return capacity;
                }
            }
        }
        void SaveData(int addr, string newData)
        {
            if (isInRaid)
            {
                foreach (var hardDrive in this.hds)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.data[addr] = newData;
            }
        }

        string LoadData(int address)
        {
            if (isInRaid)
            {
                if (!this.hds.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }
                return this.hds.First().LoadData(address);
            }
            else
            {
                return this.data[address];
            }
        }

        public void Draw(string a)
        {
            if (this.IsMonochrome)
            {
                C.ForegroundColor = ConsoleColor.Gray;
                C.WriteLine(a);
                C.ResetColor();
            }
            else
            {
                C.ForegroundColor = ConsoleColor.Green;
                C.WriteLine(a);
                C.ResetColor();
            }
        }
    }
}
