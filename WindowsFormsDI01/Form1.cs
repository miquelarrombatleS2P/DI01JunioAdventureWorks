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
        List<ProductModel> products = new List<ProductModel>();
        

        public string sql = $"SELECT DISTINCT "
                       + $"Production.Product.ProductModelID AS ProductModelID, Production.ProductModel.Name, Production.ProductDescription.Description, "
                       + $"Production.Product.ListPrice, "
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

            List<Category> categories = new List<Category>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sql2 = "select [ProductCategoryID],[Name] from Production.ProductCategory";
                categories = connection.Query<Category>(sql2).ToList();

                foreach (Category categorys in categories)
                {
                    categoryList.Items.Add(categorys);
                }

            }

        }

        private void initializeListBox()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                
                products = connection.Query<ProductModel>(sql).ToList();

                List<ProductModel> productsTotal = products.Distinct().ToList();
                List<ProductModel> output = new List<ProductModel>();

                duplicates(productsTotal, output);

            }
        }

        private void productList_DoubleClick(object sender, EventArgs e)
        {
            string productSelected = productList.SelectedItems[0].ToString();
            
            string pModelId = productSelected.Split('/')[0];
        //    string pModelDesc = productSelected.Split('/')[1];
        //    string pModelPrice = productSelected.Split('/')[2];

         //   MessageBox.Show(pModelName + pModelDesc + pModelPrice);
            string pModelID = pModelId;
            
         /*   foreach (ProductModel item in products)
            {
                if (item.Name.Equals(pModelName) && item.Description.Equals(pModelDesc) && item.ListPrice.Equals(pModelPrice))
                {
                    MessageBox.Show(item.ProductModelID);
                    pModelID = item.ProductModelID;
                }
            }
         */ 

            
            For updateProducts = new For(pModelID);
            updateProducts.ShowDialog();
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            productList.Items.Clear();
            subcategoryList.Text = "";
            subcategoryList.Items.Clear();
            categoryChangeLanguage();


            // int id = ((Category)sender).ProductCategoryID;
            int id = ((Category)categoryList.SelectedItem).ProductCategoryID;

            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
             {
                List<string> subCategories = new List<string>();

                //int valor = Int32.Parse(idCategory);

                string sql4 = $"select [Name] FROM [Production].[ProductSubcategory] WHERE ProductSubcategory.ProductCategoryID = {id}";
                subCategories = connection.Query<string>(sql4).ToList();

                foreach (string subCategory in subCategories)
                {
                    subcategoryList.Items.Add(subCategory);
                }

             }
        }
        private void categoryChangeLanguage()
        {
            subcategoryList.Enabled = true;
      
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            string sql1 = sql + $"AND ProductCategory.Name = '{categoryList.Text}'";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<ProductModel> products = new List<ProductModel>();

                products = connection.Query<ProductModel>(sql1).ToList();

                List<ProductModel> output = new List<ProductModel>();

                duplicates(products, output);

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

            string sql1 = sql + $"AND ProductSubcategory.Name = '{subcategoryList.Text}'";

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

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            categoryList.Text = "";
            subcategoryList.Text = "";
            subcategoryList.Enabled = false;

            if (searchBox.Equals(""))
            {
                initializeListBox();
            }
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sql1 = sql + $"AND Product.Name like '%{searchBox.Text}%' AND ProductModel.Name like '%{searchBox.Text}%'";

                List<ProductModel> products = new List<ProductModel>();
                products = connection.Query<ProductModel>(sql1).ToList();
                productList.Items.Clear();
                List<ProductModel> output = new List<ProductModel>();

                duplicates(products, output);


            }
        }

        private void duplicates(List<ProductModel> products, List<ProductModel> output)
        {
            foreach (ProductModel item in products)
            {
                bool add = true;

                foreach (var itemOut in output)
                {
                    if (item.ProductModelID == itemOut.ProductModelID)
                    {
                        add = false;

                    }
                }
                if (add)
                {
                    output.Add(item);
                }
            }
            foreach (var item in output)
            {
                productList.Items.Add(item);
            }
        }
    }
}
