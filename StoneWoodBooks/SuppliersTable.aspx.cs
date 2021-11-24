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
    public partial class SuppliersTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            onload2(sender, e);
            onload3(sender, e);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Supplier";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = reader["SupplierID"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Name"].ToString();
                    tr.Cells.Add(tc);

                    tblSupplier.Rows.Add(tr);
                }
            }
        }

        protected void onLoad1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtSupplier.Text.Equals(""))
            {
                cmd.CommandText = txtSupplier.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM Supplier";
            }
            while (tblSupplier.Rows.Count > 1)
                tblSupplier.Rows.RemoveAt(1);

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
                        tc.Text = reader["SupplierID"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Name"].ToString();
                        tr.Cells.Add(tc);

                        tblSupplier.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }

        protected void onload2(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtSupplierRep.Text.Equals(""))
            {
                cmd.CommandText = txtSupplierRep.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM SupplierRep";
            }
            while (tblSupplierRep.Rows.Count > 1)
                tblSupplierRep.Rows.RemoveAt(1);

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
                        tc.Text = reader["RepID"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Lname"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Fname"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["CellNum"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["WorkNum"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Email"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["SupplierID"].ToString();
                        tr.Cells.Add(tc);

                        tblSupplierRep.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }

        protected void onload3(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtSuppliedBy.Text.Equals(""))
            {
                cmd.CommandText = txtSuppliedBy.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM SuppliedBy";
            }
            while (tblSuppliedBy.Rows.Count > 1)
                tblSuppliedBy.Rows.RemoveAt(1);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            //SqlCommand cmd = new SqlCommand();
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
                        tc.Text = reader["ISBN"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["SupplierID"].ToString();
                        tr.Cells.Add(tc);

                        tblSuppliedBy.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }
        protected void btnQuerySupplier_Click(object sender, EventArgs e)
        {
            onLoad1(sender, e);
        }

        protected void btnQuerySupplierRep_Click(object sender, EventArgs e)
        {
            onload2(sender, e);
        }

        protected void btnQuerySuppliedBy_Click(object sender, EventArgs e)
        {
            onload3(sender, e);
        }
    }
}