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

            // This lets you add new info to the textboxes
            if (!IsPostBack)
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                cmd.Connection = conn;

                string un = (string)Cache.Get("Username"); // short for username

                cmd.CommandText = "Select (select Min(Email) From CustomerEmail Where Username = '" + un + "') as Email1, (select " +
                    "Max(Email) From CustomerEmail Where Username = '" + un + "' and not Email = ((select Min(Email) From CustomerEmail " +
                    "Where Username = '" + un + "'))) as Email2, Phone, StreetName, StreetNum, City, State, Zip from CustomerEmail, " +
                    "CustomerPhone, CustomerAddress WHERE CustomerEmail.Username = '" + un + "' AND " +
                    "CustomerPhone.Username = '" + un + "' AND CustomerAddress.Username = '" + un + "';";

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Fill the txtboxes on loadup
                    txtEmail.Text = reader["Email1"].ToString();
                    txtAltEmail.Text = reader["Email2"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtStreet.Text = reader["StreetNum"].ToString() + " " + reader["StreetName"].ToString();
                    txtCity.Text = reader["City"].ToString();
                    ddlState.Text = reader["State"].ToString();
                    txtZip.Text = reader["Zip"].ToString();
                }
                conn.Close();
            }
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
                if (!txtAltEmail.Text.Equals(""))
                {
                    if (txtAltEmail.Text.Equals(txtEmail.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                            "alert('You typed the same email twice')", true);
                        return false;
                    }

                    if (!Regex.IsMatch(txtAltEmail.Text, @"(.*\D+.*)@(.*\D+.*)\.(\D+)", RegexOptions.None,
                        TimeSpan.FromMilliseconds(200)) || Regex.IsMatch(txtAltEmail.Text, @"[\s_]"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                            "alert('You have inserted an invalid email address')", true);
                        return false;
                    }
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
            else if (isValid()) {
                txtEmail.Enabled = false;
                txtAltEmail.Enabled = false;
                txtPhone.Enabled = false;
                txtStreet.Enabled = false;
                txtCity.Enabled = false;
                txtZip.Enabled = false;
                ddlState.Enabled = false;

                conn.Open();
                cmd.CommandText = "Select Count(Email) From CustomerEmail Where Username = '" + un + "';";
                SqlDataReader reader = cmd.ExecuteReader();
                int emails = 0;
                if (reader.Read())
                    int.TryParse(reader[0].ToString(), out emails);

                reader.Close();

                try
                {
                    cmd.CommandText = "Update CustomerEmail set Email = '" + txtEmail.Text + "' where " +
                        "Email = (Select Min(Email) From CustomerEmail Where Username = '" + un + "');";
                    cmd.ExecuteNonQuery();

                    // This happens when no altemail is provided but a previous email existed
                    if (txtAltEmail.Text.Equals("") & emails == 2)
                    {
                        cmd.CommandText = "Delete from CustomerEmail Where Email = (Select Max(Email) From CustomerEmail " +
                        "Where Username = '" + un + "');";
                        cmd.ExecuteNonQuery();
                    }

                    // this happens when an altemail is provided but it was originally empty
                    else if (!txtAltEmail.Text.Equals("") & emails <= 1)
                    {
                        cmd.CommandText = "Insert into CustomerEmail Values('" + un + "', '" + txtAltEmail.Text + "');";
                        cmd.ExecuteNonQuery();
                    }

                    // This happens when an existing altemail exists and is also provided
                    else if (!txtAltEmail.Text.Equals("") & emails == 2)
                    {
                        cmd.CommandText = "Update CustomerEmail set Email = '" + txtAltEmail.Text +
                            "' Where Email = (Select Max(Email) From CustomerEmail Where Username = '" + un + "');";
                        cmd.ExecuteNonQuery();
                    }
                }

                // This happens if the customer tries switching the main email with the alt
                // If this happens, delete the users emails and re-enter them
                catch (SqlException)
                {
                    cmd.CommandText = "Delete From CustomerEmail Where Username = '" + un + "';";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "Insert Into CustomerEmail Values ('" + un + "', '" + txtEmail.Text + "');";
                    cmd.ExecuteNonQuery();

                    if (!txtAltEmail.Text.Equals(""))
                    {
                        cmd.CommandText = "Insert Into CustomerEmail Values ('" + un + "', '" + txtAltEmail.Text + "');";
                        cmd.ExecuteNonQuery();
                    }
                }

                cmd.CommandText = "Update CustomerPhone set Phone = " + txtPhone.Text + " where Username = '" + un + "';";
                cmd.ExecuteNonQuery();

                // I just didnt want to make an extra box for street number, so this combines both the number and the address name
                Regex r = new Regex(@"(?<number>\d+)?\s*(?<street>[^\d]+)\s*(?<number>\d+)?$");
                Match m = r.Match(txtStreet.Text);
                string number = m.Groups["number"].Value;
                string street = m.Groups["street"].Value;


                cmd.CommandText = "Update CustomerAddress set StreetName = '" + street + "', StreetNum = " + number 
                    + ", Zip  = " + txtZip.Text + ", State = '" + ddlState.Text + "' where Username = '" + un + "';";
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