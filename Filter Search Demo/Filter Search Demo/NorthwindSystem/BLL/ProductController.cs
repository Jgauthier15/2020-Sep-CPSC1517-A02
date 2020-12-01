using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
using System.Data.SqlClient;        //needed for the SqlParameter Class
using System.ComponentModel;        //required for ODS exposure
#endregion

namespace NorthwindSystem.BLL
{
    //expose this class to the ObjectDataSource wizard
    //this will allow for EASY selection of values for
    //  the wizard, and the wizard will generate my code
    [DataObject]
    public class ProductController
    {
        //expose the methods you wish the wizard to know about
        [DataObjectMethod(DataObjectMethodType.Select,false)]
 
        #region Filter Search Demo Interface
        //to query your database using a non primary key value
        //this will require a sql procedure to call
        //the namespace System.Data.SqlClient is required
        //the returning datatype is IEnumerable<T>
        //this returning datatype will be cast using ToList() on the return
        public List<Product> Products_GetByPartialProductName(string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByPartialProductName @PartialName",
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }

        public List<Product> Products_GetByCategories(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                //this lookup is using data that is NOT part of your primary key.
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByCategories @CategoryID",
                                    new SqlParameter("CategoryID", categoryid));
                return results.ToList();
            }
        }

        public List<Product> Products_GetBySupplierPartialProductName(int supplierid, string partialproductname)
        {
            using (var context = new NorthwindContext())
            {
                //sometimes there may be a sql error that does not like the new SqlParameter()
                //       coded directly in the SqlQuery call
                //if this happens to you then code your parameters as shown below then
                //       use the parm1 and parm2 in the SqlQuery call instead of the new....
                //don't know why but its weird
                //var parm1 = new SqlParameter("SupplierID", supplierid);
                //var parm2 = new SqlParameter("PartialProductName", partialproductname);
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetBySupplierPartialProductName @SupplierID, @PartialProductName",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("PartialProductName", partialproductname));
                return results.ToList();
            }
        }

        public List<Product> Products_GetForSupplierCategory(int supplierid, int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetForSupplierCategory @SupplierID, @CategoryID",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("CategoryID", categoryid));
                return results.ToList();
            }
        }

        public List<Product> Products_GetByCategoryAndName(int category, string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByCategoryAndName @CategoryID, @PartialName",
                                    new SqlParameter("CategoryID", category),
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
        public Product Product_FindByID(int productid)
        {
            //return the record from the database via the DbSet collection
            //where the pkey matches the supplied value
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productid);
            }
        }

        public int Product_Add(Product item)
        {
            using(var context = new NorthwindContext())
            {
                //staging
                //place your entity instance into your DbSet for processing by EntityFramework
                //This data is in memory NOT yet on your Sql Database.
                //This means that the Primary Key has NOT YET been created
                //The Primary Key is created WHEN the data is sent to the database
                context.Products.Add(item);

                //commit your transaction to the database
                //if the following command aborts, then your data record is NOT on the database,
                //  the transaction is AUTOMATICALLY RolledBack
                //After the success of the following command, the instance will be loaded with
                //  your new Primary Key identity value
                //IF you have entity VALIDATION ANNOTATION then when the following command
                //  is executed, the entity validation annotation will be EXECUTED
                context.SaveChanges();

                return item.ProductID;
            }
        }
        #endregion
    }
}
