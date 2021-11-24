using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoneWoodBooks
{
    public partial class CustomersTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //onload1(sender, e);
            onload2(sender, e);
            onload3(sender, e);
            onload4(sender, e);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Customer";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = reader["Username"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Password"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Fname"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Lname"].ToString();
                    tr.Cells.Add(tc);

                    tblCustomer.Rows.Add(tr);
                }
            }
            conn.Close();
        }

        protected void onload1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtCustomer.Text.Equals(""))
            {
                cmd.CommandText = txtCustomer.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM Customer";
            }
            while (tblCustomer.Rows.Count > 1)
                tblCustomer.Rows.RemoveAt(1);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                
            cmd.Connection = conn;
                
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TableRow tr = new TableRow();
                        TableCell tc = new TableCell();
                        tc.Text = reader["Username"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Password"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Fname"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Lname"].ToString();
                        tr.Cells.Add(tc);

                        tblCustomer.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }
        protected void btnQueryCustomer_Click(object sender, EventArgs e)
        {
            onload1(sender, e);
        }

        protected void onload2(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtCustomerPhone.Text.Equals(""))
            {
                cmd.CommandText = txtCustomerPhone.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM CustomerPhone";
            }
            while (tblCustomerPhone.Rows.Count > 1)
                tblCustomerPhone.Rows.RemoveAt(1);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                
            cmd.Connection = conn;
                
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TableRow tr = new TableRow();
                        TableCell tc = new TableCell();
                        tc.Text = reader["Username"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Phone"].ToString();
                        tr.Cells.Add(tc);

                        tblCustomerPhone.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }
        protected void btnQueryCustomerPhone_Click(object sender, EventArgs e)
        {
            onload2(sender, e);
        }

        protected void onload3(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtCustomerEmail.Text.Equals(""))
            {
                cmd.CommandText = txtCustomerEmail.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM CustomerEmail";
            }
            while (tblCustomerEmail.Rows.Count > 1)
                tblCustomerEmail.Rows.RemoveAt(1);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                
            cmd.Connection = conn;
                
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TableRow tr = new TableRow();
                        TableCell tc = new TableCell();
                        tc.Text = reader["Username"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Email"].ToString();
                        tr.Cells.Add(tc);

                        tblCustomerEmail.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }
        protected void btnQueryCustomerEmail_Click(object sender, EventArgs e)
        {
            onload3(sender, e);
        }

        protected void onload4(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtCustomerAddress.Text.Equals(""))
            {
                cmd.CommandText = txtCustomerAddress.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM CustomerAddress";
            }
            while (tblCustomerAddress.Rows.Count > 1)
                tblCustomerAddress.Rows.RemoveAt(1);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                
            cmd.Connection = conn;
                
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TableRow tr = new TableRow();
                        TableCell tc = new TableCell();
                        tc.Text = reader["Username"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["StreetNum"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["StreetName"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["City"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["State"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Zip"].ToString();
                        tr.Cells.Add(tc);

                        tblCustomerAddress.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }

        protected void btnQueryCustomerAddress_Click(object sender, EventArgs e)
        {
            onload4(sender, e);
        }
    }
}