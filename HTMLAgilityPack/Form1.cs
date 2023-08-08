using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Uri url = new Uri("https://www.trendyol.com/arzum/ok004-k-okka-minio-turk-kahvesi-makinesi-krom-p-415310?boutiqueId=620857&merchantId=105330");
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            var baslik = dokuman.DocumentNode.SelectNodes("//*[@id=\"product-detail-app\"]/div/div[2]/div[1]/div[2]/div[2]/div[2]/div/div/div[1]/h1/span").First().InnerText;
            var aciklama = dokuman.DocumentNode.SelectNodes("//*[@id=\"product-detail-app\"]/div/section/div/div/div").First().InnerText;
            listBox1.Items.Add("Ürün Adı : " + baslik);
            listBox1.Items.Add("Ürün Açıklaması : " + aciklama);
        }
    }
}