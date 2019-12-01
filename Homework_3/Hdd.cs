using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


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
            try
            {
                var doc = new XmlDocument();
                doc.Load(file);
                var root = doc.CreateElement("hdd");
                doc.DocumentElement?.AppendChild(root);

                var name = doc.CreateElement("name");
                name.InnerText = Name;
                root.AppendChild(name);

                var producer = doc.CreateElement("producer");
                producer.InnerText = Producer;
                root.AppendChild(producer);

                var model = doc.CreateElement("model");
                model.InnerText = Model;
                root.AppendChild(model);

                var quantity = doc.CreateElement("quantity");
                quantity.InnerText = $"{Quantity}";
                root.AppendChild(quantity);

                var price = doc.CreateElement("price");
                price.InnerText = $"{Price}";
                root.AppendChild(price);

                var speed = doc.CreateElement("speed");
                speed.InnerText = $"{Speed}";
                root.AppendChild(speed);

                var diskSize = doc.CreateElement("disk_size");
                diskSize.InnerText = $"{DiskSize}";
                root.AppendChild(diskSize);

                doc.Save(file);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        #endregion
    }
}
