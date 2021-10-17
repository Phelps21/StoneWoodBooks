using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoneWoodBooks
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateNewAccount_Click(object sender, EventArgs e)
        {
            //Create SQL queries to check if account can be created
            //iff account is created, redirect to homepage
            Response.Redirect("Default.aspx");
        }
    }
}