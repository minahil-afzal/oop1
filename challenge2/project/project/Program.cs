using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Class
{
    public class Product
    {
        public Product()
        {

        }
        public Product(string n, string c, float pr, float qn, float st)
        {
            productName = n;
            productCategory = c;
            productPrice = pr;
            stockQuantity = qn;
            minimumStock = st;
        }

        public string productName;
        public string productCategory;
        public float productPrice;
        public float stockQuantity;
        public float minimumStock;
    }
}

