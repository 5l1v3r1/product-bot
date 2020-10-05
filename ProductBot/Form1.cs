using ProductBot.BusinessLogicLayer;
using ProductBot.Entities;
using ProductBot.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductBot
{
    public partial class ProductBot : Form
    {
        private ProductManager productManager;
        private EmailManager mailManager;
        private List<Product> products;
        private Email mail;
        public ProductBot()
        {
            productManager = new ProductManager();
            mailManager = new EmailManager();
            
            InitializeComponent();
        }

        private void Search_Btn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Search_Textbox.Text))
            {
                products = productManager.SearchProduct(Search_Textbox.Text);
                Search_GridView.DataSource = null;
                Search_GridView.Refresh();

                if (products == null || products.Count == 0)
                {
                    MessageBox.Show("Sonuç Bulunamadı.");
                }
                else
                {
                    Search_GridView.DataSource = products;
                    Search_GridView.Refresh();
                }
            }
        }

        private void Kaydet_Btn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Email_TextBox.Text) && !String.IsNullOrEmpty(Percent_TextBox.Text))
            {
                if (products == null || products.Count == 0)
                {
                    MessageBox.Show("Lütfen Kayıt Etmek İçin Ürün Arayınız.");
                }
                else
                {
                    mail = new Email
                    {
                        MailAddress = Email_TextBox.Text,
                        PricePercent = Convert.ToInt32(Percent_TextBox.Text)
                    };

                    int mailID = mailManager.SaveEmail(mail);
                    productManager.SaveProduct(products, mailID);

                }
              
            }
            else
            {
                MessageBox.Show("Lütfen Mail Adresi ve Fiyat Yüzdesi Alanlarını Doldurunuz.");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            productManager.CheckProductPrice();
        }

        private void Start_Btn_Click(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            timer1.Start();
        }

        private void Stop__Btn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
