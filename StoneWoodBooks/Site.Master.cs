using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoneWoodBooks
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logOut(object sender, EventArgs e)
        {
            Cache.Remove("Username");
            Response.Redirect("Login.aspx");
        }
    }
}