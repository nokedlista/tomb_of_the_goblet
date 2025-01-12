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
        public Form1()
        {
            InitializeComponent();
            LoadMaps();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void LoadMaps()
        {
            List<Map> maps = new List<Map>();
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
                    x = (line.Length > 1) ? line.Length : x;
                    data.AddRange(line);
                    y++;
                } while (line.Length > 1);
                Map map = new Map(x, y - 1, data);
                maps.Add(map);
            }
            sr.Close();

            for (int i = 0; i < maps[0].Y; i++)
            {
                for (int j = 0; j < maps[0].X; j++)
                {
                    maps[0].DisplayField(j, i);
                }
            }
        }
    }
}
