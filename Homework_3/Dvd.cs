using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    public class Dvd : DataStorage
    {
        #region Properties
        public double ReadingSpeed { get; set; }
        public double WritingSpeed { get; set; }
        #endregion
        #region Methods
        public Dvd(string name) : base(name)
        {

        }
        public override string ToString()
        {
            return base.ToString() + $", Reading Speed: {ReadingSpeed}, Writing Speed: {WritingSpeed}";
        }
        public override void Print()
        {
            Console.WriteLine($"DVD disk information:\n{this.ToString()}");
        }
        public override void Download(string file)
        {
            Console.WriteLine($"DVD disk data was downloaded from {file}");
        }
        public override void Upload(string file)
        {
            Console.WriteLine($"DVD disk data was uploaded to {file}");
        }
        #endregion
    }
}
