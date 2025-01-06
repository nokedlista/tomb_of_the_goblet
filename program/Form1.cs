using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static program.Map;

namespace program
{
    public partial class Form1 : Form
    {
        static List<Map> maps = new List<Map>();

        public Form1()
        {
            InitializeComponent();
            LoadMaps();
            DisplayMap(2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void LoadMaps()
        {
            StreamReader sr = new StreamReader("mapData.txt");
            List<string> data = new List<string>();
            while (!sr.EndOfStream)
            {
                string[] line;
                data.Clear();
                int x = 0;
                int y = 0;
                do
                {
                    line = sr.ReadLine().Split(';');
                    if (line.Length > 1)
                    {
                        x = line.Length;
                        data.AddRange(line);
                        y++;
                    }
                } while (line.Length > 1);
                Map map = new Map(x, y, data);
                maps.Add(map);
            }
            sr.Close();
        }

        private void DisplayMap(int mapNumber)
        {
            for (int i = 0; i < maps[mapNumber - 1].Y; i++)
            {
                for (int j = 0; j < maps[mapNumber - 1].X; j++)
                {
                    PictureBox field = new PictureBox()
                    {
                        Left = j * 30,
                        Top = i * 30,
                        Width = 30,
                        Height = 30,
                        BackColor = maps[mapNumber - 1].getFieldColor(j, i),
                        Parent = MapPlace,
                    };
                }
            }
        }

        private void MapPlace_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
