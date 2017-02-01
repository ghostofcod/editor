using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработано на кире© 2017");
        }

        private void создатьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0) //если в текстовом поле что-то есть
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?","Внимание!" , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                //если ответ да, открываем окно сохранения, если нет, то открываем новое окно
                if (result == DialogResult.Yes)
                {
                    сохранитьФайлToolStripMenuItem_Click(sender, e);
                    textBox1.Clear();
                }
                if (result == DialogResult.No)
                {
                    textBox1.Clear(); 
                }

            }
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовый файл|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK) //если нажали сохранить, сохраняем файл
            {
                textBox1.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void сохранитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Безымянный";
            sfd.Filter = "Текстовый файл|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK) //если нажали сохранить, сохраняем файл
            {
                File.WriteAllText(sfd.FileName, textBox1.Text);
            }
        }
    }
}
