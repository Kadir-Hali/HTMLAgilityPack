using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HTMLAgilityPack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//TRENDYOL
        {
            //Uri url = new Uri("https://www.trendyol.com/arzum/ok004-k-okka-minio-turk-kahvesi-makinesi-krom-p-415310?boutiqueId=620857&merchantId=105330");
            Uri url = new Uri("https://www.trendyol.com/reeder/p13-blue-max-2022-4-gb-128-gb-yesil-cep-telefonu-reeder-turkiye-garantili-p-299146129?boutiqueId=61&merchantId=364277");
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            var baslik = dokuman.DocumentNode.SelectNodes("//*[@id=\"product-detail-app\"]/div/div[2]/div[1]/div[2]/div[2]/div[2]/div/div/div[1]/h1/span").First().InnerText;
            var marka = dokuman.DocumentNode.SelectNodes("//*[@id=\"product-detail-app\"]/div/div[2]/div[1]/div[2]/div[2]/div[2]/div/div/div[1]/h1/a").First().InnerText;
            var bilgi = dokuman.DocumentNode.SelectNodes("//*[@id=\"product-detail-app\"]/div/section/div/div/div").First().InnerText;
            var urunOzellikleri = dokuman.DocumentNode.SelectNodes("//*[@id=\"product-detail-app\"]/div/section/div/ul").First().InnerText;
            //var urunAciklaması = dokuman.DocumentNode.SelectNodes("//*[@id=\"urun-aciklamasi\"]/div").First().InnerText;
            var picLink = dokuman.DocumentNode.SelectSingleNode("//*[@id=\"product-detail-app\"]/div/div[2]/div[1]/div[2]/div[1]/div/div[2]/div/div[1]/img").Attributes["src"].Value;
            //var imageStream = HttpWebRequest.Create(imagePath).GetResponse().GetResponseStream();
            //this.pictureBox1.Image=Image.FromStream(imageStream);
            listBox1.Items.Add("Ürün Adı : " + baslik);
            listBox1.Items.Add("Marka : " + marka);
            listBox1.Items.Add("Ürün Bilgileri : " + bilgi);
            listBox1.Items.Add("Ürün Özellikleri : " + urunOzellikleri);
            //listBox1.Items.Add("Ürün Açıklaması : " + urunAciklaması);// TÜM ÜRÜNLERDE BU ALAN YOK!
            listBox1.Items.Add("Ürün Foto Linki : " + picLink);
        }
    }
}