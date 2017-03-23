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

namespace AT
{
    public partial class Form1 : Form
    {
        int hash;
        string name;
        int value;
        int craftHash1;
        int craftHash2;
        int craftHash3;
        int craftHash4;
        string flavor;
        string effect;
        string texture;

        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // SAVE
        {
            Save();
        }


        private void button2_Click(object sender, EventArgs e) // EXPORT
        {
            Save();
            Export();
        }

        public void Save()
        {
            hash = int.Parse(richTextBox1.Text);
            name = richTextBox2.Text;
            value = int.Parse(richTextBox3.Text);
            craftHash1 = int.Parse(richTextBox4.Text);
            craftHash2 = int.Parse(richTextBox7.Text);
            craftHash3 = int.Parse(richTextBox8.Text);
            craftHash4 = int.Parse(richTextBox9.Text);
            flavor = richTextBox5.Text;
            effect = richTextBox6.Text;
            texture = richTextBox10.Text;
        }

        public void Export()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; 
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = name + ".txt";

                using (StreamWriter output = new StreamWriter(saveFileDialog1.FileName))
                {
                    output.WriteLine(hash);
                    output.WriteLine(name);
                    output.WriteLine(value);
                    output.WriteLine(craftHash1);
                    output.WriteLine(craftHash2);
                    output.WriteLine(craftHash3);
                    output.WriteLine(craftHash4);
                    output.WriteLine(flavor);
                    output.WriteLine(effect);
                    output.WriteLine(texture);
                }
            }
        }

        
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //string name = saveFileDialog1.FileName;
        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
