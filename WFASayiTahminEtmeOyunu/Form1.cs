using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFASayiTahminEtmeOyunu
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            lblPuan.Text = puan.ToString();

            lblIpucu.Text = "Sayı 0 ile 1000 arasındadır";
            sayi = rnd.Next(1001);
            lblSaniye.Text = "60";

        }

        int puan = 1000;
        Random rnd = new Random();
        int sayi;
        int sayac = 0;
        int saniye = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;

            saniye = saniye - 1;
            lblSaniye.Text = Convert.ToString(saniye);
            if (saniye == 0)
            {
                timer1.Stop();
                MessageBox.Show("Süren Bitti Oyun Bitti !", "Süre bitti gitti!");
                DialogResult dialogResult2 = MessageBox.Show("Yeni oyuna başlamak ister misin ?", "Tekrar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult2 == DialogResult.Yes)
                {
                    MessageBox.Show("Sayıyı çoktan değiştirdim. Kaldığın yerden devam etmeyi deneme ! ", "Haberin olsun !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    puan = 1000;
                    sayi = rnd.Next(1001);
                    sayac = 0;
                    saniye = 60;
                    lblSaniye.Text = Convert.ToString(saniye);
                }
                else
                    Close();

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                timer1.Start();

                int tahmin = Convert.ToInt32(txtSayi.Text);
                

                if (sayi == tahmin)
                {
                    timer1.Stop();
                    lblIpucu.Text = $"Tebrikler kazandınız";
                    MessageBox.Show("TEBRİKLER OYUNU KAZANDINIZ", "KAZANDINIZ !!!!!");
                    DialogResult dialogResult = MessageBox.Show("Yeniden Oynamak İstermisiniz ?", "Yeniden ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        MessageBox.Show("Sayı tekrar değiştirildi bol şans. ", "Haberin olsun !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        puan = 1000;
                        sayi = rnd.Next(1001);
                        saniye = 60;
                        lblSaniye.Text = Convert.ToString(saniye);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        Close();

                    }
                }
                else if (tahmin < sayi)
                {
                    lblIpucu.Text = $"Girdiğin sayı :{tahmin} \r\n Tahminini arttır.";
                    puan -= 100;
                }
                else if (tahmin > sayi)
                {
                    lblIpucu.Text = $"Girdiğin sayı :{tahmin} \r\n Tahminini düşür.";
                    puan -= 100;
                }

                if (puan == 0 || puan < 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Puanınız tükendi 500 puan daha verebilirim.İster misin ?", "Kaybettin", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (sayac == 0)
                        {
                            MessageBox.Show("2.Şansın iyi kullan 500 puan daha verdim.", "Haberin olsun !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puan = 500;
                            sayac++;
                        }
                        else
                        {
                            timer1.Stop();
                            MessageBox.Show("2.Şans bir kere gelir üzgünüm Oyun Bitti.", "Geçmiş olsun!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }

                    else if (dialogResult == DialogResult.No)
                    {
                        timer1.Stop();
                        DialogResult dialogResult2 = MessageBox.Show("Yeni oyuna başlamak ister misin ?", "Tekrar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            
                            MessageBox.Show("Sayıyı çoktan değiştirdim. Kaldığın yerden devam etmeyi deneme ! ", "Haberin olsun !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puan = 1000;
                            sayi = rnd.Next(1001);
                            sayac = 0;
                            saniye = 60;
                            lblSaniye.Text = Convert.ToString(saniye);
                        }
                        else
                            Close();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                        Close();

                }
                
                

                lblPuan.Text = puan.ToString();
                txtSayi.Clear();


            }

            catch
            {
                MessageBox.Show("Sadece sayı girişi yapabilirsin", "Hop Nereye ?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

      

       
        
    }
}
