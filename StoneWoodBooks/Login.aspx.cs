using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace StoneWoodBooks
{
    //added this comment to test git functionality
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            //input validation - to be replaced by parameterized SQL query
            /*if (txtUser.Text.Equals("admin") && txtPassword.Text.Equals("admin"))
            {
                Response.Redirect("Default.aspx");
            }*/
            try
            {
                String username = txtUser.Text;
                String password = txtPassword.Text;

                String query = "SELECT * FROM Users WHERE Username ='" + username + "' and Password='" + password + "'";
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection = conn;

                //cmd.CommandText = "SELECT Users.Password FROM Users";

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    Response.Redirect("Default.aspx");
            }
            catch(Exception)
            {
                Response.Write("Error: Invalid input");
            }
            /*else
            {
                Response.Write("Error: incorrect username or password!");
            }*/
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            //this method will query the admin table for login validation
        }
    }
}