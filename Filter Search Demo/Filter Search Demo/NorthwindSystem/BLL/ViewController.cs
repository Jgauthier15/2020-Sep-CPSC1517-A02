﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Views;
using NorthwindSystem.DAL;
using System.Data.SqlClient;        //needed for the SqlParameter Class
using System.ComponentModel;        //required for ODS exposure
#endregion


namespace NorthwindSystem.BLL
{
    //This class uses View data class objects
    [DataObject]
    public class ViewController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<ProductsInCategories>Views_ProductsOfCategory(string category)
        {
            //the context connects one to the database
            using(var context = new NorthwindContext())
            {
                var results = context.Database.SqlQuery<ProductsInCategories>(
                    "ProductsOfCategory @category",
                    new SqlParameter("category", category));
                return results.ToList();
            }
        }
    }

}
