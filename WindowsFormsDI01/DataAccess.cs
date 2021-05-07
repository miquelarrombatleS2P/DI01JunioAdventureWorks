using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace WindowsFormsDI01
{
    class DataAccess
    {
        public static ProductPhoto GetProductWithImage(int productID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sql = $@"SELECT Product.ProductId, Name, ProductPhoto.ProductPhotoId, ThumbnailPhoto, ThumbnailPhotoFileName, LargePhoto, LargePhotoFileName 
                                FROM Production.Product 
                                INNER JOIN Production.ProductProductPhoto ON Product.ProductID = ProductProductPhoto.ProductID 
                                INNER JOIN Production.ProductPhoto ON ProductProductPhoto.ProductPhotoID = ProductPhoto.ProductPhotoID 
                                WHERE Product.ProductID = {productID}; ";

                ProductPhoto productPhoto = connection.Query<ProductPhoto>(sql).FirstOrDefault();
                return productPhoto;
            }
        }

        public static int WriteImage(string fileName, Image image)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                byte[] largePhoto = ms.ToArray();

                string sql = "Insert into Production.ProductPhoto (ThumbNailPhoto, ThumbNailPhotoFileName, LargePhoto, LargePhotoFileName)"
                           + "Values (NULL, NULL, @lrgImg, @lrgImgFileName)";
                var parametrs = new { lrgImg = largePhoto, lrgImgFileName = fileName };
                int rowsAffected = connection.Execute(sql, parametrs);
                if (rowsAffected != 1)
                {
                    throw new Exception("Error inserting an image to DB");

                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
