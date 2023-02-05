using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace HuR_Kart_v1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] hy_Kart_Matris ={{0,0,1,1,2,2},
                               {3,3,4,4,5,5},
                               {6,6,7,7,8,8},
                               {9,9,10,10,11,11},
                               {12,12,13,13,14,14}
                               };

        Image[,] hy_Kart_Image = new Image[5, 6];

        int hy_Kacinci_Kart;
        int hy_Kart_A, hy_Kart_B;
        PictureBox hy_ilk, hy_ikinci;
        int hy_Eslesme, hy_Hamle, hy_Puan = 3000;
        string hy_Rumuz;
        System.Media.SoundPlayer hy_Player = new System.Media.SoundPlayer();

        

        public string hy_Pc_IP()
        {
            string hy_StrHostName = "";
            hy_StrHostName = System.Net.Dns.GetHostName();
            IPHostEntry hy_IpEntry = System.Net.Dns.GetHostEntry(hy_StrHostName);
            IPAddress[] hy_Addr = hy_IpEntry.AddressList;
            return hy_Addr[hy_Addr.Length - 1].ToString();
        }

        private string hy_Roma(int hy_sayi)
        {
            int hy_Hane;
            string hy_Sayi_Roma = "";
            //
            string[] hy_Roma_Birler = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] hy_Roma_Onlar = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] hy_Roma_Yuzler = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] hy_Roma_Binler = { "", "M", "M", "M", "", "", "", "", "", "" };
            //
            hy_Hane = hy_sayi / 1000;
            hy_sayi -= hy_Hane * 1000;
            hy_Sayi_Roma += hy_Roma_Binler[hy_Hane];
            //
            hy_Hane = hy_sayi / 100;
            hy_sayi -= hy_Hane * 100;
            hy_Sayi_Roma += hy_Roma_Yuzler[hy_Hane];
            //
            hy_Hane = hy_sayi / 10;
            hy_sayi -= hy_Hane * 10;
            hy_Sayi_Roma += hy_Roma_Onlar[hy_Hane];
            //
            hy_Hane = hy_sayi;
            hy_sayi -= hy_Hane;
            hy_Sayi_Roma += hy_Roma_Birler[hy_Hane];
            //
            return hy_Sayi_Roma;
        }

        private void hy_Kart_Iceriklerini_Gizle()
        {
            hy_pcbox_00.Image=null; hy_pcbox_01.Image=null; hy_pcbox_02.Image=null; hy_pcbox_03.Image=null; hy_pcbox_04.Image=null; hy_pcbox_05.Image=null;
            hy_pcbox_10.Image=null; hy_pcbox_11.Image=null; hy_pcbox_12.Image=null; hy_pcbox_13.Image=null; hy_pcbox_14.Image=null; hy_pcbox_15.Image=null;
            hy_pcbox_20.Image=null; hy_pcbox_21.Image=null; hy_pcbox_22.Image=null; hy_pcbox_23.Image=null; hy_pcbox_24.Image=null; hy_pcbox_25.Image=null;
            hy_pcbox_30.Image=null; hy_pcbox_31.Image=null; hy_pcbox_32.Image=null; hy_pcbox_33.Image=null; hy_pcbox_34.Image=null; hy_pcbox_35.Image=null;
            hy_pcbox_40.Image=null; hy_pcbox_41.Image=null; hy_pcbox_42.Image=null; hy_pcbox_43.Image=null; hy_pcbox_44.Image=null; hy_pcbox_45.Image=null;   
            
             
             
        }

        private void hy_Kartlari_Göster()
        {
            hy_pcbox_00.Visible=true; hy_pcbox_01.Visible=true; hy_pcbox_02.Visible=true; hy_pcbox_03.Visible=true; hy_pcbox_04.Visible=true; hy_pcbox_05.Visible=true;
            hy_pcbox_10.Visible=true; hy_pcbox_11.Visible=true; hy_pcbox_12.Visible=true; hy_pcbox_13.Visible=true; hy_pcbox_14.Visible=true; hy_pcbox_15.Visible=true;
            hy_pcbox_20.Visible=true; hy_pcbox_21.Visible=true; hy_pcbox_22.Visible=true; hy_pcbox_23.Visible=true; hy_pcbox_24.Visible=true; hy_pcbox_25.Visible=true;
            hy_pcbox_30.Visible=true; hy_pcbox_31.Visible=true; hy_pcbox_32.Visible=true; hy_pcbox_33.Visible=true; hy_pcbox_34.Visible=true; hy_pcbox_35.Visible=true;
            hy_pcbox_40.Visible=true; hy_pcbox_41.Visible=true; hy_pcbox_42.Visible=true; hy_pcbox_43.Visible=true; hy_pcbox_44.Visible=true; hy_pcbox_45.Visible=true;   
            
           
        }

        private void hy_Kartlar_Aktif()
        {
            hy_pcbox_00.Enabled=true; hy_pcbox_01.Enabled=true; hy_pcbox_02.Enabled=true; hy_pcbox_03.Enabled=true; hy_pcbox_04.Enabled=true; hy_pcbox_05.Enabled=true;
            hy_pcbox_10.Enabled=true; hy_pcbox_11.Enabled=true; hy_pcbox_12.Enabled=true; hy_pcbox_13.Enabled=true; hy_pcbox_14.Enabled=true; hy_pcbox_15.Enabled=true;
            hy_pcbox_20.Enabled=true; hy_pcbox_21.Enabled=true; hy_pcbox_22.Enabled=true; hy_pcbox_23.Enabled=true; hy_pcbox_24.Enabled=true; hy_pcbox_25.Enabled=true;
            hy_pcbox_30.Enabled=true; hy_pcbox_31.Enabled=true; hy_pcbox_32.Enabled=true; hy_pcbox_33.Enabled=true; hy_pcbox_34.Enabled=true; hy_pcbox_35.Enabled=true;
            hy_pcbox_40.Enabled=true; hy_pcbox_41.Enabled=true; hy_pcbox_42.Enabled=true; hy_pcbox_43.Enabled=true; hy_pcbox_44.Enabled=true; hy_pcbox_45.Enabled=true;


        }

        private void hy_Kartlar_Pasif()
        {

            hy_pcbox_00.Enabled=false; hy_pcbox_01.Enabled=false; hy_pcbox_02.Enabled=false; hy_pcbox_03.Enabled=false; hy_pcbox_04.Enabled=false; hy_pcbox_05.Enabled=false;
            hy_pcbox_10.Enabled=false; hy_pcbox_11.Enabled=false; hy_pcbox_12.Enabled=false; hy_pcbox_13.Enabled=false; hy_pcbox_14.Enabled=false; hy_pcbox_15.Enabled=false;
            hy_pcbox_20.Enabled=false; hy_pcbox_21.Enabled=false; hy_pcbox_22.Enabled=false; hy_pcbox_23.Enabled=false; hy_pcbox_24.Enabled=false; hy_pcbox_25.Enabled=false;
            hy_pcbox_30.Enabled=false; hy_pcbox_31.Enabled=false; hy_pcbox_32.Enabled=false; hy_pcbox_33.Enabled=false; hy_pcbox_34.Enabled=false; hy_pcbox_35.Enabled=false;
            hy_pcbox_40.Enabled=false; hy_pcbox_41.Enabled=false; hy_pcbox_42.Enabled=false; hy_pcbox_43.Enabled=false; hy_pcbox_44.Enabled=false; hy_pcbox_45.Enabled=false;

            
        }

        private void hy_Kartlari_Yerlestir()
        {
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 6; j += 2)
                {
                    hy_Kart_Image[i, j] = hy_image.Images[2 * i + j / 2];
                    hy_Kart_Matris[i, j] = 2 * i + j / 2;
                    hy_Kart_Image[i, j+1] = hy_image.Images[2 * i + j / 2];
                    hy_Kart_Matris[i, j+1] = 2 * i + j / 2;

                }
            }
        }

        private void hy_Kartlari_Karistir()
        {
            int hy_Yedek_Resim_No = 0;
            Image hy_Yedek_Image;
            int hy_x1, hy_y1,
                hy_x2, hy_y2;

            //Karıştırma İşlemi
            Random hy_Rastgele = new Random();
            for (int i = 0; i < 50; i++)
            {
                hy_x1 = hy_Rastgele.Next(0, 5);
                hy_x2 = hy_Rastgele.Next(0, 5);
                hy_y1 = hy_Rastgele.Next(0, 6);
                hy_y2 = hy_Rastgele.Next(0, 6);
                //Resimleri Yerleştirme
                hy_Yedek_Image = hy_Kart_Image[hy_x1, hy_y1];
                hy_Kart_Image[hy_x1, hy_y1] = hy_Kart_Image[hy_x2, hy_y2];
                hy_Kart_Image[hy_x2, hy_y2] = hy_Yedek_Image;
                //Resim No Değişimi
                hy_Yedek_Resim_No = hy_Kart_Matris[hy_x1, hy_y1];
                hy_Kart_Matris[hy_x1, hy_y1] = hy_Kart_Matris[hy_x2, hy_y2];
                hy_Kart_Matris[hy_x2, hy_y2] = hy_Yedek_Resim_No;
            }


        }

        private void hy_pcbox_kart_ac(object sender, EventArgs e)
        {
            PictureBox hy_Tiklanan = ((PictureBox)sender);

            int hy_Koordinat_x, hy_Koordinat_y;
            hy_Koordinat_x = Convert.ToInt32(((PictureBox)(sender)).Name.Substring(9, 1));
            hy_Koordinat_y = Convert.ToInt32(((PictureBox)(sender)).Name.Substring(10, 1));
            hy_Tiklanan.Image = hy_Kart_Image[hy_Koordinat_x, hy_Koordinat_y];
            hy_Kacinci_Kart++;
            hy_Tiklanan.Enabled=false;
            if (hy_Kacinci_Kart == 1)
            {
                hy_Kart_A = hy_Kart_Matris[hy_Koordinat_x, hy_Koordinat_y];
                hy_ilk = hy_Tiklanan;
                if (hy_ses_ac.Checked)
                {
                    try
                    {
                        hy_Player.SoundLocation = @"Medya\Kart.wav";
                        hy_Player.Play();
                    }
                    catch { }
                }


            }
            else if (hy_Kacinci_Kart == 2)
            {
                hy_Hamle++;
                hy_Kart_B = hy_Kart_Matris[hy_Koordinat_x, hy_Koordinat_y];
                hy_tmr_kartlari_kapat.Start();
                hy_Kartlar_Pasif();
                hy_ikinci = hy_Tiklanan;
                hy_Kacinci_Kart = 0;



            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void enİyilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hy_tab_hur.SelectTab(1);
            
        }

        private void hy_hakkında_Click(object sender, EventArgs e)
        {
            hy_tab_hur.SelectTab(2);
        }

        private void hy_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hy_btn_yeni_oyun_Click(object sender, EventArgs e)
        {
            hy_Puan = 3000;
            hy_lbl_puan1.Text = "---";
            hy_Eslesme = 0;
            hy_lbl_eslenen_kart1.Text = "---";
            hy_Hamle = 0;
            hy_lbl_hamle1.Text = "---";
            hy_Kacinci_Kart = 0;
            hy_tmr_puan.Start();
            hy_tab_hur.SelectTab(0);
            hy_Kart_Iceriklerini_Gizle();
            hy_Kartlari_Yerlestir();
            hy_Kartlari_Karistir();
            hy_Kartlari_Göster();
            hy_Eslesme = 0;
            hy_Kartlar_Aktif();

            if (hy_ses_ac.Checked)
            {

                try
                {
                    hy_Player.SoundLocation = @"Medya\Yeni_oyun.wav";
                    hy_Player.Play();
                }
                catch
                { }
            } hy_Kartlari_Yerlestir();
            hy_Kartlari_Karistir();
        }

        private void hy_tmr_kartlari_kapat_Tick(object sender, EventArgs e)
        {
            hy_lbl_hamle1.Text = hy_Roma(hy_Hamle);
            hy_Kacinci_Kart = 0;
            hy_tmr_kartlari_kapat.Stop();
            if (hy_Kart_A == hy_Kart_B)
            {
                hy_Eslesme++;
                hy_ilk.Visible = false;
                hy_ikinci.Visible = false;
                hy_lbl_eslenen_kart1.Text = hy_Roma(hy_Eslesme);
                if (hy_ses_ac.Checked)
                {
                    try
                    {
                        hy_Player.SoundLocation = @"Medya\Eslesme.wav";
                        hy_Player.Play();
                    }
                    catch { }
                }

            }
            else
            {
                if (hy_ses_ac.Checked)
                {
                    try
                    {
                        hy_Player.SoundLocation = @"Medya\Kart2.wav";
                        hy_Player.Play();
                    }
                    catch { }
                }
                hy_lbl_puan1.Text = hy_Roma(hy_Puan -= 10);

            }
            hy_Kart_Iceriklerini_Gizle();
            hy_Kartlar_Aktif();
            if (hy_Eslesme == 14)
            {
                hy_tmr_puan.Stop();


            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("HüR-Kart Terk Edilecek!\nOnaylıyor Musunuz?", "HüR-Kart Sonlandırma", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (hy_ses_ac.Checked)
                {
                    //Sesler
                }
            }
            else
            {
                //Çıkışı İptal Etme
                e.Cancel = true;
            }
        }

        private void hy_tmr_puan_Tick(object sender, EventArgs e)
        {
            hy_lbl_puan1.Text = hy_Roma(hy_Puan--);
        }
    }
}
