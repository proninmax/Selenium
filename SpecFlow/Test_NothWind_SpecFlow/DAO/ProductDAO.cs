using NUnit.Framework;
using PageObject;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProductDAO
    {
        ProductInfo productInfo;
        AddProduct addProduct;
        public ProductDAO(ProductInfo page)
        {
            productInfo = page;
        }
        public ProductDAO (AddProduct page)
        {
            addProduct = page;
        }
        public AllProducts AddNewProduct(Product product)
        {
            addProduct.addName.SendKeys(product.Name);
            addProduct.addCategory.SendKeys(product.Category);
            addProduct.addPrice.SendKeys(product.UnitPrice.ToString());
            addProduct.addSupplier.SendKeys(product.Supplier);
            addProduct.buttonAdd.Click();
            return new AllProducts(addProduct.webDriver);
        }
        public void CheckAddProduct(Product product)
        {
            Assert.AreEqual(product.Name, productInfo.productName.GetAttribute("value").ToString());
            Assert.AreEqual(product.Category, productInfo.productCategory.Text.ToString());
            Assert.AreEqual(product.Supplier, productInfo.productSupplier.Text.ToString());
            Assert.AreEqual(product.UnitPrice.ToString() + ",0000", productInfo.productPrice.GetAttribute("value").ToString());
        }
    }
}
