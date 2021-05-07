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
using System.IO;

namespace WindowsFormsDI01
{
    public partial class DetallForm : Form
    {
        List<Product> products;
        int ProductModelId = 0;
        Product product = new Product();
        
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

        public DetallForm(string ProductModelID)
        {
            InitializeComponent();
            ProductModelId = Int32.Parse(ProductModelID);
            initialInformation();
            searchIdProduct();

        }

        private void initialInformation()
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                products = new List<Product>();

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
                    Button sizeButton = new Button();
                    this.flowLayoutPanelSize.Controls.Add(sizeButton);
                    sizeButton.Name = item;
                    sizeButton.Text = item;
                    sizeButton.Location = new Point(locateSize += 70, 165);
                    sizeButton.Size = new Size(45, 45);
                    sizeButton.Click += sizeButton_Click;

                    
                    if (sizeList[0] == item)
                    {
                        sizeButton.BackColor = Color.Red;
                        string texto = sizeButton.Text;
                        product.Size = texto;
                    }
                }

               
                foreach (var item in colorList)
                {

                    Button colorButton = new Button();
                    this.flowLayoutPanelColor.Controls.Add(colorButton);
                    colorButton.Name = item;
                    colorButton.Text = item;
                    colorButton.Location = new Point(locateColor += 75, 218);
                    colorButton.Size = new Size(75, 45);
                    colorButton.Click += colorButton_Click;

                   
                    if (colorList[0] == item)
                    {
                        colorButton.BackColor = Color.Red;
                        string texto = colorButton.Text;
                        product.Color = texto;
                    }

                }

            }
        }

        private void sizeButton_Click(object sender, EventArgs e)
        {
            foreach (Button item in flowLayoutPanelSize.Controls)
            {
                item.BackColor = Color.LightGray;
            }

            Button btn = (Button)sender;
            btn.BackColor = Color.Red;
            string texto = btn.Text;
            product.Size = texto;   
            
            searchIdProduct();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            foreach (Button item in flowLayoutPanelColor.Controls)
            {
                item.BackColor = Color.LightGray;
            }

            Button btn = (Button)sender;
            btn.BackColor = Color.Red;
            string texto = btn.Text;
            product.Color = texto;

            searchIdProduct();
        }

        private void searchIdProduct()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"AND Product.Size = '{product.Size}' AND Product.Color like '%{product.Color}%' ;";

                products = connection.Query<Product>(sql1).ToList();

                foreach (Product item in products)
                {
                    productSelected.Text = item.productID;
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update has successfully");
        }

        private void productSelected_TextChanged(object sender, EventArgs e)
        {
            ProductPhoto productPhoto = DataAccess.GetProductWithImage(int.Parse(productSelected.Text));
            byte[] photo = productPhoto.LargePhoto;
            MemoryStream ms = new MemoryStream(photo);
            Image image = Image.FromStream(ms);
            pictureBox1.Image = image; 
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileNametextBox.Text = openFileDialog1.FileName;
                pictureBox2.Image = Image.FromFile(fileNametextBox.Text);
            }
        }

        private void writeImgtoDBButton_Click(object sender, EventArgs e)
        {
            string lrgPhotoFileName = fileNametextBox.Text.Split('\\').Last();

            try
            {
                int rowsAffected = DataAccess.WriteImage(lrgPhotoFileName, pictureBox2.Image);
                MessageBox.Show("Inserted an image correctly", "Success", MessageBoxButtons.OK);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
            }
            
        }
    }
}
