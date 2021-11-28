using System;
using System.Web.UI;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace StoneWoodBooks
{
    public partial class UpdatePW : Page
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        protected void Submit(object sender, EventArgs e)
        {
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            cmd.Connection = conn;

            cmd.CommandText = "Select Password From Customer where Username = '" + (string)Cache.Get("Username") + "';";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() & reader[0].ToString().Equals(txtPW.Text))
            {
                lblpw.Text = "Please Enter your new password";
                btnSubmit.Enabled = false;
                btnSubmit.Visible = false;
                btnChangePW.Enabled = true;
                btnChangePW.Visible = true;
            }

            else
                lblpw.Text = "Wrong password entered, try typing slowly";

            conn.Close();
        }

        protected void btnChangePW_Click(object sender, EventArgs e)
        {
            if(btnChangePW.Text.Length == 0)
            {
                lblpw.Text = "Password must have at least one character";
                return;
            }

            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "Update Customer Set Password = '" + txtPW.Text + "' Where Username = '" 
                + Cache.Get("Username") + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
            lblpw.Text = "Password changed";
            btnChangePW.Visible = false;
            txtPW.Visible = false;

        }
    }
}