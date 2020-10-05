using ProductBot.DataAccessLayer;
using ProductBot.Entities;
using ProductBot.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProductBot.BusinessLogicLayer
{

    class ProductManager
    {
        private WebBot bot;
        private ProductDal productDal;
        private List<Product> products;
        private MailSender mailSender;
        private HandleException handle;
        public ProductManager()
        {
            bot = new WebBot();
            productDal = new ProductDal();
            mailSender = new MailSender();
            handle = new HandleException();
        }

        public List<Product> SearchProduct(string productName)
        {
            products = bot.SearchProduct(productName);

            return products;
        }

        public void SaveProduct(List<Product> products, int mailID)
        {
            productDal.Save(products, mailID);
        }

        public void CheckProductPrice()
        {
            decimal newPrice;
            string message;
            string platform;

            handle.ExceptionHandler(() =>
            {
                foreach (DataRow row in productDal.List().Rows)
                {
                    platform = row["platform"].ToString();


                    if (row["platform"].ToString().Trim() == "hepsiburada")
                    {
                        newPrice = bot.CheckHepsiburadaPrice(row["url"].ToString().Trim());
                        message = PriceComparison(Convert.ToDecimal(row["price"]), newPrice, Convert.ToInt32(row["price_percent"]));
                        if (!string.IsNullOrEmpty(message))
                        {
                            mailSender.Send(row["mail_address"].ToString().Trim(), message, newPrice, row["name"].ToString().Trim(), row["url"].ToString().Trim());
                        }


                    }
                    else if (row["platform"].ToString().Trim() == "trendyol")
                    {
                        newPrice = bot.CheckTrendyolPrice(row["url"].ToString().Trim());
                        message = PriceComparison(Convert.ToDecimal(row["price"]), newPrice, Convert.ToInt32(row["price_percent"]));
                        if (!string.IsNullOrEmpty(message))
                        {
                            mailSender.Send(row["mail_address"].ToString().Trim(), message, newPrice, row["name"].ToString().Trim(), row["url"].ToString().Trim());
                        }
                    }
                }
            });

        }

        public string PriceComparison(decimal price, decimal newPrice, int price_percent)
        {
            int percent = 0;
            string message;

            if (price == newPrice)
            {
                return null;
            }
            else if (price > newPrice)
            {
                percent = Convert.ToInt32(100 - ((newPrice * 100) / price));
                if (percent >= price_percent)
                {
                    message = "Ürün fiyatı %" + percent.ToString() + " düştü.";
                    return message;
                }
                else
                {
                    return null;
                }

            }
            else
            {

                percent = Convert.ToInt32(100 - ((price * 100) / newPrice));

                if (price_percent >= percent)
                {
                    message = "Ürün fiyatı %" + percent.ToString() + " arttı.";
                    return message;
                }
                else
                {
                    return null;
                }

            }
        }


    }
}
