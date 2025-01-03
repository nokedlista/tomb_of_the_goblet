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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            List<Map> maps = new List<Map>();
            StreamReader sr = new StreamReader("mapData.txt");
            List<string> data = new List<string>();
            while (!sr.EndOfStream)
            {
                string line;
                data.Clear();
                do
                {
                    line = sr.ReadLine();
                    data.Add(line);

                } while (line != " ");
                int x = line.Length;
                int y = data.Count / x;
                Map map = new Map(x, y, data);
                maps.Add(map);
            }
            sr.Close();

            label1.Text += maps[0].displayFieldType();
        }
    }
}
