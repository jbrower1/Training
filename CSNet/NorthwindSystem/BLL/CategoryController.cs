using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data; //obtains the <T> devinitions
using NorthwindSystem.DAL;  //obtains the context class
using System.ComponentModel; // to expose a class/methods to the ODS dialogs
#endregion

namespace NorthwindSystem.BLL
{

    //YOU MUST REBUILD EVERY TIME YOU MAKE A CHANGE TO THE METHOD/ ADD ANOTHER METHOD TO BE EXPOSED
    //YOU MUST ALSO REBUILD WEBSITE

    // expose the contoller to the ODS implimentation dialogs
    [DataObject]
    public class CategoryController
    {
        
        public Category Category_Get(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }

        //expose a specific method to the ODS implimentation dialogs
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Category> Category_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }

    }
}
