using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public double UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public Product()
        {
            Name = "TestProduct";
            Category = "Beverages";
            Supplier = "Exotic Liquids";
            UnitPrice = 100;
            QuantityPerUnit = null;
            UnitsInStock = 0;
            UnitsOnOrder = 0;
            ReorderLevel = 0;
            Discontinued = false;
        }
        public Product(string name, string category, string supplier, string quantityPerUnit, int unitPrice, int unitsInStock,
          int unitsOnOrder , int reorderLevel, bool discontinued)
        {
            Name = name;
            Category = category;
            Supplier = supplier;
            QuantityPerUnit = quantityPerUnit;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
            UnitsOnOrder = unitsOnOrder;
            ReorderLevel = reorderLevel;
            Discontinued = discontinued;
        }
    }
}
