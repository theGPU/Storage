using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    class Program
    {
        private static List<Storage> storages = new List<Storage>();
        static void Main(string[] args)
        {
            storages.Add(new Flash("SanDisk Cruzer Fit", "SDCZ33-016G-G35", 15414067, 1264025, 29900, 9011));
            storages.Add(new HDD("Toshiba Canvio READY", "HDTP210EK3AA", 12000, 64, 16777216, 50331648, 50331648));
            storages.Add(new DVD("Mirex", "af", 0));

            while (true)
            {
                Console.Clear();
                PrintMenu();
                Console.Write("Enter: ");
                SelectMenu(Console.ReadKey().KeyChar);

                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Select an action\n" +
                "1 - Show the amount of memory on all storages\n" +
                "2 - Copying information from storage to storage\n" +
                "3 - Calculating the number of storage needed for transfer");
        }
        private static void PrintStorages()
        {
            int i = 1;
            foreach (var storage in storages)
            {
                Console.WriteLine($"{i}\r{storage.GetInfo()}");
                i++;
            }
        }
        private static void GetMemoryStatistic()
        {
            float totalKb = 0;
            float busyKb = 0;
            foreach (var storage in storages)
            {
                totalKb += storage.TotalKb;
                busyKb += storage.BusyKb;
            }
            Console.WriteLine($"Total space on all storage: {totalKb / 1024}/mb, busy {busyKb / 1024}/mb");
        }
        private static void SelectMenu(char number)
        {
            Console.Clear();
            switch (number)
            {
                case '1':
                    GetMemoryStatistic();
                    break;
                case '2':
                    PrintStorages();
                    Console.Write("Enter copy source: ");
                    var source = storages[int.Parse(Console.ReadLine()) - 1];
                    PrintStorages();
                    Console.Write("Enter copy destination: ");
                    var destination = storages[int.Parse(Console.ReadLine()) - 1];

                    var result = source.Copy(destination);
                    if (result == true)
                    {
                        float speedWriteKb = source.SpeedReadKb;
                        if (destination.SpeedWriteKb < source.SpeedReadKb)
                            speedWriteKb = destination.SpeedWriteKb;
                        Console.WriteLine($"Successful copying, with speed: {source.BusyKb / speedWriteKb / 1024}mb/s");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient copy space");
                    }
                    break;
                case '3':
                    Console.Write("How much information do you need to transfer?, kb: ");
                    float transferKb = float.Parse(Console.ReadLine());
                    Console.WriteLine("For this you will need:");
                    foreach (var storage in storages)
                        Console.WriteLine($"{storage.Name} ({storage.Model}) - {Math.Ceiling(transferKb / storage.TotalKb)}");

                    break;
                default:
                    Console.WriteLine("Unknown menu item");
                    break;
            }
        }
    }
}
