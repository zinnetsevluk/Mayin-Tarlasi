using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mayintarlası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int saniye = 0,dakika = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Interval = 1000;
            timer1.Start();
            if (saniye < 59) saniye++;

            else
            {

                saniye = 0;

                if (dakika < 59)
                {

                    dakika++;

                }

                else
                {

                    dakika = 0;

                }

            }
            label3.Text = dakika + ":" + saniye;
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void başlangıçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MayinTarlası oyun = new MayinTarlası(9,9,10);
         
            oyun.alan = this;
             oyun.ButonOlustur();
            timer1_Tick(sender, e);
            etkisizOlsun();
           
           
          
         
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ortaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MayinTarlası oyun = new MayinTarlası(16, 16, 40);
            oyun.alan = this;
            oyun.ButonOlustur();
            timer1_Tick(sender, e);
            etkisizOlsun();
       
         
        }

        private void zorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MayinTarlası oyun = new MayinTarlası(16,30, 99);
            oyun.alan = this;
            oyun.ButonOlustur();
            timer1_Tick(sender, e);
            etkisizOlsun();
           
           
            
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MayinTarlası oyun = new MayinTarlası();
            timer1.Stop();
            saniye = 0;
            dakika = 0;
            

        }



        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://windows.microsoft.com/tr-tr/windows/minesweeper-how-to#1TC=windows-7");
        }

        private void YeniOyunStripMenuItem_Click(object sender, EventArgs e)
        {
            MayinTarlası oyun = new MayinTarlası();
            timer1.Stop();
            saniye = 0;
            dakika = 0;
        }

        private void kendinYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1.ActiveForm.Width = 300;
            //Form1.ActiveForm.Height = 200;
            panel1.Controls.Clear();
            panel1.Hide();
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            numericUpDown1.Visible = true;
            numericUpDown2.Visible = true;
            numericUpDown3.Visible = true;
            button1.Visible = true;
            saniye = 0;
            dakika = 0;
            label3.Text = null;
            label5.Text = null;


        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            etkisizOlsun();
            int sayi1=Convert.ToInt32(numericUpDown1.Value);
            int sayi2=Convert.ToInt32(numericUpDown2.Value);
            int sayi3=Convert.ToInt32(numericUpDown3.Value);
            MayinTarlası oyun = new MayinTarlası(sayi1,sayi2,sayi3);
            oyun.alan = this;
            oyun.ButonOlustur();
            timer1_Tick(sender, e);
         
           
        }
        private void etkisizOlsun()
        {

            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown3.Visible = false;
            button1.Visible = false;
            panel1.Visible = true;
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }  
    }
}
