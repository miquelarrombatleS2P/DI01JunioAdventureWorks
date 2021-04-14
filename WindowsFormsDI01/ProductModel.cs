using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsDI01
{
    class ProductModel
    {
        public string ProductModelID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double ListPrice { get; set; }

        public override string ToString()
        {
            return $"{ProductModelID}/{Name}/{Description}/{ListPrice}";
        }
    }
}
