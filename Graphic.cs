using System;

namespace ConsoleApp1
{
    class Graphic
    {

        private int Width;
        private int Height;
        private int Frame;
        private float Quality_line;
        public void SetValues(int Width, int Height)
        {
            Frame = 0;
            this.Width = Width;
            this.Height = Height;
        }

        public void Draw(bool[,,] List)
        {
            int bufferSize = Convert.ToInt32(Width * Height * 1);
            using var output = new StreamWriter(
            Console.OpenStandardOutput(), bufferSize: bufferSize);
            Frame++;
            string Text = "";
            for (int i = 0; i < Height - 1; i++)
            {
                for (int j = 0; j < Width - 1; j++)
                {
                    if (List[i, j, 1] == true) Text += "#"+" ";
                    else Text += '.' + " ";
                }
            }
            output.WriteLine(Text + "Frame: " + Frame +  " / bufferSize: " + bufferSize + " / Print \"help\" for help or press \"Enter\" for continue");
        }
    }
}
