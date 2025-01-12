using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
            Character,
            Spike,
            TimedSpike,
            Shooting,
            Bulet,
            TSpike,
        }

        private int x { set; get; }
        private int y { set; get; }
        private string[,] bgImgPath { set; get; }
        //private Color[,] fieldColors { set; get; } //később lecserélhető a bg img-kre???
        private FieldType[,] fields { set; get; }
        private int[] playerField { set; get; }
        private int numOfPoints { set; get; }
        Player player = new Player();

        public int X
        { 
            get {  return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public string BgImgPath(int _x, int _y)
        {
            return bgImgPath[_y, _x];
        }

        public FieldType getFieldType(int _x, int _y)
        {
            return fields[_y, _x];
        }

        /*public Color getFieldColor(int _x, int _y)
        {
            return fieldColors[_y, _x];
        }

        public void setFieldColor(int _x, int _y, Color color)
        {
            fieldColors[_y,_x] = color;
        }*/

        public int[] PlayerField
        {
            set
            {
                if (value.Length != 2)
                {
                    new Exception("The player field format is invalid (correct format: [x, y])");
                }
                else if (value[0] > x || value[0] < 0 || value[1] > y || value[1] < 0)
                {
                    new Exception("Invalid player position (out of range)");
                }
                else if (fields[value[1],value[0]] == FieldType.Doted || fields[value[1], value[0]] == FieldType.Emty)
                {
                    playerField = value;
                    MapAction(value);
                }
            }
            get { return playerField; }
        }

        public Map(int _x, int _y, List<string> data)
        {
            x = _x;
            y = _y;
            //fieldColors = new Color[y, x];
            fields = new FieldType[y, x];
            bgImgPath = new string[y, x];
            BuildMap(data);
        }

        public void BuildMap(List<string> data)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    char typeData = data[i * x + j][0];
                    string type = data[i * x + j];
                    int a = i * x + j;
                    switch (typeData)
                    {
                        case '0':
                            fields[i, j] = FieldType.Emty;
                            //fieldColors[i, j] = Color.Black;
                            bgImgPath[i, j] = "./pics/" + type + ".png";
                            break;
                        case 'T':
                            fields[i, j] = FieldType.TimedSpike;
                            //fieldColors[i, j] = Color.Blue;
                            bgImgPath[i, j] = "./pics/" + type + ".png";
                            break;
                        case 'S':
                            fields[i, j] = FieldType.Spike;
                            //fieldColors[i, j] = Color.LightBlue;
                            bgImgPath[i, j] = "./pics/" + type + ".png";
                            break;
                        case 'd':
                            fields[i, j] = FieldType.Doted;
                            //fieldColors[i, j] = Color.Yellow;
                            bgImgPath[i, j] = "./pics/dot.png";
                            numOfPoints++;
                            break;
                        case 'G':
                            fields[i, j] = FieldType.Gate;
                            //fieldColors[i, j] = Color.Gray;
                            int[] player = { j, i };
                            bgImgPath[i, j] = "./pics/gate.png";
                            playerField = player;
                            break;
                        case 'P':
                            fields[i, j] = FieldType.Portal;
                            //fieldColors[i, j] = Color.Green;
                            bgImgPath[i, j] = "./pics/portal.png";
                            break;
                        default:
                            try
                            {
                                char typeDataTwo = data[i * x + j][1];
                                if (typeDataTwo == 'T')
                                {
                                    fields[i, j] = FieldType.TimedSpike;
                                    //fieldColors[i, j] = Color.Blue;
                                    bgImgPath[i, j] = "./pics/" + type + ".png";
                                }
                                else if (typeDataTwo == 'S')
                                {
                                    fields[i, j] = FieldType.Spike;
                                    //fieldColors[i, j] = Color.LightBlue;
                                    bgImgPath[i, j] = "./pics/" + type + ".png";
                                }
                            }
                            catch (Exception)
                            {
                                fields[i, j] = FieldType.Wall;
                                bgImgPath[i, j] = "./pics/" + type + ".png";
                            }
                            break;
                    }
                }
            }
        }

        private void MapAction(int[] playerField)
        {
            int playerX = playerField[0];
            int playerY = playerField[1];
            bool activate = fields[playerY + 1, playerX] == FieldType.TimedSpike ||
                            fields[playerY, playerX + 1] == FieldType.TimedSpike ||
                            fields[playerY - 1, playerX] == FieldType.TimedSpike ||
                            fields[playerY, playerX - 1] == FieldType.TimedSpike;
            if (fields[playerY, playerX] == FieldType.Spike)
            {
                player.minusLife();
            }
            if (fields[playerY, playerX] == FieldType.Doted) 
            {
                numOfPoints--;
                fields[playerY, playerX] = FieldType.Emty;
                if (numOfPoints < 0 || fields[playerY, playerX] == FieldType.Gate)
                {
                    //Törlés, új map ???
                }
            }
            if (activate) //ide valószínűleg szálkezelés kell majd. kihagyni az időzített tüskéket?
            {
                Thread.Sleep(500);
                fields[playerY, playerX] = FieldType.TSpike;
                Thread.Sleep(1000);
                fields[playerY, playerX] = FieldType.Emty;
            }
        }
    }
}

