using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoneWoodBooks
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewCustomers_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomersTable.aspx");
        }

        protected void btnViewSuppliers_Click(object sender, EventArgs e)
        {
            Response.Redirect("SuppliersTable.aspx");
        }

        protected void btnViewAuthors_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorsTable.aspx");
        }

        protected void btnViewOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdersTable.aspx");
        }

        protected void btnViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("BooksTable.aspx");
        }
    }
}