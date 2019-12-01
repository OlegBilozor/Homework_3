using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Homework_3
{
    public abstract class DataStorage
    {
        #region Properties
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        #endregion
        #region Methods
        public DataStorage(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Producer: {Producer}, Model: {Model}, Quantity: {Quantity}, Price: {Price}";
        }
        public abstract void Print();

        public abstract void Download(string file);

        public abstract void Upload(string file);

        #endregion

    }
}
