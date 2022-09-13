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
using ZXing;
using System.Drawing.Imaging;

namespace Barcode_Generator_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128}; //QR_CODE
            pictureBox1.Image = writer.Write(txtEncode.Text);
            const string fileName = "generated-barcodes.txt";
            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine("Olusturulan ve kaydedilen barkod: {0}", txtEncode.Text);
            sw.Close();
            /*pictureBox1.Image.Save($"{txtEncode.Text}", ImageFormat.Jpeg);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode((Bitmap)pictureBox1.Image);
            if (result != null)
                txtDecode.Text = result.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("-----------Dosyadan Okunan Barkod Bilgisi----------------");
            const string fileName = "generated-barcodes.txt";
            StreamReader sr = new StreamReader(fileName);
            while (sr.ReadLine() is string s)
                Console.WriteLine(s);
            sr.Close();
            Console.WriteLine("-------------------------------------------");
        }
    }
}

/*StreamWriter sw = new StreamWriter(fileName,true);
sw.WriteLine(brCode.Draw(barcode, 60));
sw.Close();*/