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

namespace DatoveSoubory00
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("celaCisla.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter br = new BinaryWriter(fs);
            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                int cislo = int.Parse(textBox1.Lines[i]);
                br.Write(cislo);
            }
            fs.Close();
            br.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FileStream fs = new FileStream("celaCisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            while(fs.Position < fs.Length)
            {
                int cislo = br.ReadInt32();
                listBox1.Items.Add(cislo);
            }
            br.Close();
            fs.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //všechna lichá čísla v souboru opravte na sudá vynásobením dvěma.
            FileStream fs = new FileStream("celaCisla.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                 int pos = (int) br.BaseStream.Position; 

                int x = br.ReadInt32();  //V souboru jsme za prectenym cislem
                if(x%2 != 0)
                {
                    x *= 2;

                    // bw.BaseStream.Position -= 4;
                    //bw.BaseStream.Position -= sizeof(Int32);
                    // bw.Seek(-4, SeekOrigin.Current);
                    //bw.Seek(-sizeof(Int32), SeekOrigin.Current);
                    bw.Seek(pos, SeekOrigin.Begin); //+int pos


                    bw.Write(x);
                }
            }
            br.Close();
            fs.Close();
            bw.Close();
        }
    }
}
