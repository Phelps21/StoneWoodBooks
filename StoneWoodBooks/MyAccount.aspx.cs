using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Globalization;

namespace StoneWoodBooks
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            // This case allows changes
            if (txtPhone.Enabled == false)
            {
                btnEditInfo.Text = "Submit Change";
                txtEmail.Enabled = true;
                txtPhone.Enabled = true;
                txtStreet.Enabled = true;
                txtCity.Enabled = true;
                txtZip.Enabled = true;
            }

            // This checks if the email and phone is valid
            else if (!isValid()) { } // Do nothing

            // This case submits all changes
            else
            {
                txtEmail.Enabled = false;
                txtPhone.Enabled = false;
                txtStreet.Enabled = false;
                txtCity.Enabled = false;
                txtZip.Enabled = false;

                btnEditInfo.Text = "Edit Info";

            }
        }

        protected void btnPW_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdatePW.aspx");
        }
    }

}