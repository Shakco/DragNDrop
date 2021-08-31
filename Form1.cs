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

namespace SuperProga1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
        }

        void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                label1.Text = "Отпустите мышь";
                e.Effect = DragDropEffects.Copy;
            }
        }

        void panel1_DragLeave(object sender, EventArgs e)
        {
            label1.Text = "Перетащите файлы сюда";
        }

        void panel1_DragDrop(object sender, DragEventArgs e)
        {
            label1.Text = "Перетащите файлы сюда";

            List<string> paths = new List<string>();
            foreach (string obj in (string[])e.Data.GetData(DataFormats.FileDrop))
                if (Directory.Exists(obj))
                    paths.AddRange(Directory.GetFiles(obj, "*.*", SearchOption.AllDirectories));
                else
                    paths.Add(obj);
            label2.Text = string.Join("\r\n", paths);
        }

        void panel1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Укажи файл";
            file.InitialDirectory = "";
            if (file.ShowDialog() == DialogResult.OK)
            {
                label2.Text = file.FileName;
            }
        }

        void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.WhiteSmoke, 2);
            pen.DashPattern = new float[] { 2, 2 };
            e.Graphics.DrawRectangle(pen, 1, 1, panel1.Width - 2, panel1.Height - 2);
        }
    }
}
