using NorthwindSystem.BLL;
using NorthwindSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class GridViewCodeBehind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        protected Exception GetInnerException(Exception ex)
        {
            while(ex.InnerException!=null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductArg.Text))
            {
                MessageLabel.Text = "Enter a product name (or portion of) then press Search.";
            }
            else
            {
                try
                {
                    ProductController sysmgr = new ProductController();
                    List<Product> info = sysmgr.Products_GetByPartialProductName
                        (ProductArg.Text);
                    if(info.Count > 0)
                    {
                        ProductList.DataSource = info;
                        ProductList.DataBind();
                    }
                    else
                    {
                        MessageLabel.Text = "No products match your search value.";
                        //to empty a GridView
                        ProductList.DataSource = null;
                        ProductList.DataBind();
                    }
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = GetInnerException(ex).Message;
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ProductID.Text = "";
            ProductName.Text = "";
            UnitPrice.Text = "";
            Discontinued.Checked = false;
            ProductArg.Text = "";
            ProductList.DataSource = null;
            ProductList.DataBind();
        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //determine the selected GridView Row
                //this obtains a pointer to the selected row
                GridViewRow agvrow = ProductList.Rows[ProductList.SelectedIndex];
                HiddenField aPointerToControl = agvrow.FindControl("ProductID") as HiddenField;
                //fields from the GridView are returned as a string
                string hiddenfieldvalue = aPointerToControl.Value;
                //convert the string value to a numeric
                int productid = int.Parse(hiddenfieldvalue);

                //how to combine it all into one line
                //int productid = int.Parse((agvrow.FindControl("ProductID") as HiddenField).Value);

                ProductController sysmgr = new ProductController();
                Product info = sysmgr.Product_FindByID(productid);
                if (info == null)
                {
                    MessageLabel.Text = "Product not currently on file. Refresh your search";
                    //fast way to empty fields, use an event-method already coded
                    Clear_Click(sender, e);
                }
                else
                {
                    ProductID.Text = info.ProductID.ToString();
                    ProductName.Text = info.ProductName;
                    UnitPrice.Text = string.Format("{0:0.00}", info.UnitPrice);
                    Discontinued.Checked = info.Discontinued;
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = GetInnerException(ex).Message;
            }
        }

    }
}