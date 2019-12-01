using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


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
                Console.WriteLine("Choose operation type: add an item - \"Add\", print list - \"Print\", remove items - \"Remove\", find and select an item - \"Find\",\n" +
                    "change selected item - \"Change\", write data to xml file - \"Write\", read data from xml file - \"Read\"");
                string operation = Console.ReadLine().ToLower();
                switch(operation)
                {
                    case "add":
                        Console.Write("Enter name for new storage: ");
                        string storageName = Console.ReadLine();
                        Console.Write("Enter producer for new storage: ");
                        string producer = Console.ReadLine();
                        Console.Write("Enter model for new storage: ");
                        string model = Console.ReadLine();
                        Console.Write("Enter quantity for new storage: ");
                        Int32.TryParse(Console.ReadLine(),out int quantity);
                        Console.Write("Enter price for new storage: ");
                        Decimal.TryParse(Console.ReadLine(), out decimal price);
                        Console.WriteLine("What type of data storage you want to add: flash drive (\"flash\"), hdd (\"hdd\") or dvd disk (\"dvd\")?");
                        string storageType = Console.ReadLine().ToLower();                       
                        switch(storageType)
                        {
                            case "flash":
                                Console.Write("Enter memory amount for new flash drive: ");
                                Int32.TryParse(Console.ReadLine(), out int memoryAmount);
                                Console.Write("Enter speed for new flash drive: ");
                                Double.TryParse(Console.ReadLine(), out double speed);
                                repository.AddStorage(new FlashDrive(storageName)
                                {
                                    Producer = producer, Model = model, Quantity = quantity, Price = price,
                                    MemoryAmount = memoryAmount, Speed = speed
                                });
                                break;
                            case "hdd":
                                Console.Write("Enter disk size for new hdd: ");
                                Int32.TryParse(Console.ReadLine(), out int diskSize);
                                Console.Write("Enter speed for new hdd: ");
                                Double.TryParse(Console.ReadLine(), out speed);
                                repository.AddStorage(new Hdd(storageName)
                                {
                                    Producer = producer, Model = model, Quantity = quantity, Price = price,
                                    DiskSize = diskSize, Speed = speed
                                });
                                break;
                            case "dvd":
                                Console.Write("Enter reading speed for new dvd: ");
                                Double.TryParse(Console.ReadLine(), out double readingSpeed);
                                Console.Write("Enter writing speed for new dvd: ");
                                Double.TryParse(Console.ReadLine(), out double writingSpeed);
                                repository.AddStorage(new Dvd(storageName)
                                {
                                    Producer = producer, Model = model, Quantity = quantity, Price = price,
                                    ReadingSpeed = readingSpeed, WritingSpeed = writingSpeed
                                });
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
                    case "write":
                        Console.WriteLine("Choose name for the new file:");
                        string fileName = Console.ReadLine();
                        repository.WriteToXml(fileName);
                        break;
                    case "read":
                        Console.WriteLine("Write name of the file to read information from:");
                        fileName = Console.ReadLine();
                        repository.ReadFromXml(fileName);
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
