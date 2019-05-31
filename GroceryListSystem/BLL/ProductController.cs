using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using GroceryList.Data.Entities;
using System.ComponentModel;
using GroceryListSystem.DAL;
#endregion

namespace GroceryListSystem.BLL
{
    [DataObject]
    public class ProductController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> Product_List()
        {
            using (var context = new GroceryListContext())
            {
                return context.Products
                              .Include(nameof(Product.Category))
                              .ToList();
            }
        }

        public Product Get_Product(int productid)
        {
            using (var context = new GroceryListContext())
            {
                return context.Products.Find(productid);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Product> GetProductByCategory(int categoryid)
        {
            using (var context = new GroceryListContext())
            {
                var result = from item in context.Products
                             where item.CategoryID == categoryid
                             select item;
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int AddProduct(Product newproduct)
        {
            using (var context = new GroceryListContext())
            {
                context.Products.Add(newproduct);
                context.SaveChanges();
                return newproduct.ProductID;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public int UpdateProduct(Product products)
        {
            using (var context = new GroceryListContext())
            {
                context.Entry(products).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public int DeleteProduct(Product item)
        {
            return DeleteProduct(item.ProductID);
        }
        public int DeleteProduct(int productid)
        {
            using (var context = new GroceryListContext())
            {
                var existing = context.Products.Find(productid);
                context.Products.Remove(existing);
                return context.SaveChanges();
            }
        }
    }
}
