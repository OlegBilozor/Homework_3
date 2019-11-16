using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    public class StoragesRepository
    {
        private List<DataStorage> _storages;        
        public StoragesRepository()
        {
            _storages = new List<DataStorage>();            
        }
        public void AddStorage(DataStorage storage) //Method for adding Data Storage
        {
            _storages.Add(storage);
            Console.WriteLine($"Storage {storage.Name} was added");
        }
        public void Print() //Method for printing all items
        {
            if(_storages.Count==0) //if list is empty
                Console.WriteLine("There are no items!");
            else //if list contains some items
            _storages.ForEach(s => s.Print());
        }
        public DataStorage Find(int index, string value) //Method to find a specific Data Storage. Finds only first appropriate item
        {
            DataStorage storage = null;
            switch (index)
            {
                case 0: //if we want to find by Name
                    storage = _storages.Find(s => s.Name == value);                   
                    break;
                case 1: //if we want to find by Producer
                    storage = _storages.Find(s => s.Producer == value);
                    break;
                case 2: //if we want to find by Price
                    decimal price;
                    try
                    {
                        price = Decimal.Parse(value);
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Invalid value");
                        break;
                    }
                    storage = _storages.Find(s=>s.Price <= price);
                    break;
                default:
                    Console.WriteLine("Invalid index!");
                    break;                    
            }
            if (storage == null)            
                Console.WriteLine("There is no such item!");
            else
                Console.WriteLine($"Was founded item - {storage}");
                return storage; //output can be used for method Change().
        }
        public void Remove(int index, string value) //Method for removing Data Storages form the list. Removes all appropriate items
        {
            int counter = 0;
            switch(index)
            {
                case 0: //if we want to remove by Name
                    _storages.ForEach(s =>
                    {
                        if(s.Name==value)
                        {
                            _storages.Remove(s);
                            counter++;
                        }
                    });
                    break;
                case 1: //if we want to remove by Producer
                    _storages.ForEach(s =>
                    {
                        if (s.Producer == value)
                        {
                            _storages.Remove(s);
                            counter++;
                        }
                    });
                    break;
                case 2: //if we want to remove by Price
                    decimal price;
                    try
                    {
                        price = Decimal.Parse(value);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid value");
                        break;
                    }
                    _storages.ForEach(s =>
                    {
                        if (s.Price<=price)
                        {
                            _storages.Remove(s);
                            counter++;
                        }
                    });
                    break;
                default: //if index is invalid
                    Console.WriteLine("Invalid index!");
                    break;
            }
            if(counter==0) //if no items were found and removed
                Console.WriteLine("There are no such items!");
            else //if some items were find and removed
                Console.WriteLine($"{counter} item/-s was/were removed");
        }
        public void Change(int index, string value, DataStorage storage) //Method for changing some property of some Data Storage
        {
            if(!(_storages.Contains(storage)))
            {
                Console.WriteLine("Item doesn't belong to list");
                return;
            }
            else
            {
                switch(index)
                {
                    case 0: //if we want to change Name
                        storage.Name = value;
                        break;
                    case 1: //if we want to change Producer
                        storage.Producer = value;
                        break;
                    case 2: //if we want to change Model
                        storage.Model = value;
                        break;
                    case 3: //if we want to change Quantity
                        int quantity;
                        try
                        {
                            quantity = Int32.Parse(value);
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Invalid value!");
                            break;
                        }
                        storage.Quantity = quantity;
                        break;
                    case 4: //if we want to change price
                        decimal price;
                        try
                        {
                            price = Decimal.Parse(value);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid value!");
                            break;
                        }
                        storage.Price = price;
                        break;
                    case 5: //if we want to change the first unique class property
                        if(storage is Dvd) //if object is Dvd we changing the Writing Speed
                        {
                            double writingSpeed;
                            try
                            {
                                writingSpeed = Double.Parse(value);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid value!");
                                break;
                            }
                            Dvd dvd = storage as Dvd;
                            dvd.WritingSpeed = writingSpeed;
                        }
                        else if(storage is Hdd) //if object is Hdd we changing the Disk Size
                        {
                            int diskSize;
                            try
                            {
                                diskSize = Int32.Parse(value);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid value!");
                                break;
                            }
                            Hdd hdd = storage as Hdd;
                            hdd.DiskSize = diskSize;
                        }
                        else //if object is Flash Drive we changing the Memory Amount
                        {
                            int memoryAmount;
                            try
                            {
                                memoryAmount = Int32.Parse(value);
                            }
                            catch(Exception)
                            {
                                Console.WriteLine("Invalid value!");
                                break;
                            }
                            FlashDrive flashDrive = storage as FlashDrive;
                            flashDrive.MemoryAmount = memoryAmount;
                        }
                        break;
                    case 6: //if we want to change the second unique class property
                        double num; //one variable, cause second unqie class property anyway has type double
                        try
                        {
                            num = double.Parse(value);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid value!");
                            break;
                        }
                        if(storage is Dvd) //if object is Dvd we changing the Reading Speed
                        {
                            Dvd dvd = storage as Dvd;
                            dvd.ReadingSpeed = num;
                        }
                        else if(storage is Hdd) //if object is Hdd we changing the Speed
                        {
                            Hdd hdd = storage as Hdd;
                            hdd.Speed = num;
                        }
                        else //if object is Flash Drive we changing the Speed
                        {
                            FlashDrive flashDrive = storage as FlashDrive;
                            flashDrive.Speed = num;
                        }
                        break;
                    default: //if index is invalid
                        Console.WriteLine("Invalid index!");
                        break;
                }
            }
        }
    }
}
