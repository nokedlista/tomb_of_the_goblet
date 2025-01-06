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
        private Color[,] fieldColors { set; get; } //később lecserélhető a bg img-kre???
        private FieldType[,] fields { set; get; }

        public int X
        { 
            get {  return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public FieldType getFieldType(int _x, int _y)
        {
            return fields[_y, _x];
        }

        public Color getFieldColor(int _x, int _y)
        {
            return fieldColors[_y, _x];
        }

        public void setFieldColor(int _x, int _y, Color color)
        {
            fieldColors[_y,_x] = color;
        }

        public Map(int _x, int _y, List<string> data)
        {
            x = _x;
            y = _y;
            fieldColors = new Color[y, x];
            fields = new FieldType[y, x];
            BuildMap(data);
        }

        private void BuildMap(List<string> data)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    char typeData = data[i * x + j][0];
                    int a = i * x + j;
                    switch (typeData)
                    {
                        case '0':
                            fields[i, j] = FieldType.Emty;
                            fieldColors[i, j] = Color.Black;
                            break;
                        case 'T':
                            fields[i, j] = FieldType.TimedSpike;
                            fieldColors[i, j] = Color.Blue;
                            break;
                        case 'S':
                            fields[i, j] = FieldType.Spike;
                            fieldColors[i, j] = Color.LightBlue;
                            break;
                        case 'd':
                            fields[i, j] = FieldType.Doted;
                            fieldColors[i, j] = Color.Yellow;
                            break;
                        case 'G':
                            fields[i, j] = FieldType.Gate;
                            fieldColors[i, j] = Color.Gray;
                            break;
                        case 'P':
                            fields[i, j] = FieldType.Spike;
                            fieldColors[i, j] = Color.Green;
                            break;
                        default:
                            try
                            {
                                char typeDataTwo = data[i * x + j][1];
                                if (typeDataTwo == 'T')
                                {
                                    fields[i, j] = FieldType.TimedSpike;
                                    fieldColors[i, j] = Color.Blue;
                                }
                                else if (typeDataTwo == 'S')
                                {
                                    fields[i, j] = FieldType.Spike;
                                    fieldColors[i, j] = Color.LightBlue;
                                }
                            }
                            catch (Exception)
                            {
                                fields[i, j] = FieldType.Wall;
                            }
                            break;
                    }
                }
            }
        }
    }
}

