using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace kareKodOlusturmaVeOkuma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Image KarekodOlustur(string veri)
        {
           QRCodeEncoder qe = new QRCodeEncoder();
            qe.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qe.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            qe.QRCodeVersion = 4;
            System.Drawing.Bitmap bm = qe.Encode(veri);
            return bm;
        }

        private string KareKodOku(Image ımg)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            string metin = decoder.Decode(new QRCodeBitmapImage(ımg as Bitmap));
            return metin;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string veri =KareKodOku(pictureBox1.Image);
            label1.Text = veri;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = KarekodOlustur(richTextBox1.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
           
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
