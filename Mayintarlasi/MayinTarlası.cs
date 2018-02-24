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
    class MayinTarlası
    {
         int[,] bayrak; 
         Button [,] kareler;
         public Form1 alan;
         int satirSayisi, sutunSayisi, mayinSayisi;
         int[,] mayinlar;
         int[,] sayi;
         int kalanKareSayisi = 0;
         int kalanbayrak;
         
          
        public MayinTarlası(int a, int b, int c)
        {
            this.satirSayisi = a;
            this.sutunSayisi = b;
            this.mayinSayisi = c;
            kalanbayrak = mayinSayisi;
            kareler = new Button[satirSayisi, sutunSayisi];
        }
        public MayinTarlası()
        {

        }
    
        public void ButonOlustur()
        {
            bayrak = new int[satirSayisi, sutunSayisi];
            mayinlar= new int[satirSayisi, sutunSayisi];
            sayi = new int[satirSayisi, sutunSayisi];
             //temizle();
            alan.panel1.Controls.Clear();
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    kareler[i, j] = new Button();
                    alan.panel1.Height = satirSayisi*30;
                    alan.panel1.Width = sutunSayisi*30 ;
                    kareler[i, j].TabIndex = i;
                    kareler[i, j].Width = 30;
                    kareler[i, j].Height = 30;
                    kareler[i, j].Name = ("satir" + i + "sütun" + j);
                    kareler[i, j].BackColor = Color.CornflowerBlue;
                    kareler[i, j].FlatStyle = FlatStyle.Standard;
                    kareler[i, j].Location = new Point(j * 30, i * 30);
                    mayinlar[i, j] = 1;
                    sayi[i, j] = 0;
                    bayrak[i, j] =0;
                    alan.label5.Text = kalanbayrak.ToString();
                    //kareler[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    kareler[i, j].MouseDown += new MouseEventHandler(sagtıkla);
                    kareler[i, j].Click += new EventHandler(MayinTarlası_Click);
                    alan.panel1.Controls.Add(kareler[i, j]);

                }
            }
          
            MayinDagıt();
            sayilariYerlestir();
           
    
            
        }
        public void MayinDagıt()
        { 
                 Random r = new Random();


                 for (int i = 0; i < mayinSayisi; i++)
                 {
                     int x, y;
                     x = r.Next(satirSayisi);
                     y = r.Next(sutunSayisi);

                     while (Mayın_Kontrol(x, y))
                     {
                         x = r.Next(satirSayisi);
                         y = r.Next(sutunSayisi);

                     }
                     mayinlar[x, y] = 0;
                 }
        
        }

       public void MayinTarlası_Click(object sender, EventArgs e)
        {

            Button tıklanan = (Button)sender;
            int gelen_i=1;
            int gelen_j = 1; 
            for (int i = 0; i <satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (tıklanan == kareler[i, j])
                    {

                        gelen_i = i;
                        gelen_j = j;
                    }
                }
            }


            if (mayinlar[gelen_i, gelen_j] == 0 && bayrak[gelen_i, gelen_j] == 0)
                    {
                        for (int i = 0; i < satirSayisi; i++)
                        {
                            for (int j = 0; j < sutunSayisi; j++)
                            {
                                if (mayinlar[i, j] == 0)
                                {
                                 
                                    kareler[gelen_i, gelen_j].Enabled = false;
                                    kareler[i, j].BackgroundImage = Mayintarlası.Properties.Resources.bomb;
                                    kareler[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                    alan.timer1.Stop();
                                   
                                   
                                }
                            }
                        }
                        puanHesapla();
                        DialogResult cevap = MessageBox.Show("Süre : "+ alan.dakika+"."+alan.saniye+"\nPuan :"+alan.label6.Text+"\nOyunu Kaybettiniz. :( Tekrar oynamak istermisiniz?", "Başarısız",MessageBoxButtons.YesNo);
                        kalanbayrak = mayinSayisi;          
                        if (cevap == DialogResult.Yes)
                        {
                           // ButonOlustur();
                            //alan.timer1.Start();
                            alan.panel1.Controls.Clear();
                            alan.saniye = 0;
                            alan.dakika = 0;
                            alan.label3.Text = null;
                            alan.label5.Text = null;
                     
                        }

                        else if (cevap == DialogResult.No)
                        {
                            Application.Exit(); 
                        }
                    }
            else if (mayinlar[gelen_i, gelen_j] == -1 && bayrak[gelen_i, gelen_j] == 0)
                    {
                        kareler[gelen_i, gelen_j].Enabled = false;
                        kareler[gelen_i, gelen_j].BackColor = Color.Pink;
                        kareler[gelen_i, gelen_j].Text = sayi[gelen_i, gelen_j].ToString();
                        mayinlar[gelen_i, gelen_j] = 4;
                    }
            else if (bayrak[gelen_i, gelen_j] == 0)
                    {
                        bosAc(gelen_i, gelen_j);
                    }
                    oyunBitti();

        }

       public void oyunBitti()
       {
           //kalanKareSayisi = 0;
           for (int i = 0; i < satirSayisi; i++)
           {
               for (int j = 0; j < sutunSayisi; j++)
               {
                   if (kareler[i,j].Enabled==true)
                   {
                       kalanKareSayisi++;
                   }
               }
               
           }
           if (kalanKareSayisi == mayinSayisi)
           {
               alan.timer1.Stop();
               puanHesapla();
               alan.label6.Text = "100";
               DialogResult cevap = MessageBox.Show("Süre : " + alan.dakika + ":" + alan.saniye + "\nPuan :" + alan.label6.Text + "\nOyunu Kazandınız. :) Tekrar oynamak istermisiniz?", "Başarılı", MessageBoxButtons.YesNo);
               kalanbayrak = mayinSayisi;

               if (cevap == DialogResult.Yes)
               {
                   alan.panel1.Controls.Clear();
                   alan.saniye = 0;
                   alan.dakika = 0;
                   alan.label3.Text = null;
                   alan.label5.Text = null;


               }
               else if (cevap == DialogResult.No)
               {
                   Application.Exit();
               }
           }
           else
           {
               kalanKareSayisi = 0;
           
           }
       }
        public void sayilariYerlestir()
        {
             for (int i = 0; i <satirSayisi; i++)
             for (int j = 0; j < sutunSayisi; j++)
                {
                    if (mayinlar[i, j] != 0)
                    {
                      
                        if (j % sutunSayisi != 0)//ilk sutunda değilse
                            if (mayinlar[i, j - 1] == 0)//sol
                            {
                                sayi[i, j]++;
                              
                            }

                        if ((j + 1) % sutunSayisi!= 0) // son sutunda değilse
                            if (mayinlar[i, j + 1] == 0)//sağ
                            {
                                sayi[i, j ]++;
                              
                            }
                       
                        if (i % satirSayisi != 0)//ilk satırda değilse
                            if (mayinlar[i - 1, j] == 0)//üst
                            {
                                sayi[i , j]++;
                              
                            }
                       
                        if (i < satirSayisi - 1)// son satırda değilse
                            if (mayinlar[i + 1, j] == 0)//alt
                            {
                                sayi[i , j]++;
                              
                            }
                      
                        if ((i % satirSayisi != 0) && (j % sutunSayisi!= 0)) //ilk satır ve ilk sutunda değilse
                            if (mayinlar[i - 1, j - 1] == 0)//solüst
                            {
                                sayi[i, j ]++;
                              
                            }
                        if ((i % satirSayisi != 0) && ((j + 1) % sutunSayisi != 0)) //ilk satır ve son sutunda değilse
                            if (mayinlar[i - 1, j + 1] == 0)//sağüst
                            {
                                sayi[i , j ]++;
                              
                            }
                        if ((j % sutunSayisi != 0) && (i < satirSayisi - 1)) //ilk sutun ve son satırda değilse
                            if (mayinlar[i + 1, j - 1] == 0)//solalt
                            {
                                sayi[i, j ]++;
                              
                            }
                        if (((j + 1) % sutunSayisi != 0) && (i < satirSayisi- 1)) //son satır ve son sutunda değilse
                            if (mayinlar[i + 1, j + 1] == 0)//sağalt
                            {
                                sayi[i , j]++;
                              
                               
                            } 
                       
                        if (sayi[i,j] != 0)
                        {
                           
                            mayinlar[i, j] = -1;
                        }

                    } 
               }
           }

        
        public void bosAc(int i, int j)
        {
            if (mayinlar[i, j] == 1 && bayrak[i, j] == 0)
            {
                kareler[i, j].Enabled = false;
                kareler[i, j].BackColor = Color.White;
                mayinlar[i, j] = 4;

                //jjjjjjj
                if (j < (sutunSayisi - 1))
                {
                    bosAc(i, j + 1);
                }
                if (j > 0)
                {
                    bosAc(i, j - 1);
                }
                //iiiiiiii
                if (i < (satirSayisi - 1))
                {
                    bosAc(i + 1, j);
                }
                if (i > 0)
                {
                    bosAc(i - 1, j);
                }
                //iiiiiii----jjjjjjjjjj
                if (i > 0 && j < (sutunSayisi - 1))
                {
                    bosAc(i - 1, j + 1);
                }
                if ((i < satirSayisi - 1) && j < (sutunSayisi - 1))
                {
                    bosAc(i + 1, j + 1);
                }
                if ((i < satirSayisi - 1) && (j > sutunSayisi - 1))
                {
                    bosAc(i + 1, j - 1);
                }
                if (i > 0 && j > 0)
                {
                    bosAc(i - 1, j - 1);
                }

            }
            else if (mayinlar[i, j] == 0)
            {

            }
            else if (mayinlar[i, j] == -1 && bayrak[i,j]==0)
            {
                kareler[i, j].Enabled = false;
               kareler[i, j].BackColor = Color.Pink;
                kareler[i, j].Text = sayi[i, j].ToString();
                mayinlar[i, j] = 4;
            }
        }


        public bool Mayın_Kontrol(int x, int y)
        {

            if (mayinlar[x, y] == 0)
            {
                return true;
            }
            return false;
        }
        public void puanHesapla()
        {
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (kareler[i, j].Enabled == true)
                    {
                        kalanKareSayisi++;
                    }
                }

            }
            if (alan.saniye!=0)
            {
                 int puan = ((((satirSayisi * sutunSayisi)-kalanKareSayisi)-1) / (alan.dakika * 60 + alan.saniye));
                 alan.label6.Text = puan.ToString();
            }
           
        }
        //public void temizle()
        //{
        //    for (int i = 0; i < satirSayisi; i++)
        //    {
        //        for (int j = 0; j < sutunSayisi; j++)
        //        {
        //            alan.panel1.Controls.Remove(kareler[i, j]);
                    
        //        }
        //    }

        //}
        public void sagtıkla(object sender, MouseEventArgs e)
        {

            Button tıklanan = (Button)sender;
            int gelen_i = 1;
            int gelen_j = 1;
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (tıklanan == kareler[i, j])
                    {

                        gelen_i = i;
                        gelen_j = j;

                    }
                }
            }
                if (e.Button == MouseButtons.Right)
                {

                    if (bayrak[gelen_i, gelen_j]==1)
                    {
                        kareler[gelen_i, gelen_j].Image = null;
                        bayrak[gelen_i, gelen_j] = 0;
                        kareler[gelen_i, gelen_j].BackColor = Color.CornflowerBlue;
                        kalanbayrak += 1;
                        alan.label5.Text = kalanbayrak.ToString();
                    }
                    else if (bayrak[gelen_i, gelen_j] == 0)
                    {
                        if (kalanbayrak <= 0)
                        {
                            MessageBox.Show("Daha fazla bayrak ekleyemezsiniz.");
                        }
                        else 
                        {
                            kareler[gelen_i, gelen_j].Image = Mayintarlası.Properties.Resources.flag1;
                            kareler[gelen_i, gelen_j].BackgroundImageLayout = ImageLayout.Stretch;
                            kareler[gelen_i, gelen_j].BackColor = Color.White;
                            kalanbayrak -= 1;
                            alan.label5.Text = kalanbayrak.ToString();
                            bayrak[gelen_i, gelen_j] = 1;
                        }
                    
                       
                    }

                }

        }
        
    }

}
