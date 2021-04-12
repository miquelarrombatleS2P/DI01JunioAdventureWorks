using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace WindowsFormsDI01
{
    public partial class Form2 : Form
    {
        int ProductModelId = 0;
        public string sql = $"SELECT "
                       + $"Production.Product.ProductID AS ProductID, Production.Product.ProductModelID AS ProductModelID, Production.Product.Name, "
                       + $"Production.ProductDescription.Description, Production.Product.ListPrice, Production.Product.Size, Production.Product.Color "
                       + $"FROM "
                       + $"Production.Product "
                       + $"INNER JOIN Production.ProductSubcategory on Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID "
                       + $"INNER JOIN Production.ProductCategory on Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID "
                       + $"INNER JOIN Production.ProductModel on Production.Product.ProductModelID = Production.ProductModel.ProductModelID "
                       + $"INNER JOIN Production.ProductModelProductDescriptionCulture on Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID "
                       + $"INNER JOIN Production.ProductDescription on Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID "
                       + $"WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL ";

        public Form2(string ProductModelID)
        {
            InitializeComponent();
            ProductModelId = int.Parse(ProductModelID.ToString());
            initialInformation();

        }

        private void initialInformation()
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"AND Product.ProductModelID = '{ProductModelId}';";

                products = connection.Query<Product>(sql1).ToList();

                List<string> size = new List<string>();
                List<string> color = new List<string>();

                int locate = 25;

                foreach (Product product in products)
                {
                    Name.Text = product.Name;
                    Description.Text = product.Description;
                    Price.Text = product.ListPrice.ToString();

                    size.Add(product.Size);
                    color.Add(product.Color);

                }

                foreach (var item in size)
                {
                    Label label = new Label();

                    this.Controls.Add(label);

                    label.AutoSize = true;
                    label.Location = new System.Drawing.Point(locate += 15, 80);
                    label.Name = "Size";
                    label.Size = new System.Drawing.Size(0, 0);
                    label.TabIndex = 4;
                    label.Visible = true;

                    label.Text = item;

                }
                foreach (var item in color)
                {
                    Label label = new Label();

                    this.Controls.Add(label);

                    label.AutoSize = true;
                    label.Location = new System.Drawing.Point(locate += 15, 90);
                    label.Name = "Color";
                    label.Size = new System.Drawing.Size(0, 0);
                    label.TabIndex = 5;
                    label.Visible = true;

                    label.Text = item;

                }

            }
        }
    }
}
