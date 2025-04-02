using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace WpfApp5
{
    public class FileManager
    {
        private string fileName;

        public FileManager(string fileName)
        {
            this.fileName = fileName;
        }


        public List<Cars> all = new List<Cars>();

        public List<Cars> ReadFile()
        {
            try
            {
                foreach (string line in File.ReadAllLines("data.txt", Encoding.UTF8).Skip(1))
                {
                    all.Add(new Cars(line));
                }

                //File.ReadAllLines("data.txt", Encoding.UTF8).ToList().ForEach(line => all.Add(new Cars(line)));
                /*all.Remove(all.Last());
                all.RemoveAt(all.Count - 1);*/
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return all;
        }

        public void WriteOneLine(Cars oneCar)
        {
            using (StreamWriter write = new StreamWriter(fileName, true ,Encoding.UTF8))   //using-nál nem kell bezárni külön
            {
                write.Write($"\n{oneCar.Manufacturer};{oneCar.Model};{oneCar.Power};{oneCar.Weight}");
            }
        }

        public void Edit(List<Cars> list)
        {
            using (StreamWriter edit = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                edit.WriteLine("cs");
                for (int i = 0; i < list.Count; i++)
                {
                    edit.WriteLine($"{all[i].Manufacturer};{all[i].Model};{all[i].Power};{all[i].Weight}");
                }
                edit.WriteLine($"{all.Last().Manufacturer};{all.Last().Model};{all.Last().Power};{all.Last().Weight}");
            }
            ReadFile();
        }
    }
}
