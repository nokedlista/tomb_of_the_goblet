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
        static PictureBox[,] fields;
        static bool alive = true;

        public Form1()
        {
            InitializeComponent();
            LoadMaps();
            DisplayMap(1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        static void LoadMaps()
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
            fields = new PictureBox[maps[mapNumber - 1].Y, maps[mapNumber - 1].X];
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
                        BackColor = Color.Black,
                        Parent = MapPlace,
                    };
                    string imgPath = maps[mapNumber - 1].BgImgPath(j, i);
                    if (imgPath != null)
                    {
                        field.BackgroundImage = Image.FromFile(imgPath);
                    }
                    fields[i,j] = field;
                }
            }
        }

        public void changePortal(int _x, int _y)
        {
            fields[_y, _x].BackgroundImage = Image.FromFile("./pics/portal");
        }

        private void MapPlace_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
