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


        private int x { set; get; }
        private int y { set; get; }
        private int end { set; get; }
        private List<string> data { set; get; }
        private Field[,] fields { set; get; }
        //private pictureBox[,] fieldsDisplay { set; get; } 

        public Map(int x, int y, List<string> data)
        {
            this.x = x;
            this.y = y;
            this.data = data;
            BuildMap();
        }

        private void BuildMap() 
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Field field = new Field(data[i * j + j]);
                }
            }
        }

        public string displayFieldType()
        {
            List<string> display = new List<string>();
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                for (int j = 0; j < fields.GetLength(1); j++)
                {
                   display.Add(fields[i,j].Type + ", ");
                }
                display.Add("\n");
            }

            return display.ToString();
        }
    }

    internal class Field
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

        /* public enum WallGrafic
        {
            Top,
            Bottom,
            Right,
            Left,
            TopRight,
            TopLeft,
            BottomRight,
            BottomLeft,
            RightLeft,
            TopBottom,
            TopRightLeft,
            TopBottomLeft,
            TopBottomRight,
            BottomRightLeft,
            TopBottomLeftRight,
        }

        public enum SpikeGrafic
        {
            Wall1,
            Wall2,
            Wall3,
            Wall4,
            Wall9Left,
            Wall5Top,
        }

        public enum TimedSpikeGrafic
        {
            Wall7,
            Wall15,
            Wall13Bottom,
            Wall8Bottom,
        } */

        private FieldType type;

        public FieldType Type
        {
            get { return type; }
            set  //only doted fields are able to change to emty
            {
                if (type == FieldType.Doted)
                {
                    type = FieldType.Emty;
                }
                else
                {
                    throw new Exception("A mezõ típusa nem módosítható");
                }
            }
        }
        public Field(string typeData)
        {
            switch (typeData[0])
            {
                case '0': type = FieldType.Emty; break;
                case 'T': type = FieldType.TimedSpike; break;
                case 'S': type = FieldType.Spike; break;
                case 'd': type = FieldType.Doted; break;
                case 'G': type = FieldType.Gate; break;
                case 'P': type = FieldType.Spike; break;
                default: type = FieldType.Wall; break;
            }
        }
    }
}
