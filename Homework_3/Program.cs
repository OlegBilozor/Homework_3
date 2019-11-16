using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 200;
            StoragesRepository repository = new StoragesRepository();
            DataStorage dataStorage = null;
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("Choose operation type: add an item - \"Add\", print list - \"Print\", remove items - \"Remove\", find and select an item - \"Find\", change selected item- \"Change\"");
                string operation = Console.ReadLine().ToLower();
                switch(operation)
                {
                    case "add":
                        Console.Write("Enter name for new storage: ");
                        string storageName = Console.ReadLine();
                        Console.WriteLine("What type of data storage you want to add: flash drive (\"flash\"), hdd (\"hdd\") or dvd disk (\"dvd\")?");
                        string storageType = Console.ReadLine().ToLower();                       
                        switch(storageType)
                        {
                            case "flash":
                                repository.AddStorage(new FlashDrive(storageName));
                                break;
                            case "hdd":
                                repository.AddStorage(new Hdd(storageName));
                                break;
                            case "dvd":
                                repository.AddStorage(new Dvd(storageName));
                                break;
                            default:
                                Console.WriteLine("Invalid storage type!");
                                break;
                        }
                        break;
                    case "print":
                        repository.Print();
                        break;
                    case "find":
                        int index;
                        string value;
                        Console.Write("Choose parametr for search: 0 - by name, 1 - by producer, 2 - by price (will be found storage with the same price or lower): ");
                        Int32.TryParse(Console.ReadLine(), out index);
                        Console.Write("Enter parametr value: ");
                        value = Console.ReadLine();
                        dataStorage = repository.Find(index, value);
                        break;
                    case "remove":
                        Console.Write("Choose parametr for removing: 0 - by name, 1 - by producer, 2 - by price (will be removed storages with the same price or lower): ");
                        Int32.TryParse(Console.ReadLine(), out index);
                        Console.Write("Enter parametr value: ");
                        value = Console.ReadLine();
                        repository.Remove(index, value);
                        break;
                    case "change":
                        if (dataStorage == null)
                        {
                            Console.WriteLine("You haven't selected a data storage yet!");
                            break;
                        }
                        else
                        {
                            Console.Write("Chose property to change: 0 - name, 1 - producer, 2 - model, 3 - quantity, 4 - price, 5 - writing speed/disk size/memory amount, 6 - reading speed/speed: ");
                            Int32.TryParse(Console.ReadLine(),out index);
                            Console.Write("Enter new value for property: ");
                            value = Console.ReadLine();
                            repository.Change(index, value, dataStorage);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operation type!");
                        break;

                }
                Console.WriteLine("\n-------------------------------------------------------------------\n");
            }
        }
    }
}
