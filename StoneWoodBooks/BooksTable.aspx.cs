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
    public partial class BooksTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            onload2(sender, e); //this calls helper method to build Books_Author table at first page load
            onload3(sender, e); //builds BookCategories at first page load
            onload4(sender, e); //builds Book_And_Category at first page load
            onload5(sender, e); //builds SuppliedBy table
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Books";
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
                    tc.Text = reader["Title"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Price"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["PublicationDate"].ToString();
                    tr.Cells.Add(tc);

                    tblBooks.Rows.Add(tr);
                }
            }
            conn.Close();
        }

        protected void onload1(object sender, EventArgs e)
        {
            if (!txtBooks.Text.Equals(""))
            {
                while (tblBooks.Rows.Count > 1)
                    tblBooks.Rows.RemoveAt(1);

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = txtBooks.Text;
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
                            tc.Text = reader["Title"].ToString();
                            tr.Cells.Add(tc);

                            tc = new TableCell();
                            tc.Text = reader["Price"].ToString();
                            tr.Cells.Add(tc);

                            tc = new TableCell();
                            tc.Text = reader["PublicationDate"].ToString();
                            tr.Cells.Add(tc);

                            tblBooks.Rows.Add(tr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
                }
                conn.Close();
            }
        }

        protected void onload2(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtBooks_Authored.Text.Equals(""))
            {
                cmd.CommandText = txtBooks_Authored.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM Books_Authored";
            }
            while (tblBooks_Authored.Rows.Count > 1)
                tblBooks_Authored.Rows.RemoveAt(1);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            cmd.Connection = conn;
            //cmd.CommandText = txtBooks_Authored.Text;
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
                        tc.Text = reader["AID"].ToString();
                        tr.Cells.Add(tc);

                        tblBooks_Authored.Rows.Add(tr);
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
            if (!txtBookCategories.Text.Equals(""))
            {
                cmd.CommandText = txtBookCategories.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM BookCategories";
            }
            while (tblBookCategories.Rows.Count > 1)
                tblBookCategories.Rows.RemoveAt(1);

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
                        tc.Text = reader["CategoryID"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["CategoryDescription"].ToString();
                        tr.Cells.Add(tc);

                        tblBookCategories.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }

        protected void onload4(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtBook_And_Category.Text.Equals(""))
            {
                cmd.CommandText = txtBook_And_Category.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM Book_And_Category";
            }
            while (tblBook_And_Category.Rows.Count > 1)
                tblBook_And_Category.Rows.RemoveAt(1);

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
                        tc.Text = reader["ISBN"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["CategoryID"].ToString();
                        tr.Cells.Add(tc);

                        tblBook_And_Category.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }

        protected void onload5(object sender, EventArgs e)
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
        protected void btnQueryBooks_Click(object sender, EventArgs e)
        {
            onload1(sender, e);
        }

        protected void btnQueryBooks_Authored_Click(object sender, EventArgs e)
        {
            onload2(sender, e);
        }

        protected void btnQueryBookCategories_Click(object sender, EventArgs e)
        {
            onload3(sender, e);
        }

        protected void btnQueryBook_And_Category_Click(object sender, EventArgs e)
        {
            onload4(sender, e);
        }

        protected void btnQuerySuppliedBy_Click(object sender, EventArgs e)
        {
            onload5(sender, e);
        }
    }
}