using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


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
            try
            {
                var doc = new XmlDocument();
                doc.Load(file);
                var root = doc.CreateElement("dvd");
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

                var readingSpeed = doc.CreateElement("reading_speed");
                readingSpeed.InnerText = $"{ReadingSpeed}";
                root.AppendChild(readingSpeed);

                var writingSpeed = doc.CreateElement("writing_speed");
                writingSpeed.InnerText = $"{WritingSpeed}";
                root.AppendChild(writingSpeed);

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
