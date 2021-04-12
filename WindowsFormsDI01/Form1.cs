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
    public partial class Form1 : Form
    {
        public string sql = $"SELECT "
                       + $"Production.Product.ProductModelID AS ProductModelID, Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, "
                       + $"Production.Product.Name, Production.Product.ProductNumber, Production.Product.Color, Production.Product.ListPrice, "
                       + $"Production.Product.Size, Production.Product.ProductLine, Production.Product.Class, Production.Product.Style, "
                       + $"Production.ProductCategory.Name AS ProductCategory, Production.ProductSubcategory.Name AS ProductSubcategory "
                       + $"FROM "
                       + $"Production.Product "
                       + $"INNER JOIN Production.ProductSubcategory on Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID "
                       + $"INNER JOIN Production.ProductCategory on Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID "
                       + $"INNER JOIN Production.ProductModel on Production.Product.ProductModelID = Production.ProductModel.ProductModelID "
                       + $"INNER JOIN Production.ProductModelProductDescriptionCulture on Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID "
                       + $"INNER JOIN Production.ProductDescription on Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID "
                       + $"WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL ";

        public Form1()
        {
            InitializeComponent();
            initializeListBox();
            subcategoryList.Enabled = false;
            MainForm_Load();

        }

        private void MainForm_Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<string> categories = new List<string>();

                string sql2 = "select [Name] from Production.ProductCategory";
                categories = connection.Query<string>(sql2).ToList();

                foreach (var category in categories)
                {
                    categoryList.Items.Add(category);
                }

                List<string> subcategorys = new List<string>();

                string sql3 = "select [Name] from Production.ProductSubcategory";
                subcategorys = connection.Query<string>(sql3).ToList();

                foreach (var subcategory in subcategorys)
                {
                    subcategoryList.Items.Add(subcategory);
                }
            }

        }

        private void initializeListBox()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<ProductModel> products = new List<ProductModel>();

                products = connection.Query<ProductModel>(sql).ToList();

                foreach (ProductModel product in products)
                {
                    productList.Items.Add(product.ToString());
                }
            }
        }

        private void productList_DoubleClick(object sender, EventArgs e)
        {
            string productSelected = productList.SelectedItems[0].ToString();
            string idproductModel = productSelected.Split('/')[0];
            string productModelID = idproductModel.ToString();

            Form2 updateProducts = new Form2(productModelID);
            updateProducts.ShowDialog();
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            productList.Items.Clear();
            categoryChangeLanguage();
        }
        private void categoryChangeLanguage()
        {
            subcategoryList.Enabled = true;
      
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            string sql1 = sql + $"AND ProductCategory.Name = '{categoryList.Text}' ORDER BY Product.Name";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<ProductModel> products = new List<ProductModel>();

                products = connection.Query<ProductModel>(sql1).ToList();
               
                foreach (ProductModel product in products)
                {
                    productList.Items.Add(product.ToString());
                }
            }
        }

        private void subcategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            productList.Items.Clear();
            subCategoryChangeLanguage();
        }

        private void subCategoryChangeLanguage()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            string sql1 = sql + $"AND ProductSubcategory.Name = '{subcategoryList.Text}' ORDER BY Product.Name";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<ProductModel> products = new List<ProductModel>();

                products = connection.Query<ProductModel>(sql1).ToList();
                               
                foreach (ProductModel product in products)
                {
                    productList.Items.Add(product.ToString());
                }

            }
        }
    }
}
