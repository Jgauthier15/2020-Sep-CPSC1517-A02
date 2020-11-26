﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
using System.Data.SqlClient;
using System.ComponentModel;
#endregion

namespace NorthwindSystem.BLL
{
    [DataObject]
    public class CategoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        #region Filter Search Demo Interface
        public List<Category> Category_List()
        {
            //need to connect to the Context class
            //this connection will be done in a transaction coding group
            using (var context = new NorthwindContext())
            {
                //via EnityFrame, make a request for all records,
                //all attributes from the specified DbSet property
                return context.Categories.ToList();
            }
        }
        #endregion
    }
}
