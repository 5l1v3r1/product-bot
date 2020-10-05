using ProductBot.Entities;
using ProductBot.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProductBot.DataAccessLayer
{
    class ProductDal : DatabaseConnection
    {
        HandleException handle;

        public ProductDal()
        {
            handle = new HandleException();
        }

        public void Save(List<Product> products, int mailID)
        {
            handle.ExceptionHandler(() =>
            {

                DataTable productTable = ProductTable(products, mailID);


                using (command = new SqlCommand("insert_product", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tableproducts", productTable);
                    ConnectionControl();
                    command.ExecuteNonQuery();
                    ConnectionControl();
                };
            });

        }

       public DataTable List()
        {
            return handle.ExceptionTypeHandler<DataTable>(() =>
            {

                DataTable productTable = new DataTable();

                string query = "SELECT[platform], [url], [name], [price],[mail_address],[price_percent] FROM dbo.products as p INNER JOIN dbo.e_mails as e ON e.id = p.mail_id";
               
                using (command = new SqlCommand(query, connection))
                {

                    ConnectionControl();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                    {

                        dataAdapter.SelectCommand = command;

                        dataAdapter.Fill(productTable);

                        ConnectionControl();

                        

                    }

                };

                return productTable;
            });

        }

        public DataTable ProductTable(List<Product> products, int mailID)
        {
            return handle.ExceptionTypeHandler<DataTable>(() =>
            {
                DataTable dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("platform", typeof(string)));
            dataTable.Columns.Add(new DataColumn("url", typeof(string)));
            dataTable.Columns.Add(new DataColumn("url_name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("price", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("date", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("mail_id", typeof(int)));

            foreach(var product in products)
            {
                dataTable.Rows.Add(
                    product.Name,
                    product.Platform,
                    product.Url,
                    product.UrlName,
                    product.Price,
                    DateTime.Now,
                    mailID);
            }

            return dataTable;
            });

        }
    }
}
