using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program
{
    internal class Map
    {
        public enum FieldType
        {
            Emty,
            Wall,
            Doted,
            Gate,
            Portal,
            Caracter,
            Spike,
            TimedSpike,
            Shooting,
            Bulet,
        }

        private int x { set; get; }
        private int y { set; get; }
        private PictureBox[,] fieldsDisplay { set; get; }
        private FieldType[,] fields { set; get; }

        public int X
        { 
            get {  return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Map(int x, int y, List<string> data)
        {
            this.x = x;
            this.y = y;
            BuildMap(data);
        }

        private void BuildMap(List<string> data)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    char typeData = data[i * j + j][0];
                    PictureBox disp = new PictureBox();
                    disp.Width = 30;
                    disp.Height = 30;
                    switch (typeData)
                    {
                        case '0':
                            fields[i, j] = FieldType.Emty;
                            disp.BackColor = Color.Black;
                            break;
                        case 'T':
                            fields[i, j] = FieldType.TimedSpike;
                            break;
                        case 'S':
                            fields[i, j] = FieldType.Spike;
                            break;
                        case 'd':
                            fields[i, j] = FieldType.Doted;
                            break;
                        case 'G':
                            fields[i, j] = FieldType.Gate;
                            break;
                        case 'P':
                            fields[i, j] = FieldType.Spike;
                            break;
                        default:
                            fields[i, j] = FieldType.Wall;
                            break;
                    }
                    fieldsDisplay[i, j] = disp;
                }
            }
        }

        public PictureBox DisplayField(int x, int y)
        {
            for (int i = 0; i < this.y; i++)
            {
                for (int j = 0; j < this.x; j++)
                {

                    if (y == i && x == j)
                    {
                        return fieldsDisplay[i, j];
                    }
                }
            }
            return null;
        }
    }
}

