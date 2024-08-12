using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class ReadingFiles
    {
        public int Width;
        public int Height;
        public void SetValues(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
        public void Save(bool[,,] list)
        {
            string Text = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (list[i, j, 1] == true) Text += "1";
                    else Text += "0";
                }
                Text += "\n";
            }
            string name = Convert.ToString(DateTime.Now);
            name = "Life_" + name.Replace(" ", "").Replace(".", "").Replace(",", "").Replace(":", "");
            Console.WriteLine("file name is \"" + name + ".txt\". Good luck finding it LOL");
            using (FileStream stream = new FileStream(name + ".txt", FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(Text);
                stream.Write(array, 0, array.Length);
            }
        }
        public bool[,,] Reading(bool[,,] list,string phrase) 
        {
            try
            {
                using (FileStream stream1 = File.OpenRead(phrase + ".txt"))

                {
                    Width = Width + 1;
                    byte[] array = new byte[stream1.Length];
                    stream1.Read(array, 0, array.Length);
                    string Text = Encoding.Default.GetString(array);
                    Text.Replace("\n", "");
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            if (Text[j + i * Width] == '0' || Text[j + i * Width] == '1')
                            {

                                list[i, j, 1] = Convert.ToBoolean(Convert.ToInt32(Text[j + i * Width]) - '0');
                                list[i, j, 0] = Convert.ToBoolean(Convert.ToInt32(Text[j + i * Width]) - '0');
                            }
                        }
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("the address is incorrect");
            }
            return list;
        }
    }
}
