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
    public partial class For : Form
    {
        int ProductModelId = 0;
       
        public string sql = $"SELECT "
                       + $"Production.Product.ProductID AS ProductID, Production.Product.ProductModelID AS ProductModelID, Production.ProductModel.Name, "
                       + $"Production.ProductDescription.Description, Production.Product.ListPrice, Production.Product.Size, Production.Product.Color "
                       + $"FROM "
                       + $"Production.Product "
                       + $"INNER JOIN Production.ProductSubcategory on Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID "
                       + $"INNER JOIN Production.ProductCategory on Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID "
                       + $"INNER JOIN Production.ProductModel on Production.Product.ProductModelID = Production.ProductModel.ProductModelID "
                       + $"INNER JOIN Production.ProductModelProductDescriptionCulture on Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID "
                       + $"INNER JOIN Production.ProductDescription on Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID "
                       + $"WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL ";

        public For(string ProductModelID)
        {
            InitializeComponent();
            ProductModelId = Int32.Parse(ProductModelID);
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

                List<string> sizeDuplicates = new List<string>();
                List<string> colorDuplicates = new List<string>();

                int locateSize = 25;
                int locateColor = 20;

                foreach (Product product in products)
                {
                    Name.Text = product.Name;
                    decription.Text = product.Description;
                    Price.Text = product.ListPrice.ToString() + "€";

                    sizeDuplicates.Add(product.Size);
                    colorDuplicates.Add(product.Color);

                }
                List<string> sizeList = sizeDuplicates.Distinct().ToList();
                List<string> colorList = colorDuplicates.Distinct().ToList();

                foreach (var item in sizeList)
                {
                    Button newButton = new Button();
                    this.Controls.Add(newButton);
                    newButton.Text = item;
                    newButton.Location = new Point(locateSize += 70, 165);
                    newButton.Size = new Size(45, 45);
                    
                }
               
                foreach (var item in colorList)
                {

                    Button newButton = new Button();
                    this.Controls.Add(newButton);
                    newButton.Text = item;
                    newButton.Location = new Point(locateColor += 75, 218);
                    newButton.Size = new Size(75, 45);

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update has successfully");
        }

  
    }
}
