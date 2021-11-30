using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace StoneWoodBooks
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //TODO: add regex and rules for username, password
        public bool isValid()
        {

            // Test if the email address is a valid one within 200 ms
            try
            {
                if (!Regex.IsMatch(txtEmail.Text, @"(.*\D+.*)@(.*\D+.*)\.(\D+)", RegexOptions.None,
                    TimeSpan.FromMilliseconds(200)) || Regex.IsMatch(txtEmail.Text, @"[\s_]"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                        "alert('You have entered an invalid email address')", true);
                    return false;
                }

            }

            catch (RegexMatchTimeoutException)
            {
                return false;
            }


            // Test if the phone is a valid phone number within 200 ms
            try
            {
                if (!Regex.IsMatch(txtPhone.Text, @"^([0-9]{10})$", RegexOptions.None,
                    TimeSpan.FromMilliseconds(200)))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                        "alert('You have inserted an invalid phone number')", true);
                    return false;
                }

            }

            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            return true;
        }

        protected void btnCreateNewAccount_Click(object sender, EventArgs e)
        {
            //Create SQL queries to check if account can be created
            //iff account is created, redirect to homepage
            if (isValid())
            {
                //Create SQL connection object  
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

                //Create command object
                SqlCommand cmd1 = new SqlCommand(); //inserts into Customer
                SqlCommand cmd2 = new SqlCommand(); //inserts into CustomerEmail
                SqlCommand cmd5 = new SqlCommand(); // inserts into CustomerPhone
                SqlCommand cmd6 = new SqlCommand(); // inserts into CustomerAddress
               
                cmd1.Connection = conn;
                cmd2.Connection = conn;
                cmd5.Connection = conn;
                cmd6.Connection = conn;

                //Dynamically build query VULNERABLE TO INJECTION
                cmd1.CommandText = "INSERT INTO Customer VALUES ('" + txtUsername.Text + "', '" +
                    txtPassword.Text + "', '" + txtUserFirstName.Text + "', '" +txtUserLastName.Text +"')";

                cmd2.CommandText = "INSERT INTO CustomerEmail VALUES ('"+txtUsername.Text+"', '"+txtEmail.Text+"');";

                cmd5.CommandText = "INSERT INTO CustomerPhone VALUES ('" +txtUsername.Text + "', " +Int64.Parse(txtPhone.Text)+");";

                cmd6.CommandText = "INSERT INTO CustomerAddress VALUES ('" + txtUsername.Text + "', " + Int64.Parse(txtStreetNum.Text) + ", '"+txtUserStreetName.Text+"', '"+txtUserCity.Text+"', '"+ddlUserState.SelectedValue+"', "+Int64.Parse(txtUserZIP.Text)+");";

                if(!txtAlternateEmail.Text.Equals(""))
                {
                    SqlCommand cmd3 = new SqlCommand(); //inserts alternate email if it exists
                    cmd3.Connection = conn;
                    cmd3.CommandText = "INSERT INTO CustomerEmail VALUES ('" + txtUsername.Text + "', '" + txtAlternateEmail.Text + "');";
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();
                }

                if(!txtAlternatePhone.Text.Equals(""))
                {
                    SqlCommand cmd4 = new SqlCommand(); //inserts alternate phone if it exists
                    cmd4.Connection = conn;
                    cmd4.CommandText = "INSERT INTO CustomerPhone VALUES ('" + txtUsername.Text + "', "+Int64.Parse(txtAlternatePhone.Text)+");";
                    conn.Open();
                    cmd4.ExecuteNonQuery();
                    conn.Close();
                }

                //open connection, execute queries, close connection
                conn.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
                conn.Close();
                Session["Username"] = txtUsername.Text;
                Cache.Insert("Username", txtUsername.Text);
                Response.Redirect("Default.aspx");
            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                        "alert('Error: Please enter valid values')", true);

            }
            
        }
    }
}