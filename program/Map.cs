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
            Emty = 0,
            //simple walls:
            WT = 1,
            WB = 2,
            WR = 3,
            WL = 4,
            WLT = 5,
            WRT = 6,
            WRB = 7;
            WLB = 8;
            WLR = 9;
            WTB = 10,
            WLRT = 11,
            WLTB = 12,
            WRTB = 13,
            WLRB = 14,
            WLRTB = 15,
            Doted = 16,
            Portal = 17,
            Gate = 18,
            Caracter = 19,
            Spike = 20,
            TimedSpike = 21,
        }

        private int x { set; get; }
        private int y { set; get; }
        private int end { set; get; }

        public Map(int x, int y, int end)
        {
            this.x = x;
            this.y = y;
            this.end = end;
        }
    }
}
