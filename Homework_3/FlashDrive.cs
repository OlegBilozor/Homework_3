using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    public class FlashDrive : DataStorage
    {
        #region Properties
        public int MemoryAmount { get; set; }
        public double Speed { get; set; }
        #endregion

        #region Methods
        public FlashDrive(string name) : base(name)
        {

        }
        public override string ToString()
        {
            return base.ToString() + $", Memory Amount: {MemoryAmount}, Speed: {Speed}";
        }
        public override void Print()
        {
            Console.WriteLine($"Flash drive information:\n{this.ToString()}");
        }
        public override void Download(string file)
        {
            Console.WriteLine($"Flash drive data was downloaded from {file}");
        }
        public override void Upload(string file)
        {
            Console.WriteLine($"Flash drive data was uploaded to {file}");
        }
        #endregion
    }
}
