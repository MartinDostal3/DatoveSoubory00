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

        private void button6_Click(object sender, EventArgs e)
        {
            //všechna zaporna cisla vynasob -1
           
            FileStream fs = new FileStream("realnaCisla.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
               int pos = (int)br.BaseStream.Position;
                double x = br.ReadDouble();  //V souboru jsme za prectenym cislem
                if (x < 0)
                {
                  
                    x *= -1;
                    //bw.BaseStream.Position -= sizeof(Double);
                    //bw.BaseStream.Position -= 8;
                    //bw.Seek(-8, SeekOrigin.Current);
                    //bw.Seek(-sizeof(Double), SeekOrigin.Current);
                    bw.Seek(pos, SeekOrigin.Begin);

                    bw.Write(x);
                    
                }
            }
            br.Close();
            fs.Close();
            bw.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int n = int.Parse(textBox2.Text);
            FileStream fs = new FileStream("realnaCisla.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter br = new BinaryWriter(fs);
            for (int i = 0; i < n; i++)
            {
                double nahodne = -20 + (21 - (-20)) * random.NextDouble() ;
                br.Write(nahodne);
            }
            fs.Close();
            br.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            FileStream fs = new FileStream("realnaCisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            while (fs.Position < fs.Length)
            {
                double cislo = br.ReadDouble();
                listBox2.Items.Add(cislo);
            }
            br.Close();
            fs.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("osoby.dat", FileMode.Create, FileAccess.Write);

            BinaryWriter bw = new BinaryWriter(fs);
          

         

            bw.Write("Petr");
            bw.Write(78);
            bw.Write("Pavel");
            bw.Write(80);

            bw.Write("Patrik");
            bw.Write(36);
            fs.Close();
            listBox3.Items.Clear();
            fs = new FileStream("osoby.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                string jmeno = br.ReadString();
                int hmotnost = br.ReadInt32();
                listBox3.Items.Add(jmeno + " hmotnost: " + hmotnost + " kg");


            }
            fs.Close();







        }
    }
}
