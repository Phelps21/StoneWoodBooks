using System;
using System.Web.UI;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace StoneWoodBooks
{
    public partial class MyAccount : Page
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            cmd.Connection = conn;

            string un = (string)Cache.Get("Username"); // short for username

            cmd.CommandText = "Select Email, Phone, StreetName, City, State, Zip from CustEmail, CustPhone, " +
                "CustAddress where CustEmail.Username = " + un + " and CustPhone.Username = " + un + " and CustPhone.Username = " + 
                 un + " and CustAddress.Username = " + un + ";";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            txtEmail.Text = reader["Email"].ToString();
            txtPhone.Text = reader["Phone"].ToString();
            txtStreet.Text = reader["Street"].ToString();
            txtCity.Text = reader["City"].ToString();
            ddlState.SelectedValue = reader["State"].ToString();
            txtZip.Text = reader["Zip"].ToString();

            conn.Close();
            
        }

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

            // Test if the alt email address is a valid one within 200 ms
            try
            {
                if (!Regex.IsMatch(txtAltEmail.Text, @"(.*\D+.*)@(.*\D+.*)\.(\D+)", RegexOptions.None,
                    TimeSpan.FromMilliseconds(200)) || Regex.IsMatch(txtAltEmail.Text, @"[\s_]"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                        "alert('You have inserted an invalid email address')", true);
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

        protected void EditInfo(object sender, EventArgs e)
        {
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            cmd.Connection = conn;
            string un = (string)Cache.Get("Username"); // short for username

            // This case allows changes
            if (txtPhone.Enabled == false)
            {
                btnEditInfo.Text = "Submit Change";
                txtEmail.Enabled = true;
                txtAltEmail.Enabled = true;
                txtPhone.Enabled = true;
                txtStreet.Enabled = true;
                txtCity.Enabled = true;
                txtZip.Enabled = true;
                ddlState.Enabled = true;
            }

            // This checks if the email and phone is valid
            else if (!isValid()) { } // Do nothing

            // This case submits all changes
            else
            {
                txtEmail.Enabled = false;
                txtAltEmail.Enabled = false;
                txtPhone.Enabled = false;
                txtStreet.Enabled = false;
                txtCity.Enabled = false;
                txtZip.Enabled = false;
                ddlState.Enabled = false;

                conn.Open();
                cmd.CommandText = "Update CustEmail set Email = " + txtEmail.Text + " where Username = " + un + ";";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "Update CustPhone set Phone = " + txtPhone.Text + " where Username = " + un + ";";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "Update CustStreet set StreetName " + txtStreet.Text + ", Zip  = " + txtZip.Text + 
                    ", State = " + ddlState.Text + " where Username = " + un + ";";
                cmd.ExecuteNonQuery();
                conn.Close();

                btnEditInfo.Text = "Edit Info";

            }
        }

        protected void btnPW_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdatePW.aspx");
        }
    }

}