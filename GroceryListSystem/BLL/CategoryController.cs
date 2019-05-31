using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using GroceryList.Data.Entities;
using GroceryListSystem.DAL;
using System.ComponentModel;
#endregion

namespace GroceryListSystem.BLL
{
    [DataObject]
    public class CategoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Category> Category_List()
        {
            using (var context = new GroceryListContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category Get_Category(int categoryid)
        {
            using (var context = new GroceryListContext())
            {
                return context.Categories.Find(categoryid);
            }
        }
    }
}
