using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    public class Hdd : DataStorage
    {
        #region Propeties
        public int DiskSize { get; set; }
        public double Speed { get; set; }
        #endregion
        #region Methods
        public Hdd(string name) : base(name)
        {

        }
        public override string ToString()
        {
            return base.ToString() + $", Disk Size: {DiskSize}, Speed: {Speed}";
        }
        public override void Print()
        {
            Console.WriteLine($"HDD information:\n{this.ToString()}");
        }
        public override void Download(string file)
        {
            Console.WriteLine($"HDD data was downloaded from {file}");
        }
        public override void Upload(string file)
        {
            Console.WriteLine($"HDD data was uploaded to {file}");
        }
        #endregion
    }
}
